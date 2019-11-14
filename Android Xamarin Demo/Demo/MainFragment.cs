using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using XamarinDemo.Models;

namespace XamarinDemo.Demo
{
    public class MainFragment : Fragment
    {
        static string MODEL_KEY = "model_key";
        List<ResponseModel> models;

        public static MainFragment NewInstance(List<ResponseModel> model)
        {
            MainFragment frag = new MainFragment();
            Bundle bundle = new Bundle();
            List<IParcelable> parameter = model.Cast<IParcelable>().ToList();
            bundle.PutParcelableArrayList(MODEL_KEY, parameter);
            frag.Arguments = bundle;
            return frag;
        }


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
            var result = Arguments.GetParcelableArrayList(MODEL_KEY);
            models = result.Cast<ResponseModel>().ToList();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.main_frag_item_list, container, false);
            if(view is RecyclerView)
            {
                Context myContext = view.Context;
                RecyclerView recyclerView = (RecyclerView)view;
                recyclerView.SetLayoutManager(new LinearLayoutManager(myContext));
                recyclerView.SetAdapter(new DemoRecyclerViewAdapter(myContext, models));
            }

            return view;
        }
    }

    class DemoRecyclerViewAdapter : RecyclerView.Adapter
    {
        List<ResponseModel> mValues;
        Context mContext;

        public DemoRecyclerViewAdapter(Context context, List<ResponseModel> items)
        {
            mContext = context;
            mValues = items;
        }

        public override int ItemCount { get { return mValues.Count; } }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            DemoViewHolder vh = holder as DemoViewHolder;
            vh.mDuration.Text = mValues[position].Duration.ToString();
            vh.mTime.Text = mValues[position].Risetime.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.main_frag_item, parent, false);
            return new DemoViewHolder(view);
        }

        public class DemoViewHolder : RecyclerView.ViewHolder
        {
            public View mView;
            public TextView mDuration { get;  set; }
            public TextView mTime { get;  set; }

            public DemoViewHolder(View itemView)
                : base(itemView)
            {
                mView = itemView;
                mDuration = (TextView)itemView.FindViewById(Resource.Id.tv_duration_value);
                mTime = (TextView)itemView.FindViewById(Resource.Id.tv_risetime_value);
            }
        }
    }
    

}