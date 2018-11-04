using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WeatherAppTwo.Core;
using System;
using Android.Content;

namespace WeatherAppTwo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button buttonSearch;
        Button buttonForecast;
        EditText editTextCityName;
        TextView textViewCity;
        TextView textViewTemperature;
        TextView textViewDate;
        TextView textViewHumidity;
        TextView textViewWind;
        ImageView imageViewWeatherState;
        TextView textViewWeatherDescription;
        public string id;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            editTextCityName = FindViewById<EditText>(Resource.Id.textInputEditText_CityName);
            textViewCity = FindViewById<TextView>(Resource.Id.textView_City);
            textViewDate = FindViewById<TextView>(Resource.Id.textView_Date);
            buttonSearch = FindViewById<Button>(Resource.Id.button_Search);
            textViewTemperature = FindViewById<TextView>(Resource.Id.textView_Temperature);
            textViewHumidity = FindViewById<TextView>(Resource.Id.textView_Humidity);
            textViewWind = FindViewById<TextView>(Resource.Id.textView_Wind);
            imageViewWeatherState = FindViewById<ImageView>(Resource.Id.imageView_WeatherState);
            textViewWeatherDescription = FindViewById<TextView>(Resource.Id.textView_WeatherDescription);
            buttonForecast = FindViewById<Button>(Resource.Id.button_Forecast);

            buttonSearch.Click += Button_Click;
            buttonForecast.Click += Button_Forecast_Click;
        }

        private void Button_Forecast_Click(object sender, EventArgs e)
        {
            var ForecastActivity = new Intent(this, typeof(ForecastActivity));
            ForecastActivity.PutExtra("WeatherData", id);
            StartActivity(ForecastActivity);
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            string city = editTextCityName.Text;
            var weather = await Core.Core.GetWeather("asd", city);

            textViewCity.Text = editTextCityName.Text;
            textViewTemperature.Text = weather.Temperature;
            textViewHumidity.Text = weather.Humidity;
            textViewWind.Text = weather.WindSpeed;
            textViewDate.Text = DateTime.Now.ToString("MMMM dd");
            textViewWeatherDescription.Text = weather.WeatherDescription;
            id = weather.ID;

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