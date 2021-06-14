using System;

namespace WeatherWithVue
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureMin { get; set; }

        public int TemperatureMax { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }

        public int WindSpeed { get; set; }

        public string WindDirection { get; set; }

        public string Summary { get; set; }
    }
}
