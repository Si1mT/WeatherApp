using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WeatherAppTwo.Core;
using System;
using System.Collections.Generic;
using Android.Content;

namespace WeatherAppTwo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button buttonSearch;
        Button buttonForecast;
        List<string> countries = new List<string>() { "esimene", "teine" };

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            buttonSearch = FindViewById<Button>(Resource.Id.button_Search);
            buttonForecast = FindViewById<Button>(Resource.Id.button_Forecast);



            buttonSearch.Click += Button_Click;
            buttonForecast.Click += Button_Click_Forecast;
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            var editTextCityName = FindViewById<EditText>(Resource.Id.textInputEditText_CityName);
            string city = editTextCityName.Text;
            var weather = await Core.Core.GetWeather("asd", city);

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

        private void Button_Click_Forecast(object sender, EventArgs e)
        {
            //Toast.MakeText(Application, ((TextView)args.View).Text, ToastLength.Long).Show();
            var list = FindViewById<ListView>(Resource.Id.listView1);
            list.Adapter = new CustomAdapter(this, countries);

            //var fourthActivity = new Intent(this, typeof(Activity));
            var forecastActivity = new Intent(this, typeof(ForecastActivity));
            StartActivity(forecastActivity);
        }
    }
}