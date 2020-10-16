using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace TFOR_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);


            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.main);

            // UI controls from layout
            Button stationsButton = FindViewById<Button>(Resource.Id.StationsButton);

            stationsButton.Click += delegate
            {
                StartActivity(typeof(StationsActivity));
            };

        }

    }
}