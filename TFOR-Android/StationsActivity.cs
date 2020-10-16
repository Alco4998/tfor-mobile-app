using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TFOR_Android
{
    [Activity(Label = "StationsActivity")]
    public class StationsActivity : Activity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate(bundle);


            SetContentView(Resource.Layout.stations);

            // UI controls from layout
            Button backButton = FindViewById<Button>(Resource.Id.BackButton);
            Button stationPhotosButton = FindViewById<Button>(Resource.Id.StationPhotosButton);

            backButton.Click += delegate
            {
                Finish();
            };
            stationPhotosButton.Click += delegate
            {
                StartActivity(typeof(StationsPhotoActivity));
            };
        }



    }
}