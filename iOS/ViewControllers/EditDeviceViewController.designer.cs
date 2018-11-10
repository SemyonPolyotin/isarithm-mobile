// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace isarithmmobile.iOS.ViewControllers
{
    [Register ("EditDeviceViewController")]
    partial class EditDeviceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView ModelPickerView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ModelPickerView != null) {
                ModelPickerView.Dispose ();
                ModelPickerView = null;
            }
        }
    }
}