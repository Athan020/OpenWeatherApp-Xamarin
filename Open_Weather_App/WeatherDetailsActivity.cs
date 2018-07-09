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
using Open_Weather_App.Services;

namespace Open_Weather_App
{
    [Activity(Label = "WeatherDetailsActivity")]
    public class WeatherDetailsActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_weather_details);

            // Create your application here
            string _cityQuery = Intent.GetStringExtra("City");

            GetWeather(_cityQuery);

        }
       
        public void GetWeather(string city )
        {
            var asyncTask = new WeatherService(this);

            asyncTask.Execute(city);

        }
       
        void ShowLoader()
        {

        }
    


}
}