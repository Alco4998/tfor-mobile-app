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
            
            ///Instatiates the required objects to make the Picker view work
            ServerServices services = new ServerServices();
            Siteslist = services.GetSites();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        ///PrepareForSegue is used to tranfer the Sites infomation to the relevant screen
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
        /// If there is an internet connection it will move between screens
        /// </summary>
        /// <returns>if Segue Idenifier is equal to any of the screens segue identifiers then move based on the internet connectivity</returns>
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

                default:
                    return true;

            }
        }
    }
}