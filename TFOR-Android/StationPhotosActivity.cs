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
    [Activity(Label = "StationPhotosActivity")]
    public class StationPhotosActivity : Activity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_stations);

            // UI controls from layout
            Button backButton = FindViewById<Button>(Resource.Id.BackButton);

            backButton.Click += delegate
            {
                Finish();
            };
        }

        
    }
}