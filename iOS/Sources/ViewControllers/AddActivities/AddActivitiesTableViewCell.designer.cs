// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.AddActivities
{
    [Register ("AddActivitiesTableViewCell")]
    partial class AddActivitiesTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch ActivityEnabledSwtich { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ActivityNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ActivityEnabledSwtich != null) {
                ActivityEnabledSwtich.Dispose ();
                ActivityEnabledSwtich = null;
            }

            if (ActivityNameLabel != null) {
                ActivityNameLabel.Dispose ();
                ActivityNameLabel = null;
            }
        }
    }
}