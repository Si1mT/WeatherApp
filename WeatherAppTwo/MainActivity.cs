using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using WeatherAppTwo.Core;
using System;

namespace WeatherAppTwo
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button buttonSearch;
        EditText editTextCityName;
        TextView textViewCity;
        TextView textViewTemperature;
        TextView textViewDate;
        TextView textViewHumidity;
        TextView textViewWind;
        ImageView imageViewWeatherState;
        TextView textViewWeatherDescription;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
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

            buttonSearch.Click += Button_Click;
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