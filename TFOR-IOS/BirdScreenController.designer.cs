// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TFOR_IOS
{
    [Register ("BirdScreenController")]
    partial class BirdScreenController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView BASitePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SightingsAddButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView SightingTableView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BASitePicker != null) {
                BASitePicker.Dispose ();
                BASitePicker = null;
            }

            if (SightingsAddButton != null) {
                SightingsAddButton.Dispose ();
                SightingsAddButton = null;
            }

            if (SightingTableView != null) {
                SightingTableView.Dispose ();
                SightingTableView = null;
            }
        }
    }
}