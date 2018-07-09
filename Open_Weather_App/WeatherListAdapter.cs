using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Open_Weather_App.Dto;
using Android.Graphics;

namespace Open_Weather_App
{
    class WeatherListAdapter : BaseAdapter<WeatherListItem>
    {

        private  Context mContext;
        private List<WeatherListItem> mForecastItem;

        public WeatherListAdapter(Context mContext, List<WeatherListItem> mForecastItem)
        {
            this.mContext = mContext;
            this.mForecastItem = mForecastItem;
        }


        public override long GetItemId(int position)
        {
            return position;
        }

       public override WeatherListItem this[int position]
        {
            get
            {
                return mForecastItem[position];
            }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
           

          //  if (view != null) holder = view.Tag as WeatherListAdapterViewHolder;
          
            if (view == null)
            {
             
                view = LayoutInflater.From(mContext).Inflate(Resource.Layout.details_layout, parent, false);    
            }
            String Field = mForecastItem[position].mName;
            String Data = mForecastItem[position].mData;

            

            var Field_tv = view.FindViewById(Resource.Id.tbName) as TextView;
            var Data_tv = view.FindViewById(Resource.Id.tbData) as TextView;

            Field_tv.Text = Field;
            Data_tv.Text = Data;
            if ((position) % 2 == 0)
          {
                view.SetBackgroundResource(Resource.Drawable.border1);
                 
           }

            if ((position) == (Count - 1))
            {
                Data_tv.SetTextColor(Color.Rgb(255, 127, 80));
        }
         

            return view;
        }

        //Fill in count here, currently 0
        public override int Count
        {
            get
            {
                return mForecastItem.Count;
            }
        }

    }

    class WeatherListAdapterViewHolder : Java.Lang.Object
    {
       
        public TextView mTitle;
        public TextView mData;
    }
}