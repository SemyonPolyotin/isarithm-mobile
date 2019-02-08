using System;
using System.Collections.Generic;
using Foundation;
using Isarithm.Mobile.iOS.Sources.Model;
using Isarithm.Mobile.iOS.Sources.ViewControllers.Devices;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.TVS
{
	internal class DevicesTvs : UITableViewSource
	{
		private readonly List<Device> _devices;

		public DevicesTvs(List<Device> devices)
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

		public Device GetDevice(NSIndexPath indexPath)
		{
			return _devices[indexPath.Row];
		}
	}
}