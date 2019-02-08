using System;
using System.Collections.Generic;
using Foundation;
using Isarithm.Mobile.iOS.Sources.Model;
using Isarithm.Mobile.iOS.Sources.ViewControllers.Feed;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.TVS
{
	public class FeedTvs : UITableViewSource
	{
		private List<FeedItem> feedItems;

		public FeedTvs(List<FeedItem> feedItems)
		{
			this.feedItems = feedItems;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = (FeedTableViewCell) tableView.DequeueReusableCell("feed_cell_id", indexPath);

			var feedItem = feedItems[indexPath.Row];

			cell.UpdateCell(feedItem);

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return feedItems.Count;
		}

		public FeedItem GetFeedItem(NSIndexPath indexPath)
		{
			return feedItems[indexPath.Row];
		}
	}
}