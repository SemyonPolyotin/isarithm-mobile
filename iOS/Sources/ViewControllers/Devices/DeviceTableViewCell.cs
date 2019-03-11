using System;
using Isarithm.Common.Client.Appliance;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Devices
{
    public partial class DeviceTableViewCell : UITableViewCell
    {
        public DeviceTableViewCell(IntPtr handle) : base(handle)
        {
        }

        internal void UpdateCell(Common.Domain.Device device)
        {
            DeviceNameLabel.Text = device.Name;
            var modelResponse = ApplianceService.Current.GetModelAsync(device.ModelId).Result;
            DeviceModelLabel.Text = modelResponse.Name;
        }
    }
}