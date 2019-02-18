using System;
using System.Collections.Generic;
using Foundation;
using Isarithm.Common.Client.Account;
using Isarithm.Mobile.iOS.Sources.ViewControllers.Device;
using Plugin.Settings;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Devices
{
    public partial class DevicesViewController : UITableViewController
    {
        [Action("UnwindToDevicesViewController:")]
        public void UnwindToDevicesViewController(UIStoryboardSegue segue)
        {
        }

        public DevicesViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var loggedInUserId = CrossSettings.Current.GetValueOrDefault("LoggedInUser_id", Guid.Empty);
            if (loggedInUserId == Guid.Empty)
            {
                // TODO: Display error
            }

            var devicesResponse = AccountService.Current.GetDevicesOfUserAsync(loggedInUserId).Result;

            var devices = new List<Model.Device>();

            foreach (var deviceResponse in devicesResponse.Content)
            {
                devices.Add(new Model.Device
                {
                    Id = deviceResponse.Id,
                    Name = deviceResponse.Name,
                    ModelId = deviceResponse.ModelId
                });
            }

            DevicesTableView.Source = new DevicesTvs(devices, this);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            if (segue.Identifier == "ViewDeviceSegue")
            {
                var tvs = (DevicesTvs) DevicesTableView.Source;
                var device = tvs.GetDevice(sender as NSIndexPath);
                if (segue.DestinationViewController is DeviceViewController resultViewController)
                    resultViewController.DeviceId = device.Id;
            }
        }
    }
}