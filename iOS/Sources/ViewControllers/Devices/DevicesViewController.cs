using System;
using System.Collections.Generic;
using Foundation;
using Isarithm.Mobile.iOS.Sources.TVS;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Devices
{
	public partial class DevicesViewController : UITableViewController
	{
		public DevicesViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var devices = new List<Model.Device>
			{
				new Model.Device
				{
					Name = "Name",
					Type = "Type"
				},
				new Model.Device
				{
					Name = "3",
					Type = "4"
				}
			};

			DevicesTableView.Source = new DevicesTvs(devices);
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			// TODO: Pass selected index to next view 
		}

		[Action("UnwindToDevicesViewController:")]
		public void UnwindToDevicesViewController(UIStoryboardSegue segue)
		{
		}
	}
}