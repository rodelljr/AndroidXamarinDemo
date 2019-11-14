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
using Java.Interop;
using Newtonsoft.Json;

namespace XamarinDemo.Models
{
    public class ResponseModel : Java.Lang.Object, IParcelable
    {
        private static readonly GenericParcelableCreator<ResponseModel> creator
            = new GenericParcelableCreator<ResponseModel>((parcel) => new ResponseModel(parcel));
        [JsonProperty("duration")]
        public long Duration { get; set; }
        [JsonProperty("risetime")]
        public long Risetime { get; set; }

        public ResponseModel() { }

        public ResponseModel(Parcel parcel)
        {
            Duration = parcel.ReadLong();
            Risetime = parcel.ReadLong();
        }

        public int DescribeContents()
        {
            return 0;
        }

        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            dest.WriteLong(Duration);
            dest.WriteLong(Risetime);
        }

        [ExportField("CREATOR")]
        public static GenericParcelableCreator<ResponseModel> GetCreator()
        {
            return creator;
        }

       
    }
}