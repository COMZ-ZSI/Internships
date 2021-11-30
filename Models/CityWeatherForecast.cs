using System;
using System.Collections.Generic;

namespace DefaultApp.Models
{
    //public class WeatherForecast
    //{
    //    public DateTime Date { get; set; }

    //    public int TemperatureC { get; set; }

    //    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    //    public string Summary { get; set; }
    //}

    public class CityWeatherForecast
    {
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public double TemperatureC{ get; set; }
        public string Summary { get; set; }
        //public string SummaryField;
        //public IList<DateTimeOffset> DatesAvailable { get; set; }
        //public Dictionary<string, HighLowTemps> TemperatureRanges { get; set; }
        //public string[] SummaryWords { get; set; }
    }

    //public class HighLowTemps
    //{
    //    public int High { get; set; }
    //    public int Low { get; set; }
    //}
}
