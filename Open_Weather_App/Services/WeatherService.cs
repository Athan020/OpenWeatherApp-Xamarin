using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Json;
using System.Net.Http;
using Newtonsoft.Json;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Open_Weather_App.Dto;
using System.Net.Http.Headers;
using Open_Weather_App;
using System.Net;
using Square.Picasso;

namespace Weather_App.Serwinvices
{
    static class Constants
    {
        public const string baseUrl = "http://api.openweathermap.org/data/2.5/weather?q=";
        public const string key = "&units=metric&type=accurate&appid=460cc8bee30660deca0296e2f3ffef24";
    }

    class WeatherService : AsyncTask<string, Integer, Forecast>
    {
        WeatherDetailsActivity mActivity;
        TextView mWeatherTitle_tv;
        TextView mTimeStamp_tv;
        TextView mForecast_tv;
        ImageView mWeatherIcon_iv;
        TextView mTemp_tv;
        ListView mWeatherDetails_lv;
        public WeatherService(WeatherDetailsActivity mActivity)
        {
            this.mActivity = mActivity;
        }

        void showLoaderOnly()
        {

            mActivity.FindViewById(Resource.Id.loader_pb).Visibility = ViewStates.Visible;
            mActivity.FindViewById(Resource.Id.weather_location).Visibility = ViewStates.Invisible;
            mActivity.FindViewById(Resource.Id.weather_icon).Visibility = ViewStates.Invisible;
            mActivity.FindViewById(Resource.Id.forecast).Visibility = ViewStates.Invisible;
            mActivity.FindViewById(Resource.Id.temp).Visibility = ViewStates.Invisible;
            mActivity.FindViewById(Resource.Id.time_stamp).Visibility = ViewStates.Invisible;
        }
        void showAllContent()
        {
            mActivity.FindViewById(Resource.Id.loader_pb).Visibility = ViewStates.Invisible;
            mActivity.FindViewById(Resource.Id.weather_location).Visibility = ViewStates.Visible;
            mActivity.FindViewById(Resource.Id.weather_icon).Visibility = ViewStates.Visible;
            mActivity.FindViewById(Resource.Id.forecast).Visibility = ViewStates.Visible;
            mActivity.FindViewById(Resource.Id.temp).Visibility = ViewStates.Visible;
            mActivity.FindViewById(Resource.Id.time_stamp).Visibility = ViewStates.Visible;
        }

        protected override void OnPreExecute()
        {
            base.OnPreExecute();
            mWeatherDetails_lv = mActivity.FindViewById(Resource.Id.listView) as ListView;
            mWeatherIcon_iv = mActivity.FindViewById(Resource.Id.weather_icon) as ImageView;
            mWeatherTitle_tv = mActivity.FindViewById(Resource.Id.weather_location) as TextView;
            mTemp_tv = mActivity.FindViewById(Resource.Id.temp) as TextView;
            mTimeStamp_tv = mActivity.FindViewById(Resource.Id.time_stamp) as TextView;
            mForecast_tv = mActivity.FindViewById(Resource.Id.forecast) as TextView;
            showLoaderOnly();
        }

        protected override void OnProgressUpdate(params Integer[] values)
        {
            base.OnProgressUpdate(values);
        }

        protected override  Forecast RunInBackground(params string[] @params)
        {
            //   Forecast forecast =  FetchWeather("cape town"));
            string query = @params[0];
            var uri = new Uri(Constants.baseUrl + query + Constants.key);
            Forecast forecast = new Forecast();
            using (var mWebClient = new WebClient())
            {
                var response = mWebClient.DownloadString(uri);
                forecast = JsonConvert.DeserializeObject<Forecast>(response);
                Console.WriteLine(response);
            }
                return forecast;
        }
        protected override void OnPostExecute(Forecast result)
        {
            
            if(result != null && !result.Equals(""))
            {
                showAllContent(); 
                List<WeatherListItem> Itemlist = new List<WeatherListItem>();
                Picasso.With(mActivity)
                    .Load("http://openweathermap.org/img/w/" + result.Weather[0].Icon.ToString() + ".png")
                    .Resize(250,250)
                    .Into(mWeatherIcon_iv);

                mWeatherTitle_tv.Append(" " + result.Name + "," + result.Sys.Country);
                mTemp_tv.Text = result.Main.Temp.ToString() +"C";
                mTimeStamp_tv.Text = DateTime.Now.ToLocalTime().ToString("hh:mm");
                mForecast_tv.Text = result.Weather[0].Description;

                Itemlist.Add(new WeatherListItem("Wind", GetWindRating(result.Wind.Speed) + " " + result.Wind.Speed + " m/s \n " + GetWindDirection(result.Wind.Deg) + " " + result.Wind.Deg + " deg"));
                Itemlist.Add(new WeatherListItem("Cloudiness",result.Weather[0].Description));
                Itemlist.Add(new WeatherListItem("Presure", result.Main.Pressure.ToString() +" hpa"));
                Itemlist.Add(new WeatherListItem("Humidty", result.Main.Humidity.ToString() + " %"));
                Itemlist.Add(new WeatherListItem("Sunrise", LocallizeTime(result.Sys.Sunrise)));
                Itemlist.Add(new WeatherListItem("Sunset", LocallizeTime(result.Sys.Sunset)));
                Itemlist.Add(new WeatherListItem("Geo Coords", "[" + result.Coord?.Lat.ToString() + "," + result?.Coord?.Lon.ToString() + "]"));

                Itemlist.ForEach(e => Console.WriteLine(e.ToString()));

                mWeatherDetails_lv.Adapter = new WeatherListAdapter(mActivity.ApplicationContext, Itemlist);
            }

            base.OnPostExecute(result);
        // }

         public string LocallizeTime(long value)
        {
            var date = new DateTime(value* 1000L).ToLocalTime().ToString();

            return date;
        }

        public string GetWindDirection(double windDeg)
        {
            string windDirection = " ";
            if (windDeg == 0 || windDeg == 360)
            {
                windDirection = "North";
            }
            else if (windDeg > 0 && windDeg < 45)
            {
                windDirection = "North North-East";
            }
            else if (windDeg == 45)
            {
                windDirection = "North-East";
            }
            else if (windDeg > 45 && windDeg < 90)
            {
                windDirection = "East North-East";
            }
            else if (windDeg == 90)
            {
                windDirection = "East";
            }
            else if (windDeg > 90 && windDeg < 135)
            {
                windDirection = "East South-East";
            }
            else if (windDeg == 135)
            {
                windDirection = "South-East";
            }
            else if (windDeg > 135 && windDeg < 180)
            {
                windDirection = "South South-East";
            }
            else if (windDeg == 180)
            {
                windDirection = "South";
            }
            else if (windDeg > 180 && windDeg < 225)
            {
                windDirection = "South South-West";
            }
            else if (windDeg == 225)
            {
                windDirection = "South-West";
            }
            else if (windDeg > 225 && windDeg < 270)
            {
                windDirection = "West South-West";
            }
            else if (windDeg == 270)
            {
                windDirection = "West";
            }
            else if (windDeg > 270 && windDeg < 315)
            {
                windDirection = "West North-West";
            }
            else if (windDeg == 315)
            {
                windDirection = "North-West";
            }
            else if (windDeg > 315 && windDeg < 360)
            {
                windDirection = "West North-West";
            }
            return windDirection;
        }

        public string GetWindRating(double windspeed)
        {
            string windRating = " ";
            if (windspeed < 1)
            {
                windRating = "Calm";
            }
            else if (windspeed >= 1 && windspeed < 6)
            {
                windRating = "Light Air";
            }
            else if (windspeed >= 6 && windspeed < 12)
            {
                windRating = "Light Breeze";
            }
            else if (windspeed >= 12 && windspeed < 20)
            {
                windRating = "Gentle Breeze";
            }
            else if (windspeed >= 20 && windspeed < 29)
            {
                windRating = "Moderate Breeze";
            }
            else if (windspeed >= 29 && windspeed < 39)
            {
                windRating = "Fresh Breeze";
            }
            else if (windspeed >= 39 && windspeed < 50)
            {
                windRating = "Strong Breeze";
            }
            else if (windspeed >= 50 && windspeed < 62)
            {
                windRating = "High Wind";
            }
            else if (windspeed >= 62 && windspeed < 75)
            {
                windRating = "Gale";
            }
            else if (windspeed >= 75 && windspeed < 89)
            {
                windRating = "Severe Gale";
            }
            else if (windspeed >= 89 && windspeed < 103)
            {
                windRating = "Storm";
            }
            else if (windspeed >= 103 && windspeed < 118)
            {
                windRating = "Violent Storm";
            }
            else if (windspeed >= 118)
            {
                windRating = "Hurricane Force";
            }
            return windRating;
        }

      

        public async Task<Forecast> FetchWeather(string query)
        {
            var http = new HttpClient();
//http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uri = new Uri(Constants.baseUrl + query + Constants.key);
            Forecast forecast = new Forecast();
            var response = await http.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var JsonResponse = await response.Content.ReadAsStringAsync();
                forecast = JsonConvert.DeserializeObject<Forecast>(JsonResponse);
                Console.WriteLine("Response :" + JsonResponse);
                Console.WriteLine("Result: " + forecast);
            }

            return forecast;
         
    }
    }
}
//public async Task<Forecast> FetchWeather(string query)
//{
//    var http = new HttpClient();
//    var uri = new Uri(Constants.baseUrl + query + Constants.key);
//    Forecast forecast = new Forecast();
//    var response = await http.GetAsync(uri);

//    if (response.IsSuccessStatusCode)
//    {
//        var JsonResponse = await response.Content.ReadAsStringAsync();
//        forecast = JsonConvert.DeserializeObject<Forecast>(JsonResponse);
//        Console.WriteLine("Response :" + JsonResponse);
//        Console.WriteLine("Result: " + forecast);
//    }

//    return forecast;
//}