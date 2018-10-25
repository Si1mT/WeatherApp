using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WeatherAppTwo.Core;
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace WeatherAppTwo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AetherDragon", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public string CityID;
        public bool forecast;
        public string id;
        Button buttonSearch;
        Button buttonForecast;
        List<string> countries = new List<string>() { "esimene", "teine" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            AppCenter.Start("9609ab13-1427-4092-925e-982d585c5922",
                   typeof(Analytics), typeof(Crashes));
            AppCenter.Start("9609ab13-1427-4092-925e-982d585c5922", typeof(Analytics), typeof(Crashes));

            buttonSearch = FindViewById<Button>(Resource.Id.button_Search);
            buttonForecast = FindViewById<Button>(Resource.Id.button_Forecast);

            //var toolbar = FindViewById<Toolbar>(Resource.Layout.top_toolbar);
            //this.SetActionBar(toolbar);



            buttonSearch.Click += Button_Click;
            buttonForecast.Click += Button_Click_Forecast;
        }

        private void Button_Click_Forecast(object sender, System.EventArgs e)
        {
            var ForecastActivity = new Intent(this, typeof(ForecastActivity));
            ForecastActivity.PutExtra("WeatherData", id);
            StartActivity(ForecastActivity);
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            var editTextCityName = FindViewById<EditText>(Resource.Id.textInputEditText_CityName);
            string city = editTextCityName.Text;
            var weather = await Core.Core.GetWeather("asd", city, CityID, forecast);

            var textViewCity = FindViewById<TextView>(Resource.Id.textView_City);
            var textViewDate = FindViewById<TextView>(Resource.Id.textView_Date);
            var buttonSearch = FindViewById<Button>(Resource.Id.button_Search);
            var textViewTemperature = FindViewById<TextView>(Resource.Id.textView_Temperature);
            var textViewHumidity = FindViewById<TextView>(Resource.Id.textView_Humidity);
            var textViewWind = FindViewById<TextView>(Resource.Id.textView_Wind);
            var imageViewWeatherState = FindViewById<ImageView>(Resource.Id.imageView_WeatherState);
            var textViewWeatherDescription = FindViewById<TextView>(Resource.Id.textView_WeatherDescription);

            textViewCity.Text = editTextCityName.Text;
            textViewTemperature.Text = weather.Temperature;
            textViewHumidity.Text = weather.Humidity;
            textViewWind.Text = weather.WindSpeed;
            textViewDate.Text = DateTime.Now.ToString("MMMM dd");
            textViewWeatherDescription.Text = weather.WeatherDescription;

            switch (weather.WeatherState)
            {
                case ("few clouds"):
                    imageViewWeatherState.SetImageResource(Resource.Drawable.fewClouds);
                    break;
                case ("clear sky"):
                    imageViewWeatherState.SetImageResource(Resource.Drawable.clearSky);
                    break;
                case ("rain"):
                    imageViewWeatherState.SetImageResource(Resource.Drawable.rain);
                    break;
                case ("thunderstorm"):
                    imageViewWeatherState.SetImageResource(Resource.Drawable.thunderstorm);
                    break;
                case ("shower rain"):
                    imageViewWeatherState.SetImageResource(Resource.Drawable.showerRain);
                    break;
                case ("snow"):
                    imageViewWeatherState.SetImageResource(Resource.Drawable.snow);
                    break;
                case ("mist"):
                    imageViewWeatherState.SetImageResource(Resource.Drawable.mist);
                    break;
                case ("fog"):
                    imageViewWeatherState.SetImageResource(Resource.Drawable.mist);
                    break;
            }
        }
    }
}