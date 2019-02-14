using System;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.DiscoverDevice
{
    public partial class DiscoveredDeviceTableViewCell : UITableViewCell
    {
        public DiscoveredDeviceTableViewCell (IntPtr handle) : base (handle)
        {
        }

        public void UpdateCell(DiscoveredDevice device)
        {
            DeviceModelLabel.Text = device.Name;
        }
    }
}