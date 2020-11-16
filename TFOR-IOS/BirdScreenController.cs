using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace TFOR_IOS
{
    public partial class BirdScreenController : UIViewController
    {
        public Site[] Sitesarr { get; set; }
        public SiteModel SiteMod { get; set; } 
        public List<Sighting> Sightings { get; set; } = new List<Sighting>();
        public ViewController root { get; set; }

        public BirdScreenController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            SightingsAddButton.TouchUpInside += (Sender, e) => CreateSighting();
            BASurveyButton.TouchUpInside += (Sender, e) => SubmitSurvey();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            SiteMod = new SiteModel(Sitesarr);
            BASitePicker.Model = SiteMod;

            SightingTableView.Source = new SightingsTableSource(Sightings,this);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {

            if(segue.Identifier == "SightingSegue")
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

        public void EditSighting(Sighting editsighting)
        {
            var detail = Storyboard.InstantiateViewController("detail") as SightingDetailController;
            detail.SetSighting(this, editsighting);
            NavigationController.PushViewController(detail, true);
        }

        public void SubmitSurvey()
        {

            if ((DateTime)BAStartTImePicker.Date > (DateTime)BAEndTimePicker.Date)
            {
                BASurveyButton.SetTitle("Invaild", UIControlState.Normal);
            }
            else
            {
                BASurveyButton.SetTitle("Submit", UIControlState.Normal);
                var newSurvey = new BirdSurvey((DateTime)BADatePicker.Date, (DateTime)BAStartTImePicker.Date,
                    (DateTime)BAEndTimePicker.Date, SiteMod.GetItem(SiteMod.Selectedindex), Sightings.ToArray(), BACommentText.Text);

                root.SubmitBirdSurvey(newSurvey);
                this.NavigationController.PopViewController(true);
            }
        }
    }
}