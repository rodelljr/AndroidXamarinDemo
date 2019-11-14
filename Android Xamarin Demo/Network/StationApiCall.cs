using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using XamarinDemo.Interfaces;
using XamarinDemo.Models;

namespace XamarinDemo.Network
{
    public class StationApiCall
    {
        GetDataListener listener;
        string mUrl;

        public StationApiCall(GetDataListener listener, string url)
        {
            this.listener = listener;
            mUrl = url;
            MakeApiCall();
        }

        async void MakeApiCall()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetStringAsync(mUrl);
                //var posts = JsonConvert.DeserializeObject<List<ResponseModel>>(result);
                listener.OnApiReturn(result);
            }
        }

    }
}