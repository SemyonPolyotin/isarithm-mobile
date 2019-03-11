using System;
using System.Collections.Generic;
using Foundation;
using Isarithm.Common.Domain;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Feed
{
    public class FeedTvs : UITableViewSource
    {
        private readonly List<FeedItem> _feedItems;

        public FeedTvs(List<FeedItem> feedItems)
        {
            _feedItems = feedItems;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (FeedTableViewCell) tableView.DequeueReusableCell("feed_cell_id", indexPath);
            var feedItem = _feedItems[indexPath.Row];
            cell.UpdateCell(feedItem);
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _feedItems.Count;
        }

        public FeedItem GetFeedItem(NSIndexPath indexPath)
        {
            return _feedItems[indexPath.Row];
        }
    }
}