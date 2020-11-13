using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace TFOR_IOS
{
    public partial class BirdScreenController : UIViewController
    {
        public Site[] Sitesarr { get; set; }
        public List<Sighting> Sightings { get; set; } = new List<Sighting>();

        public BirdScreenController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            BASitePicker.Model = new SiteModel(Sitesarr);
            

            SightingsAddButton.TouchUpInside += (Sender, e) => CreateSighting();
        }

        public override void ViewWillAppear(bool animated)
        {
            SightingTableView.Source = new SightingsTableSource(Sightings);
            base.ViewWillAppear(animated);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if(segue.Identifier == "AddBirdSegue")
            {
                var navctlr = segue.DestinationViewController as SightingDetailController;
                if (navctlr != null)
                {
                    var table = SightingTableView;

                    var source = table.Source as SightingsTableSource;
                    var rowpath = table.IndexPathForSelectedRow;
                    var item = source.GetItem(rowpath.Row);

                    navctlr.SetSighting(this, item);
                }
            }
        }

        public void SaveSighting(Sighting sighting)
        {
            var oldSighting = Sightings.Find(t => t.Id == sighting.Id);
                NavigationController.PopViewController(true);
        }

        public void DeleteSighting(Sighting sighting)
        {
            var oldSighting = Sightings.Find(t => t.Id == sighting.Id);
            Sightings.Remove(oldSighting);
                NavigationController.PopViewController(true);
        }

        public void CreateSighting()
        {
            int newId = 0;
            if(Sightings.Count != 0)
            {
                newId = Sightings[Sightings.Count - 1].Id + 1;
            }
            
            var newsighting = new Sighting{Id = newId };
            Sightings.Add(newsighting);

            var detail = Storyboard.InstantiateViewController("detail") as SightingDetailController;
            detail.SetSighting(this, newsighting);
            NavigationController.PushViewController(detail, true);
        }
    }
}