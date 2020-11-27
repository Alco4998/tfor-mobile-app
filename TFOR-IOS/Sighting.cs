using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace TFOR_IOS
{
    public class Sighting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }

        public Sighting(int id) { Id = id; }

        public Sighting(int id, string name, string amount)
        {
            Name = name;
            bool Intparse = int.TryParse(
                amount, out int ParsedAmount);
            Amount = ParsedAmount;
        }
        
        /// <summary>
        /// Vaildates Sighting before submission to the Bird screen
        /// </summary>
        /// <returns>
        /// Checks if the Amount is greater 0 and the name is not blank
        /// </returns>
        public bool VaildForSighting()
        {
            return Amount > 0 && Name != string.Empty;
        }

        /// <summary>
        /// Prints it's infomation in a easy to read for the Display list
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0}:{1}", Name, Amount);
        }
    }
}