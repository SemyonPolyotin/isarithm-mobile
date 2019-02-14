using System;
using Foundation;
using Isarithm.Common.Client.Account;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Profile
{
    public partial class ProfileViewController : UIViewController
    {
        public ProfileViewController(IntPtr handle) : base(handle)
        {
        }

        [Action("UnwindToProfileViewController:")]
        public void UnwindToProfileViewController(UIStoryboardSegue segue)
        {
        }

        private readonly IAccountService _accountService = new AccountService();

        public override async void ViewDidLoad()
        {
            var user = await _accountService.GetUserAsync(Guid.Parse("550e2400-e29b-41d4-a716-446655440000"));
            if (user == null)
            {
                // TODO: Show error context
            }
            else
            {
                UsernameLabel.Text = user.Username ?? UsernameLabel.Text;
                NameLabel.Text = (user.Firstname ?? "FIRSTNAME") + " " + (user.Surname ?? "SURNAME");
                BioTextView.Text = user.Bio;
            }
        }
    }
}