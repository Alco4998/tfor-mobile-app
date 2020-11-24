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
    [Register ("ViewController")]
    partial class MainMenuController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BirdSButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView MainMenu { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton MSButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SurveyButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BirdSButton != null) {
                BirdSButton.Dispose ();
                BirdSButton = null;
            }

            if (MainMenu != null) {
                MainMenu.Dispose ();
                MainMenu = null;
            }

            if (MSButton != null) {
                MSButton.Dispose ();
                MSButton = null;
            }

            if (SurveyButton != null) {
                SurveyButton.Dispose ();
                SurveyButton = null;
            }
        }
    }
}