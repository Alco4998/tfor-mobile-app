using System;
using System.Net;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using NetworkAccess = Xamarin.Essentials.NetworkAccess;

namespace TFOR_IOS
{
    public class ServerServices
    {
        const string SITES_GET_URL = "https://gtcfxedshargwai-db202010160919.adb.ap-sydney-1.oraclecloudapps.com/ords/tfor/v1/sites";
        const string BIRD_SURVEY_POST_URL = "https://gtcfxedshargwai-db202010160919.adb.ap-sydney-1.oraclecloudapps.com/ords/tfor/v1/birdsurvey";
        readonly WebClient client = new WebClient();

        public ServerServices()
        {
        }

        /// <summary>
        /// Uses GET API to GET the infomation required to make a list Site objects
        /// </summary>
        /// <returns>
        /// Returns a List of Site Objects
        /// </returns>

        public List<Site> GetSites()
        {
            Uri uri = new Uri(SITES_GET_URL);
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");


            List<Site> SiteReturn = new List<Site>();

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                string content = string.Empty;

                try
                {
                    content = client.DownloadString(uri);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }

                var Json = JObject.Parse(content);
                var Sites = Json["items"];


                foreach (var item in Sites)
                {
                    SiteReturn.Add(JsonConvert.DeserializeObject<Site>(item.ToString()));
                }

            }
            else
            {
                Console.WriteLine("Network Error", "Failed to Connect to network");
            }

            return SiteReturn;
        }

        /// <summary>
        /// POSTs the Content of the Bird Survey to the Database
        /// </summary>
        /// <param name="birdSurvey">An object formatted for the Submission</param>
        public void SubmitBirdSurvey(BirdSurvey birdSurvey)
        {
            Uri uri = new Uri(BIRD_SURVEY_POST_URL);
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            string json = JsonConvert.SerializeObject(birdSurvey);

            var returned = client.UploadString(uri, json);

            Console.WriteLine(returned);
        }
    }
}
