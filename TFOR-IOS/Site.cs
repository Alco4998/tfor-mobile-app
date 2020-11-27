using System;
namespace TFOR_IOS
{
    /// <summary>
    /// A Site object to easly manipulate the Id and database infomation for easy of understanding 
    /// </summary>
    public class Site
    {
        public int    Id          { get; private set; }
        public string Name        { get; private set; }
        public string Description { get; private set; }

        public Site(int site_id, string name, string description)
        {
            Id          = site_id;
            Name        = name;
            Description = description;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
