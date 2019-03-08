using System;
using Foundation;
using Isarithm.Mobile.iOS.Sources.Repository;
using Plugin.Settings;
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

        public override void ViewDidLoad()
        {
            var userLoaded = CrossSettings.Current.GetValueOrDefault("LoggedInUser_loaded", false);
            if (!userLoaded) UserRepository.LoadUser();

            UsernameLabel.Text = CrossSettings.Current.GetValueOrDefault("LoggedInUser_username", "ERROR");
            BioTextView.Text = CrossSettings.Current.GetValueOrDefault("LoggedInUser_bio", "");
            var avatar = CrossSettings.Current.GetValueOrDefault("LoggedInUser_avatar", null);
            if (avatar != null)
                AvatarImageView.Image = Utils.HttpUtil.LoadImage(avatar).Result;
        }
    }
}