using System;
using Foundation;
using Isarithm.Common.Client;
using UIKit;

namespace Isarithm.Mobile.iOS.ViewControllers
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

		private readonly IUserClient _userClient = new UserClient();

		public override async void ViewDidLoad()
		{
			var user = await _userClient.GetUserAsync("123");
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