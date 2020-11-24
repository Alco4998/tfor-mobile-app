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
            // Release any cached data, images, etc that aren't in use.
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            var nextControlller = segue.DestinationViewController as BirdScreenController;

            if (nextControlller != null)
            {
                nextControlller.Sitesarr = Siteslist.ToArray();
                nextControlller.root = this;
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
            bool IsConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;

            switch (segueIdentifier)
            {
                case "SurveySegue":
                    return IsConnected;

                case "BirdSegue":
                    return IsConnected;

                case "MonitorSegue":
                    return IsConnected;
            }

            return base.ShouldPerformSegue(segueIdentifier, sender);
        }
    }
}