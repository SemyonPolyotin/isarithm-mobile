using System;
using Foundation;
using Isarithm.Common.Client.Auth;
using Isarithm.Common.Client.Auth.Model;
using Isarithm.Mobile.iOS.Sources.Repository;
using Plugin.Settings;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Login
{
    public partial class LoginViewController : UIViewController
    {
        public LoginViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            var loggedInUserId = CrossSettings.Current.GetValueOrDefault("LoggedInUser_id", null);
            if (loggedInUserId != null)
            {
                var board = UIStoryboard.FromName("Main", null);
                var ctrl = board.InstantiateViewController("MainTabViewController");
                ctrl.ModalTransitionStyle = UIModalTransitionStyle.FlipHorizontal;
                PresentViewController(ctrl, true, null);
            }
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            {
                if (segueIdentifier == "loginSegue")
                {
                    var username = UsernameTextField.Text;
                    var password = PasswordTextField.Text;

                    if (!(username.Length > 0 && password.Length > 0))
                        return false;

                    var response = AuthService.Current.CreateTokenAsync(new UserCredentialsRequest
                        {Username = username, Password = password}).Result;
                    if (response != null)
                    {
                        CrossSettings.Current.AddOrUpdateValue("LoggedInUser_accessToken", response.AccessToken);
                        var userResponse = AuthService.Current
                            .CheckTokenAsync(new UserTokenRequest {AccessToken = response.AccessToken}).Result;
                        if (userResponse != null)
                            CrossSettings.Current.AddOrUpdateValue("LoggedInUser_id", userResponse.Id);
                        UserRepository.LoadUser();
                    }
                    else return false;
                }

                return base.ShouldPerformSegue(segueIdentifier, sender);
            }
        }
    }
}