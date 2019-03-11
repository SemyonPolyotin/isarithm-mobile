using System;
using System.Collections.Generic;
using Foundation;
using Isarithm.Common.Client.Account;
using Isarithm.Common.Client.Account.Model;
using Isarithm.Common.Client.Action;
using Plugin.Settings;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.AddActivities
{
    public partial class AddActivitiesViewController : UITableViewController
    {
        public Guid ModelId;
        public string Name;

        public AddActivitiesViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var activitiesResponse = ActionService.Current.GetActivitiesAsync().Result;

            var activities = new List<Common.Domain.Activity>();
            activitiesResponse.Content.ForEach(response =>
            {
                activities.Add(new Common.Domain.Activity
                {
                    Id = response.Id,
                    CreateDateTime = response.CreateDateTime,
                    LastUpdateDateTime = response.LastUpdateDateTime,
                    Name = response.Name
                });
            });

            TableView.Source = new AddActivitiesTvs(activities, this);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var deviceRequest = new DeviceRequest
            {
                ModelId = ModelId,
                Name = Name
            };

            var userId = CrossSettings.Current.GetValueOrDefault("LoggedInUser_id", Guid.Empty);

            var deviceResponse = AccountService.Current.CreateDeviceOfUserAsync(userId, deviceRequest).Result;
        }
    }
}