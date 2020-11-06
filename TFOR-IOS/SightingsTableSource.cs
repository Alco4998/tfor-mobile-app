using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace TFOR_IOS
{
    public class SightingsTableSource : UITableViewSource
    {
        List<Sighting> tableitems;
        string cellidentifier = "SigthingCell";

        public SightingsTableSource(List<Sighting> items)
        {
            tableitems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableitems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellidentifier);

            cell.TextLabel.Text = tableitems[indexPath.Row].Name;

            return cell;
        }

        public Sighting GetItem(int id)
        {
            return tableitems[id];
        }
    }
}