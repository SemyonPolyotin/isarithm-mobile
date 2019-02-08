// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Devices
{
    [Register ("DeviceTableViewCell")]
    partial class DeviceTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DeviceInfoLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DeviceNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DeviceTypeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DeviceInfoLabel != null) {
                DeviceInfoLabel.Dispose ();
                DeviceInfoLabel = null;
            }

            if (DeviceNameLabel != null) {
                DeviceNameLabel.Dispose ();
                DeviceNameLabel = null;
            }

            if (DeviceTypeLabel != null) {
                DeviceTypeLabel.Dispose ();
                DeviceTypeLabel = null;
            }
        }
    }
}