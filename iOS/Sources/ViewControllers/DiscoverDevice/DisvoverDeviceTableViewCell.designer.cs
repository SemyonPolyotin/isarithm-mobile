// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.DiscoverDevice
{
    [Register ("DiscoveredDeviceTableViewCell")]
    partial class DiscoveredDeviceTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DeviceModelLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DeviceModelLabel != null) {
                DeviceModelLabel.Dispose ();
                DeviceModelLabel = null;
            }
        }
    }
}