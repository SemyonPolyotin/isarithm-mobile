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
    [Register ("DiscoverDeviceViewController")]
    partial class DiscoverDeviceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DiscoverDeviceTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DiscoverDeviceTableView != null) {
                DiscoverDeviceTableView.Dispose ();
                DiscoverDeviceTableView = null;
            }
        }
    }
}