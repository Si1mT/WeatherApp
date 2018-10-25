using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using WeatherAppTwo;
using WeatherAppTwo.Core;

namespace WeatherAppTwo
{
    [Activity(Label = "ForecastActivity")]
    public class ForecastActivity : AppCompatActivity
    {
        public string CityID;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_forecast);
            CityID = Intent.GetStringExtra("WeatherData");
            forecast("s");
        }
        //, System.EventArgs e
        private async void forecast(object sender)
        {
            //item.Date, item.description, item.Temperature
            List<string> forecastweather = new List<string>();
            List<string> Date = new List<string>();
            List<string> Temperature = new List<string>();
            List<string> description = new List<string>();
            List<Weather> weather = await Core.Core.GetWeatherForecast(CityID);
            foreach (var item in weather)
            {
                Date.Add(item.Date);
                Temperature.Add(item.Temperature);
                description.Add(item.description);

            }
            ListView list = FindViewById<ListView>(Resource.Id.listView1);
            list.Adapter = new CustomAdapter(this, forecastweather, Date, Temperature, description);
        }
    }

}