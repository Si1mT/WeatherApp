using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WeatherAppTwo
{
    public class CustomAdapter : BaseAdapter<string>
    {
        List<string> items;
        List<string> Date;
        List<string> Temp;
        List<string> Desc;
        Activity context;

        public CustomAdapter(Activity context, List<string> items, List<string> Date, List<string> Temp, List<string> Desc) : base()
        {
            this.context = context;
            this.items = items;
            this.Date = Date;
            this.Temp = Temp;
            this.Desc = Desc;
        }

        public override string this[int position]
        {
            get { return items[position]; }
        }

        public override int Count { get { return Temp.Count; } }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.activity_list, null);

            view.FindViewById<TextView>(Resource.Id.textView1).Text = Date[position];
            view.FindViewById<TextView>(Resource.Id.textView2).Text = Temp[position];
            view.FindViewById<TextView>(Resource.Id.textviewnumberthree).Text = Desc[position];
            return view;
        }
    }
}