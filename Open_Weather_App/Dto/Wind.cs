﻿using System;
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
    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }

        [JsonProperty("deg")]
        public long Deg { get; set; }

    }
}