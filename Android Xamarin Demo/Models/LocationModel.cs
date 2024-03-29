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

namespace XamarinDemo.Models
{
    public class LocationModel
    {
        public string Location { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public LocationModel(string location, double lat, double lon)
        {
            Location = location;
            Latitude = lat;
            Longitude = lon;
        }

        public override string ToString()
        {
            return Location;
        }
    }
}