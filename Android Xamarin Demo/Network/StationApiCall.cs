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
using XamarinDemo.Interfaces;

namespace XamarinDemo.Network
{
    public class StationApiCall
    {
        GetDataListener listener;

        public StationApiCall(GetDataListener listener)
        {
            this.listener = listener;
        }

    }
}