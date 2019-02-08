// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Device
{
    [Register ("DeviceViewController")]
    partial class DeviceViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView DeviceModelImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ModelLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (DeviceModelImageView != null) {
                DeviceModelImageView.Dispose ();
                DeviceModelImageView = null;
            }

            if (ModelLabel != null) {
                ModelLabel.Dispose ();
                ModelLabel = null;
            }
        }
    }
}