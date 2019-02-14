using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Devices
{
    internal class DevicesTvs : UITableViewSource
    {
        private readonly List<Model.Device> _devices;

        public DevicesTvs(List<Model.Device> devices)
        {
            _devices = devices;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (DeviceTableViewCell) tableView.DequeueReusableCell("device_cell_id", indexPath);
            var device = _devices[indexPath.Row];
            cell.UpdateCell(device);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _devices.Count;
        }

        public Model.Device GetDevice(NSIndexPath indexPath)
        {
            return _devices[indexPath.Row];
        }
    }
}