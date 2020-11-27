using Foundation;
using System;
using System.Dynamic;
using UIKit;

namespace TFOR_IOS
{
    public partial class SightingDetailController : UITableViewController
    {
        Sighting currentSighting { get; set; }
        public BirdScreenController Delegate { get; set; }

        public SightingDetailController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ///sets the name and amount to current sighting selected incase Editing is taking place
            SpeciesText.Text = currentSighting.Name;
            AmountText.Text = currentSighting.Amount.ToString();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ///Does Vaildation And save (if Vaild)
            SaveButton.TouchUpInside += (sender, e) =>
            {
                SaveValidation();
            };
        }
        /// <summary>
        /// Sets the interaction between the parent screen and the currently selected item
        /// </summary>
        /// <param name="d">The part Bird screen Controller</param>
        /// <param name="s">the current Sighting</param>
        public void SetSighting(BirdScreenController d, Sighting s)
        {
            Delegate = d;
            currentSighting = s;
        }

        /// <summary>
        /// Creates an Alert on screen when called
        /// </summary>
        /// <param name="Title">The Title of the Alerts</param>
        /// <param name="Content">The content of the Alert</param>
        private void CreateAlert(string Title, string Content)
        {
            if (Title == null)
            {
                Title = "Title";
            }

            var ViewController = UIAlertController.Create(Title, Content, UIAlertControllerStyle.Alert);

            ViewController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            PresentViewController(ViewController, true, null);
        }
        
        /// <summary>
        /// Checkes to see if the Sighting is Vaild if so submits back to the parent controller
        /// </summary>
        private void SaveValidation()
        {
            currentSighting.Name = SpeciesText.Text;

            bool parsed = int.TryParse(AmountText.Text, out int amount);

            if (!parsed) { CreateAlert("Alert", "Amount was not a Valid Amount"); }

            currentSighting.Amount = amount;

            if (!currentSighting.VaildForSighting())
            {
                CreateAlert("Alert", "Amount was not a Valid Amount");
            }
            else
            {
                Delegate.SaveSighting(currentSighting);
            }
        }
    }
}