// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.AddDevice
{
    [Register ("AddDeviceViewController")]
    partial class AddDeviceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem CancelBarButtonItem { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIBarButtonItem SaveBarButtonItem { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CancelBarButtonItem != null) {
                CancelBarButtonItem.Dispose ();
                CancelBarButtonItem = null;
            }

            if (SaveBarButtonItem != null) {
                SaveBarButtonItem.Dispose ();
                SaveBarButtonItem = null;
            }
        }
    }
}