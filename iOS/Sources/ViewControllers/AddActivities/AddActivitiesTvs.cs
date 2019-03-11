using System;
using System.Collections.Generic;
using Foundation;
using Isarithm.Common.Domain;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.AddActivities
{
    public class AddActivitiesTvs : UITableViewSource
    {
        private readonly List<Activity> _activities;
        
        private AddActivitiesViewController _viewController;

        public AddActivitiesTvs(List<Activity> activities, UIViewController addActivitiesViewController)
        {
            _activities = activities;
            _viewController = (AddActivitiesViewController) addActivitiesViewController;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (AddActivitiesTableViewCell) tableView.DequeueReusableCell("add_activity_cell", indexPath);
            var device = _activities[indexPath.Row];
            cell.UpdateCell(device);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _activities.Count;
        }
    }
}