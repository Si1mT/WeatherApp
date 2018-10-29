using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherAppTwo;

namespace WeatherAppTwo.Core
{
    public class Core
    {
        //gets weather data from openweathermap api and defines Weather class properties with it
        public static async Task<Weather> GetWeather(string zipCode,string city)
        {
            string key = "43228feda419c96e87f49c3f0b8bbaea";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=" + city + "&units=metric&appid=" + key;

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            var weather = new Weather();
            weather.Temperature = (string)results["main"]["temp"] + "C";
            weather.Humidity = (string)results["main"]["humidity"] + "%";
            weather.WindSpeed = (string)results["wind"]["speed"] + "m/s";
            weather.WeatherState = (string)results["weather"][0]["description"];
            weather.WeatherDescription = (string)results["weather"][0]["main"];

            return weather;
        }

        public static async Task<List<Forecast>> GetForecast(string input)
        {
            string key = "43228feda419c96e87f49c3f0b8bbaea";
            string queryString = "http://api.openweathermap.org/data/2.5/forecast?q=" + input + "&units=metric&appid=" + key;
            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);

            var forecast = new List<Forecast>();

            int currentIterator = 0;
            for (int i = 0; i < 3; i++)
            {
                Forecast weather = new Forecast();
                weather.TempMin = (string)results["list"][currentIterator]["main"]["temp_min"] + " C";
                weather.TempMax = (string)results["list"][currentIterator]["main"]["temp_max"] + " C";

                forecast.Add(weather);
            }
            return forecast;
        }
    }
}
