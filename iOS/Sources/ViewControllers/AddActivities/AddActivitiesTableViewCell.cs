using System;
using Isarithm.Common.Domain;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.AddActivities
{
    public partial class AddActivitiesTableViewCell : UITableViewCell
    {
        public AddActivitiesTableViewCell (IntPtr handle) : base (handle)
        {
        }

        public void UpdateCell(Activity activity)
        {
            ActivityNameLabel.Text = activity.Name;
        }
    }
}