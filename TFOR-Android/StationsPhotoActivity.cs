using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Plugin.FilePicker;

namespace TFOR_Android
{
    [Activity(Label = "StationsPhotoActivity")]
    public class StationsPhotoActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.stations_photo);

            // UI controls from layout
            Button backButton = FindViewById<Button>(Resource.Id.BackButton);
            Button photoButton = FindViewById<Button>(Resource.Id.PhotosButton);
            TextView textView = FindViewById<TextView>(Resource.Id.textView);
            ImageButton imageButton = FindViewById<ImageButton>(Resource.Id.imageButton);

            backButton.Click += delegate
            {
                Finish();
            };

            photoButton.Click += async delegate
            {
                var file = await CrossFilePicker.Current.PickFile();
                if (file != null)
                {
                    textView.Text = file.FileName;

                }
            };
        }


    }
}