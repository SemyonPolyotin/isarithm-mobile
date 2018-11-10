using System;
using Foundation;
using UIKit;

namespace isarithmmobile.iOS.ViewControllers
{
	public partial class ProfileViewController : UIViewController
	{
		public ProfileViewController(IntPtr handle) : base(handle)
		{
		}

		[Action("UnwindToProfileViewController:")]
		public void UnwindToProfileViewController(UIStoryboardSegue segue)
		{
		}
	}
}