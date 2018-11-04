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
using WeatherAppTwo.Core;

namespace WeatherAppTwo
{
    class ForecastAdapter : BaseAdapter<Weather>
    {
        List<Weather> items;
        Activity context;


        public ForecastAdapter(Activity context, List<Weather> items) : base()
        {
            this.context = context;
            this.items = items;
        }


        public override Weather this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.CustomRow, null);

            view.FindViewById<TextView>(Resource.Id.textView1).Text = items[position].Date;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = items[position].WeatherDescription;
            view.FindViewById<TextView>(Resource.Id.textView3).Text = items[position].Temperature;

            return view;
        }
    }
}