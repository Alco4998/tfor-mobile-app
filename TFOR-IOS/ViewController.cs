using UIKit;
using System;
using System.IO;
using Foundation;
using System.Net;
using System.Data;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using NetworkAccess = Xamarin.Essentials.NetworkAccess;

namespace TFOR_IOS
{
    public partial class MainMenuController : UIViewController
    {
        public string Sites { get; private set; }
        public List<Site> Siteslist { get; set; }


        
        public MainMenuController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ServerServices services = new ServerServices();

            Siteslist = services.GetSites();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "BirdSegue")
            {
                var nextControlller = segue.DestinationViewController as BirdScreenController;

                if (nextControlller != null)
                {
                    nextControlller.Sitesarr = Siteslist.ToArray();
                }
            }
            else if (segue.Identifier == "MonitorSegue")
            {
                var nextControlller = segue.DestinationViewController as MonitorScreenController;

                if (nextControlller != null)
                {
                    nextControlller.Sitesarr = Siteslist.ToArray();
                }
            }
            else if (segue.Identifier == "SurveySegue")
            {
                var nextControlller = segue.DestinationViewController as SurveyScreenController;

                if (nextControlller != null)
                {
                    nextControlller.Sitesarr = Siteslist.ToArray();
                }
            }
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

        

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            //bool IsConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;
            bool IsConnected = true;

            switch (segueIdentifier)
            {
                case "SurveySegue":
                    return true;

                case "BirdSegue":
                    return IsConnected;

                case "MonitorSegue":
                    return IsConnected;

                default:
                    return true;

            }

            //return base.ShouldPerformSegue(segueIdentifier, sender);
        }
    }
}