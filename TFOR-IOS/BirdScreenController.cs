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

            ///Instatiates the required objects to make the Picker view work
            SiteMod = new SiteModel(Sitesarr);
            BASitePicker.Model = SiteMod;

            //attaches the Sightings to a updated variation of the source
            SightingTableView.Source = new SightingsTableSource(Sightings,this);
        }

        /// <summary>
        /// Passes the necessary infomatation for creating or editing the Sighting
        /// </summary>
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

        /// <summary>
        /// saves the infomation from the Survey
        /// </summary>
        /// <param name="sighting">This is the Sighting that will be saved</param>
        public void SaveSighting(Sighting sighting)
        {
            var oldSighting = Sightings.Find(t => t.Id == sighting.Id);
                NavigationController.PopViewController(true);
        }

        /// <summary>
        /// Deletes the infomation from the Survey
        /// </summary>
        /// <param name="sighting">This is the Sighting that will be Deleted</param>
        public void DeleteSighting(Sighting sighting)
        {
            var oldSighting = Sightings.Find(t => t.Id == sighting.Id);
            Sightings.Remove(oldSighting);
                NavigationController.PopViewController(true);
        }

        /// <summary>
        /// Creates a Sighting before pushing new window to edit the newly created survey
        /// </summary>
        public void CreateSighting()
        {
            int newId = 0;
            if(Sightings.Count != 0)
            {
                newId = Sightings[Sightings.Count - 1].Id + 1;
            }
            
            var newsighting = new Sighting(newId);
            Sightings.Add(newsighting);

            var detail = Storyboard.InstantiateViewController("detail") as SightingDetailController;
            detail.SetSighting(this, newsighting);
            NavigationController.PushViewController(detail, true);
        }

        /// <summary>
        /// Passes the relevent infomation about the Survey input to be edited
        /// </summary>
        /// <param name="editsighting">This is the Sighting that will be Deleted</param>
        public void EditSighting(Sighting editsighting)
        {
            var detail = Storyboard.InstantiateViewController("detail") as SightingDetailController;
            detail.SetSighting(this, editsighting);
            NavigationController.PushViewController(detail, true);
        }

        /// <summary>
        /// if the Survey is vaild it
        /// Packages up the infomation into Bird Survey object, That can then be Transformed into a API readable format and then Posts the API Readable format
        /// and Goes back to the main menu
        /// </summary>
        
        public void SubmitSurvey()
        {
            var newSurvey = new BirdSurvey((DateTime)BADatePicker.Date, (DateTime)BAStartTImePicker.Date,
                (DateTime)BAEndTimePicker.Date, SiteMod.GetItem(SiteMod.Selectedindex), Sightings.ToArray(), BACommentText.Text);

            if (newSurvey.VaildforBirdSurvey())
            {
                ServerServices services = new ServerServices();

                services.SubmitBirdSurvey(newSurvey);

                this.NavigationController.PopViewController(true);
            }
        }
    }
}