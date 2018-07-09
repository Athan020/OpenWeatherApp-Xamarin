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
using Newtonsoft.Json;

namespace Open_Weather_App.Dto
{
    public class Sys
    {
        
            [JsonProperty("type")]
            public long Type { get; set; }

            [JsonProperty("id")]
            public long Id { get; set; }

            [JsonProperty("message")]
            public double Message { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("sunrise")]
            public long Sunrise { get; set; }

            [JsonProperty("sunset")]
            public long Sunset { get; set; }
        
    }
}