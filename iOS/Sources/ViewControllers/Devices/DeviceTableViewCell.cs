using System;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Devices
{
	public partial class DeviceTableViewCell : UITableViewCell
	{
		public DeviceTableViewCell(IntPtr handle) : base(handle)
		{
		}

		internal void UpdateCell(Model.Device device)
		{
			DeviceNameLabel.Text = device.Name;
			DeviceTypeLabel.Text = device.Type;
		}
	}
}