using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Weather_App.Services;
using Android.Content;

namespace Open_Weather_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText mCity_et;
        Button mCitySubmit_btn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            mCitySubmit_btn = FindViewById(Resource.Id.button) as Button;
            mCitySubmit_btn.Click += delegate { SendCityName(); };
           
        }

        protected  void SendCityName()
        {
            mCity_et = FindViewById(Resource.Id.city) as EditText;
            string mQuery = mCity_et.Text.ToString();
          
           
            Toast.MakeText(this, mQuery, ToastLength.Long).Show();
            Intent intent = new Intent(this, typeof(WeatherDetailsActivity));

            intent.PutExtra("City", mQuery);
            if (intent.HasExtra("City"))
            {
                StartActivity(intent);
            }
        }
    }
}

