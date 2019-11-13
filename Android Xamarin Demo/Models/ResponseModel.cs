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

namespace XamarinDemo.Models
{
    public class ResponseModel : Java.Lang.Object, IParcelable
    {
        private static readonly GenericParcelableCreator<ResponseModel> creator
            = new GenericParcelableCreator<ResponseModel>((parcel) => new ResponseModel(parcel));

        public string Message { get; set; }
        public long Duration { get; set; }
        public long Risetime { get; set; }

        public ResponseModel() { }

        public ResponseModel(Parcel parcel)
        {
            Duration = parcel.ReadLong();
            Risetime = parcel.ReadLong();
            Message = parcel.ReadString();
        }

        public int DescribeContents()
        {
            return 0;
        }

        public void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            dest.WriteLong(Duration);
            dest.WriteLong(Risetime);
            dest.WriteString(Message);
        }

        [ExportField("CREATOR")]
        public static GenericParcelableCreator<ResponseModel> GetCreator()
        {
            return creator;
        }

       
    }
}