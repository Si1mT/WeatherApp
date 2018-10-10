using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeatherAppTwo
{
    //defines weather data properties
    public class Weather
    {
        public string Temperature { get; set; } = " ";
        public string Humidity { get; set; } = " ";
        public string WindSpeed { get; set; } = " ";
        public string WeatherState { get; set; } = " ";
        public string WeatherDescription { get; set; } = " ";
    }
}         