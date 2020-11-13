using System;
using UIKit;

namespace TFOR_IOS
{
    public class SiteModel : UIPickerViewModel
    {
        private Site[] Sites;
        public int Selectedindex = 0;

        public SiteModel(Site[] sites)
        {
            Sites = sites;
        }

        public override nint GetComponentCount(UIPickerView pickerView)
        {
            return 1;
        }

        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            return Sites.Length;
        }


        public override string GetTitle(UIPickerView picker, nint row, nint component)
        {
            return Sites[row].ToString();
        }

        public override void Selected(UIPickerView picker, nint row, nint component)
        {
            Selectedindex = (int)row;
        }

        public Site GetItem(int id)
        {
            return Sites[id];
        }
    }
}
