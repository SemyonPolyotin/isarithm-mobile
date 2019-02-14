// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Devices
{
    [Register ("DeviceTableViewCell")]
    partial class DeviceTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DeviceModelLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DeviceNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DeviceModelLabel != null) {
                DeviceModelLabel.Dispose ();
                DeviceModelLabel = null;
            }

            if (DeviceNameLabel != null) {
                DeviceNameLabel.Dispose ();
                DeviceNameLabel = null;
            }
        }
    }
}