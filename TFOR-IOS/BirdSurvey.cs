using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TFOR_IOS
{
    public class BirdSurvey
    {
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }

        public int SiteId { get; set; }
        public Sighting[] BirdSightings { get; set; }
        public string Comments { get; set; }

        public BirdSurvey(DateTime date, DateTime startTime, DateTime endTime, Site site, Sighting[] sightings, string comments)
        {
            Starttime = new DateTime(date.Year, date.Month,date.Day, startTime.Hour, startTime.Minute,0);
            Endtime = new DateTime(date.Year, date.Month, date.Day, endTime.Hour, endTime.Minute, 0);

            SiteId = site.Id;
            BirdSightings = sightings;

            if (comments != "Comments")
            {
                Comments = comments;
            }
            else
            {
                Comments = string.Empty;
            }
        }

        ///<summary>
        ///Returns if the Bird Survey is considered Vaild for submission to the database
        ///</summary>
        ///<returns>
        ///Returns a boolean of End Time > Start Time 
        ///and Site Id not Less the ones available
        ///and there is a Bird sighting
        /// </returns>
        public bool VaildforBirdSurvey()
        {
            return this.Starttime < this.Endtime &&
                   !(this.SiteId < 0) &&
                   this.BirdSightings.Length >= 1;
        }

        /// <summary>
        /// Prints the infomation about it's self on a line by line 
        /// </summary>
        public override string ToString()
        {
            return String.Format("{0}\n{1}\n{2}\n{3}\n{4}",Starttime,Endtime,SiteId,BirdSightings.Length.ToString(),Comments);
        }
    }
}