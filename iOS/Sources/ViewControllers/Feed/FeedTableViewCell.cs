using System;
using Isarithm.Mobile.iOS.Sources.Model;
using UIKit;

namespace Isarithm.Mobile.iOS.Sources.ViewControllers.Feed
{
	public partial class FeedTableViewCell : UITableViewCell
	{
		public FeedTableViewCell(IntPtr handle) : base(handle)
		{
		}

		public void UpdateCell(FeedItem feedItem)
		{
			FeedItemTextLabel.Text = feedItem.Text;
			FeedItemDateLabel.Text = feedItem.Date;
		}
	}
}