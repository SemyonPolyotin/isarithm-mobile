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
    [Register ("DevicesViewController")]
    partial class DevicesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView DevicesTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DevicesTableView != null) {
                DevicesTableView.Dispose ();
                DevicesTableView = null;
            }
        }
    }
}