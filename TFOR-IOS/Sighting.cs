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

        private bool Intparse { get; set; }

        public Sighting(int id) { Id = id; }

        public Sighting(int id, string name, string amount)
        {
            Name = name;
            Intparse = int.TryParse(
                amount, out int ParsedAmount);
            Amount = ParsedAmount;
        }

        public bool VaildForSighting()
        {
            return Amount > 0 && Name != string.Empty;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", Name, Amount);
        }
    }
}