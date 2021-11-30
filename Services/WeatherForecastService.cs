using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using DefaultApp.Models;
using System.Net.Http;
using RESTfulAPIConsume.Constants;
using System.Text.Json;

namespace DefaultApp.Services
{
    public class WeatherForecastService
    {
        private string appId;
        public WeatherForecastService(string appId)
        {
            this.appId = appId;
        }
       

        public CityWeatherForecast GetCityWeather(string cityName)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add(RequestConstants.UserAgent, RequestConstants.UserAgentValue);
                var url = "https://api.openweathermap.org/data/2.5/weather?q=" + cityName + "&units=metric&appid=" + appId;
                var uri = new Uri(url);
                var apiResponse = httpClient.GetStringAsync(uri).Result;


                var cityWeatherForecast =  MapToCityWeatherForecast(apiResponse);

                return cityWeatherForecast;
            }
        }

        private CityWeatherForecast MapToCityWeatherForecast(string apiResponse)
        {
            var cityWeatherForecastApi = JsonSerializer.Deserialize<CityWeatherForecastApi>(apiResponse);

            var cityWeatherForecast = new CityWeatherForecast()
            {
                Name = cityWeatherForecastApi.name,
                //Date = DateTime.TryParse(cityWeatherForecastApi.date),
                Date = DateTime.Now,
                Summary = cityWeatherForecastApi.weather[0].description,
                TemperatureC = cityWeatherForecastApi.main.temp
            };
            
            return cityWeatherForecast;
        }
    }
}
