// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Feed
{
    [Register ("FeedTableViewCell")]
    partial class FeedTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FeedItemDateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FeedItemTextLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (FeedItemDateLabel != null) {
                FeedItemDateLabel.Dispose ();
                FeedItemDateLabel = null;
            }

            if (FeedItemTextLabel != null) {
                FeedItemTextLabel.Dispose ();
                FeedItemTextLabel = null;
            }
        }
    }
}