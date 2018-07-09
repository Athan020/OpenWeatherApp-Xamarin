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

namespace Open_Weather_App.Dto
{
    public class WeatherListItem
    {
        private string v1;
        private string v2;

        public WeatherListItem(string v1, string v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public string mName { get; set; }
        public string mData { get; set; }
   
    }
}