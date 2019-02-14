using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.DiscoverDevice
{
    public class DiscoverDevicesTvs : UITableViewSource
    {
        private readonly List<DiscoveredDevice> _discoveredDevices;

        public DiscoverDevicesTvs(List<DiscoveredDevice> discoveredDevices)
        {
            _discoveredDevices = discoveredDevices;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (DiscoveredDeviceTableViewCell) tableView.DequeueReusableCell("discovered_device_cell", indexPath);
            var device = _discoveredDevices[indexPath.Row];
            cell.UpdateCell(device);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _discoveredDevices.Count;
        }
    }
}