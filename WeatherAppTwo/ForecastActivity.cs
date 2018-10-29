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
        ListView listView;
        EditText editTextCity;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_forecast);

            listView = FindViewById<ListView>(Resource.Id.listView1);

            // Create your application here
        }

        private void ForecastButton_Click(object sender, EventArgs e)
        {
            editTextCity = FindViewById<EditText>(Resource.Id.edit);
            Forecast();
        }

        private async void Forecast()
        {
            var forecasts = await Core.Core.GetForecast(editTextCity.Text);
        }
    }
} 