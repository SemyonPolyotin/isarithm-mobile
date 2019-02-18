using System;
using Foundation;
using Plugin.Settings;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Settings
{
    public partial class SettingsViewController : UITableViewController
    {
        public SettingsViewController (IntPtr handle) : base (handle)
        {
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if (segueIdentifier == "LogOutSegue")
            {
                CrossSettings.Current.AddOrUpdateValue("LoggedInUser_id", null);
                CrossSettings.Current.AddOrUpdateValue("LoggedInUser_username", null);
                CrossSettings.Current.AddOrUpdateValue("LoggedInUser_email", null);
                CrossSettings.Current.AddOrUpdateValue("LoggedInUser_bio", null);
                CrossSettings.Current.AddOrUpdateValue("LoggedInUser_avatar", null);
                CrossSettings.Current.AddOrUpdateValue("LoggedInUser_loaded", null);
            }
            return base.ShouldPerformSegue(segueIdentifier, sender);
        }
    }
}