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
        UIKit.UITextView BACommentText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker BADatePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker BAEndTimePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPickerView BASitePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIDatePicker BAStartTImePicker { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BASubmitButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SightingsAddButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView SightingTableView { get; set; }

        [Action ("BASubmitButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BASubmitButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BACommentText != null) {
                BACommentText.Dispose ();
                BACommentText = null;
            }

            if (BADatePicker != null) {
                BADatePicker.Dispose ();
                BADatePicker = null;
            }

            if (BAEndTimePicker != null) {
                BAEndTimePicker.Dispose ();
                BAEndTimePicker = null;
            }

            if (BASitePicker != null) {
                BASitePicker.Dispose ();
                BASitePicker = null;
            }

            if (BAStartTImePicker != null) {
                BAStartTImePicker.Dispose ();
                BAStartTImePicker = null;
            }

            if (BASubmitButton != null) {
                BASubmitButton.Dispose ();
                BASubmitButton = null;
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