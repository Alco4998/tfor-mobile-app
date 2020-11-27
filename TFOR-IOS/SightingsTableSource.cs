using Foundation;
using HomeKit;
using System;
using System.Collections.Generic;
using UIKit;

namespace TFOR_IOS
{
    /// <summary>
    /// The source model for the Table view to understand
    /// </summary>
    public class SightingsTableSource : UITableViewSource
    {
        List<Sighting> tableitems = new List<Sighting>();
        private BirdScreenController Delegate;
        string cellidentifier = "SigthingCell";

        public SightingsTableSource(List<Sighting> items, BirdScreenController b)
        {
            tableitems = items;
            Delegate = b;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableitems.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(cellidentifier);
            string item = tableitems[indexPath.Row].ToString();

            if (cell == null)
            {
                cell = new UITableViewCell(UITableViewCellStyle.Default, cellidentifier);
            }

            cell.TextLabel.Text = item;

            return cell;
        }

        public Sighting GetItem(int id)
        {
            return tableitems[id];
        }

        public override bool CanEditRow(UITableView tableView, NSIndexPath indexPath)
        {
            return true;
        }
        
        /// <summary>
        /// Creates the actions for the swipe left options
        /// </summary>
        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewRowAction editButton = UITableViewRowAction.Create(
                UITableViewRowActionStyle.Normal,
                "Edit",
                delegate
                {
                    Delegate.EditSighting(tableitems[indexPath.Row]);
                }
                );

            UITableViewRowAction deleteButton = UITableViewRowAction.Create(
                UITableViewRowActionStyle.Destructive,
                "Delete",
                delegate
                {
                    tableitems.Remove(tableitems[indexPath.Row]);
                    tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
                }
            );

            return new UITableViewRowAction[] { editButton, deleteButton };
        }
    }
}