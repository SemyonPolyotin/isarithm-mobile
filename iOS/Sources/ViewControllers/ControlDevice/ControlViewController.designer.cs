// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Isarithm.Mobile.iOS
{
    [Register ("ControlViewController")]
    partial class ConnectViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BendButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton DefaultButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ExpandButton { get; set; }

        [Action ("BendButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BendButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("DefaultButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void DefaultButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("ExpandButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ExpandButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BendButton != null) {
                BendButton.Dispose ();
                BendButton = null;
            }

            if (DefaultButton != null) {
                DefaultButton.Dispose ();
                DefaultButton = null;
            }

            if (ExpandButton != null) {
                ExpandButton.Dispose ();
                ExpandButton = null;
            }
        }
    }
}