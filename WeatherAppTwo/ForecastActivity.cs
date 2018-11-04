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
            SetContentView(Resource.Layout.forecast);

            CityID = Intent.GetStringExtra("WeatherData");
            Forecast("asd");
        }

        private async void Forecast(object sender)
        {
            List<string> Date = new List<string>();
            List<string> Temperature = new List<string>();
            List<string> WeatherDescription = new List<string>();
            List<Weather> weather = await Core.Core.GetWeatherForecast(CityID);

            foreach (var item in weather)
            {
                Date.Add(item.Date);
                Temperature.Add(item.Temperature);
                WeatherDescription.Add(item.WeatherDescription);

            }

            ListView list = FindViewById<ListView>(Resource.Id.listView1);
            list.Adapter = new ForecastAdapter(this, weather);
        }
    }
}