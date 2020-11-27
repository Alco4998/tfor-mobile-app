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

            //Set the name incase 
            SpeciesText.Text = currentSighting.Name;
            AmountText.Text = currentSighting.Amount.ToString();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            SaveButton.TouchUpInside += (sender, e) =>
            {
                SaveValidation();
            };
        }

        public void SetSighting(BirdScreenController d, Sighting s)
        {
            Delegate = d;
            currentSighting = s;
        }

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

        private void SaveValidation()
        {
            if (currentSighting.Id > 0 && currentSighting.Name != string.Empty || currentSighting.Amount < 0)
            {
                currentSighting = new Sighting(currentSighting.Id, SpeciesText.Text, AmountText.Text);
            }
            else
            {
                int Amount;
                int.TryParse(AmountText.Text, out Amount);

                currentSighting.Name = SpeciesText.Text;
                currentSighting.Amount = Amount;
            }
            
            

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