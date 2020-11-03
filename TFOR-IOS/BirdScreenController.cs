using Foundation;
using System;
using UIKit;

namespace TFOR_IOS
{
    public partial class BirdScreenController : UIViewController
    {
        public Site[] Sitesarr { get; set; }
        
        public BirdScreenController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            BASitePicker.Model = new SiteModel(Sitesarr);
        }
    }
}