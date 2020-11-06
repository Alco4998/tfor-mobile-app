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

        /*public Sighting(int id, string name, int amount)
        {
            Name = name;
            Amount = amount;
        }*/

        public override string ToString()
        {
            return string.Format("{0}:{1}", Name, Amount);
        }
    }
}