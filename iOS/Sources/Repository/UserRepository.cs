using System;
using Isarithm.Common.Client.Account;
using Plugin.Settings;

namespace Isarithm.Mobile.iOS.Sources.Repository
{
    public static class UserRepository
    {
        public static void LoadUser()
        {
            var userId = CrossSettings.Current.GetValueOrDefault("LoggedInUser_id", Guid.Empty);
            var userResponse = AccountService.Current.GetUserAsync(userId).Result;
            CrossSettings.Current.AddOrUpdateValue("LoggedInUser_username", userResponse.Username);
            CrossSettings.Current.AddOrUpdateValue("LoggedInUser_email", userResponse.Email);
            CrossSettings.Current.AddOrUpdateValue("LoggedInUser_bio", userResponse.Bio);
            CrossSettings.Current.AddOrUpdateValue("LoggedInUser_avatar", userResponse.Avatar);
            CrossSettings.Current.AddOrUpdateValue("LoggedInUser_loaded", true);
        }
    }
}