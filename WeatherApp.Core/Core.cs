using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Core
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string zipCode)
        {
            string key = "43228feda419c96e87f49c3f0b8bbaea";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?q=Tallinn&units=metric&appid="+key;

            dynamic results = await DataService.GetDataFromService(queryString).ConfigureAwait(false);
            var weather = new Weather();
            weather.Temperature=(string)results["main"]["temp"] + "C";
            return weather;
        }
    }
}
