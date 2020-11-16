using Foundation;
using System;
using UIKit;
using System.Net;
using System.Net.Http;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xamarin.Essentials;
using NetworkAccess = Xamarin.Essentials.NetworkAccess;

namespace TFOR_IOS
{
    public partial class ViewController : UIViewController
    {
        public string Sites { get; private set; }
        public List<Site> Siteslist { get; set; }

        readonly WebClient client = new WebClient();

        const string SITES_GET_URL = "https://gtcfxedshargwai-db202010160919.adb.ap-sydney-1.oraclecloudapps.com/ords/tfor/v1/sites";
        const string BIRD_SURVEY_POST_URL = "https://gtcfxedshargwai-db202010160919.adb.ap-sydney-1.oraclecloudapps.com/ords/tfor/v1/birdsurvey";

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            Siteslist = GetSites();

            //CreateAlert("Response:", Sites);
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

        private List<Site> GetSites()
        {
            //var request = HttpWebRequest.Create(SITES_GET_URL);
            Uri uri = new Uri(SITES_GET_URL);
            client.Headers.Add(HttpRequestHeader.ContentType,"application/json");
            

            List<Site> SiteReturn = new List<Site>();

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string content = client.DownloadString(uri);

                var Json = JObject.Parse(content);
                var Sites = Json["items"];


                foreach (var item in Sites)
                {
                    SiteReturn.Add(JsonConvert.DeserializeObject<Site>(item.ToString()));
                }
                //using (HttpWebResponse webResponse = request.GetResponse() as HttpWebResponse)
                //{
                //    if (webResponse.StatusCode != HttpStatusCode.OK)
                //    {
                //        CreateAlert("Connection Issues", string.Format("Failed to call Rep Code:", webResponse.StatusCode));
                //    }
                //    else
                //    {
                //        using (StreamReader Sreader = new StreamReader(webResponse.GetResponseStream()))
                //        {
                //            var content = Sreader.ReadToEnd();

                //        }
                //    }
            } else
            {
                CreateAlert("Network Error", "Failed to Connect to network");
            }
            
            return SiteReturn;
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

        public void SubmitBirdSurvey(BirdSurvey birdSurvey)
        {
            Uri uri = new Uri(BIRD_SURVEY_POST_URL);
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");

            string json = JsonConvert.SerializeObject(birdSurvey);

            Console.WriteLine(json);

            var returned = client.UploadString(uri, json);
                


        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            bool IsConnected = Connectivity.NetworkAccess == NetworkAccess.Internet;

            switch (segueIdentifier)
            {
                case "SurveySegue":
                    return false && IsConnected;

                case "BirdSegue":
                    return IsConnected;

                case "MonitorSegue":
                    return false && IsConnected;
            }

            return base.ShouldPerformSegue(segueIdentifier, sender);
        }
    }
}