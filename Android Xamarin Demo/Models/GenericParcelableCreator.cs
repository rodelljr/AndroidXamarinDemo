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
using Java.Lang;

namespace XamarinDemo.Models
{
    public class GenericParcelableCreator<T> : Java.Lang.Object,
        IParcelableCreator where T : Java.Lang.Object, new()
    {
        private readonly Func<Parcel, T> createFunc;

        public GenericParcelableCreator(Func<Parcel, T> createFromParcelFunc)
        {
            createFunc = createFromParcelFunc;
        }

        public Java.Lang.Object CreateFromParcel(Parcel source)
        {
            return createFunc(source);
        }

        public Java.Lang.Object[] NewArray(int size)
        {
            return new T[size];
        }
    }
}