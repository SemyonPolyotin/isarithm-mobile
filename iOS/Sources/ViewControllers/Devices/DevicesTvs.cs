using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Devices
{
    internal class DevicesTvs : UITableViewSource
    {
        private readonly List<Model.Device> _devices;

        private DevicesViewController _viewController;

        public DevicesTvs(List<Model.Device> devices, DevicesViewController viewController)
        {
            _devices = devices;
            _viewController = viewController;
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

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            _viewController.PerformSegue("ViewDeviceSegue", indexPath);
        }

        public Model.Device GetDevice(NSIndexPath indexPath)
        {
            return _devices[indexPath.Row];
        }
    }
}