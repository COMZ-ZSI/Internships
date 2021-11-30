using Microsoft.AspNetCore.Mvc;
using DefaultApp.Services;
using DefaultApp.Models;
using System.Collections.Generic;

namespace DefaultWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : Controller
    {

        public IActionResult City(string name)
        {
            var cityWeatherForecast = new CityWeatherForecast();
            if (name != null)
            {
                WeatherForecastService weatherForecastService = new WeatherForecastService("143981cd4e4024ab2f774b2bd6237672");

                cityWeatherForecast = weatherForecastService.GetCityWeather(name);

                return View(cityWeatherForecast);
            }
            return View();
        }

        public void PostWeather([FromBody] CityWeatherForecast cityWeatherForecast)
        {
            var SaveWeatherForecastService = new ReadWriteDataService("temp/data.json");
            SaveWeatherForecastService.saveData(cityWeatherForecast);
        }

        public IActionResult ReadWeather(string name)
        {
            var ReadWeatherForecastService = new ReadWriteDataService("temp/data.json");
            var cityWeatherForecastList = ReadWeatherForecastService.readData(name);
            ViewBag.CityWeatherList = cityWeatherForecastList;
            return View("Cities");

        }

    }

}
