using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Views;
using Java.Interop;
using XamarinDemo.Models;
using System.Collections.Generic;
using XamarinDemo.Interfaces;
using System.Text;
using XamarinDemo.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using XamarinDemo.Demo;

namespace XamarinDemo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, GetDataListener
    {
        List<LocationModel> model;
        Spinner spinner;
        double mLat, mLon;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            ButtonClickEvent();
            spinner = (Spinner)FindViewById(Resource.Id.sp_drop);
            SetupSpinner();
        }

        void SetupSpinner()
        {
            ArrayAdapter adapter = new ArrayAdapter(this,
                Android.Resource.Layout.SimpleSpinnerItem, MyLocations());
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(SpinnerSelected);
        }

        void SpinnerSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            mLat = model[e.Position].Latitude;
            mLon = model[e.Position].Longitude;
        }

        void ButtonClickEvent()
        {
            var locateButton = FindViewById<Button>(Resource.Id.btn_locate);
            locateButton.Click += (sender, e) =>
            {
                MakeStationCall();
            };
        }
        
        List<LocationModel> MyLocations()
        {
            model = new List<LocationModel>();
            model.Add(new LocationModel("Arrowhead Stadium", 39.0527456, -94.490726));
            model.Add(new LocationModel("Kauffman Stadium", 39.0489432, -94.4861044));
            model.Add(new LocationModel("Children\'s Mercy Park", 39.121597, -94.8253654));
            model.Add(new LocationModel("Sprint Center", 39.0974708, -94.5823416));

            return model;
        }

        public void OnApiReturn(string result)
        {
            List<ResponseModel> model = GetStationModel(result);
            CallFragment(model);
        }

        void CallFragment(List<ResponseModel> model)
        {
            // build transaction, call Fragment and replace the framelayout
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            MainFragment frag = MainFragment.NewInstance(model);
            transaction.Replace(Resource.Id.fl_layout, frag).Commit();
        }

        void MakeStationCall()
        {
            string uri = GetAPIUri(mLat, mLon);
            StationApiCall call = new StationApiCall(this, uri);
        }

        string GetAPIUri(double lat, double lon)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("http://api.open-notify.org/iss-pass.json?lat=")
                .Append(lat).Append("&lon=").Append(lon);
            return builder.ToString();
        }

        List<ResponseModel> GetStationModel(string model)
        {
            JObject stations = JObject.Parse(model);
            IList<JToken> myResult =  stations["response"].Children().ToList();
            List<ResponseModel> responses = new List<ResponseModel>();
            foreach (JToken item in myResult)
            {
                ResponseModel model1 = item.ToObject<ResponseModel>();
                responses.Add(model1);
            }
            return responses;
                       
        }
    }
}