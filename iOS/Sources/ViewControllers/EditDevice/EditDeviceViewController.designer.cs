// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.EditDevice
{
    [Register ("EditDeviceViewController")]
    partial class EditDeviceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem CancelBarButtonItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DeviceModelTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DeviceNameTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem SaveBarButtonItem { get; set; }

        [Action ("SaveBarButtonItem_Activated:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void SaveBarButtonItem_Activated (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (CancelBarButtonItem != null) {
                CancelBarButtonItem.Dispose ();
                CancelBarButtonItem = null;
            }

            if (DeviceModelTextField != null) {
                DeviceModelTextField.Dispose ();
                DeviceModelTextField = null;
            }

            if (DeviceNameTextField != null) {
                DeviceNameTextField.Dispose ();
                DeviceNameTextField = null;
            }

            if (SaveBarButtonItem != null) {
                SaveBarButtonItem.Dispose ();
                SaveBarButtonItem = null;
            }
        }
    }
}