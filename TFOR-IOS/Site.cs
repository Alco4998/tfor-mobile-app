using System;
namespace TFOR_IOS
{
    public class Site
    {
        public int    Id          { get; private set; }
        public string Name        { get; private set; }
        public string Description { get; private set; }

        public Site(int id, string name, string description)
        {
            Id          = id;
            Name        = name;
            Description = description;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
