using Foundation;
using System;
using UIKit;
using System.Net;
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
            }
        }

        private List<Site> GetSites()
        {
            string siteurl = "https://gtcfxedshargwai-db202010160919.adb.ap-sydney-1.oraclecloudapps.com/ords/tfor/v1/sites";

            var request = HttpWebRequest.Create(siteurl);
            request.ContentType = "application/json";
            request.Method = "GET";

            List<Site> SiteReturn = new List<Site>();

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {

                using (HttpWebResponse webResponse = request.GetResponse() as HttpWebResponse)
                {
                    if (webResponse.StatusCode != HttpStatusCode.OK)
                    {
                        CreateAlert("Connection Issues", string.Format("Failed to call Rep Code:", webResponse.StatusCode));
                    }
                    else
                    {
                        using (StreamReader Sreader = new StreamReader(webResponse.GetResponseStream()))
                        {
                            var content = Sreader.ReadToEnd();

                            var Json = JObject.Parse(content);
                            var Sites = Json["items"];


                            foreach (var item in Sites)
                            {
                                SiteReturn.Add(JsonConvert.DeserializeObject<Site>(item.ToString()));
                            }

                            string teststring = "";

                            foreach (Site site in SiteReturn)
                            {
                                teststring += string.Format("{0}\n", site.Name);
                            }
                            
                            CreateAlert("Object", teststring);
                        }
                    }
                }
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

    }
}