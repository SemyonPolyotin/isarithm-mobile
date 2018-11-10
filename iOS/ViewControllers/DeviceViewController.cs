using System;
using Foundation;
using UIKit;

namespace isarithmmobile.iOS.ViewControllers
{
	public partial class DeviceViewController : UIViewController
	{
		public DeviceViewController(IntPtr handle) : base(handle)
		{
		}

		[Action("UnwindToDeviceViewController:")]
		public void UnwindToDeviceViewController(UIStoryboardSegue segue)
		{
		}
	}
}