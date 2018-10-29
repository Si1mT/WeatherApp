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
using Android.Support.V7.App;

namespace WeatherAppTwo
{
    [Activity(Label = "ForecastActivity")]
    public class ForecastActivity : AppCompatActivity
    {
        ListView list;
        TextView cityEntry;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_forecast);

            list = FindViewById<ListView>(Resource.Id.listView1);

            // Create your application here
        }

        private void WeatherButton_Click(object sender, EventArgs e)
        {
            cityEntry = FindViewById<EditText>(Resource.Id.edit);
            Forecast();
        }

        private async void Forecast()
        {
            var forecasts = await Core.Core.GetForecast(cityEntry.Text);

            if (forecasts != null)
            {
                List<int> images = new List<int>();

                //foreach (Forecast weather in forecasts)
                //{
                //    images.Add(Resources.GetIdentifier(weather.Visibility, "drawable", PackageName));
                //}

                list.Adapter = new CustomAdapter(this, forecasts, images);
            }
        }






        //    protected override void OnCreate(Bundle savedInstanceState)
        //    {
        //        base.OnCreate(savedInstanceState);
        //        SetContentView(Resource.Layout.activity_forecast);
        //        // Create your application here

        //    }
        //}

        //public class CustomAdapter : BaseAdapter<string>
        //{
        //    List<string> items;
        //    Activity context;

        //    public CustomAdapter(Activity context, List<string> items) : base()
        //    {
        //        this.context = context;
        //        this.items = items;
        //    }

        //    public override string this[int position]
        //    {
        //        get { return items[position]; }
        //    }

        //    public override int Count { get { return items.Count; } }

        //    public override long GetItemId(int position)
        //    {
        //        return position;
        //    }

        //    public override View GetView(int position, View convertView, ViewGroup parent)
        //    {
        //        View view = convertView;
        //        if (view == null)
        //            view = context.LayoutInflater.Inflate(Resource.Layout.activity_forecast, null);

        //        view.FindViewById<TextView>(Resource.Id.textView1).Text = items[position];
        //        return view;
        //    }
    }
} 