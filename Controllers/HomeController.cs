using DefaultApp.Models;
using DefaultApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using DefaultWebApi.Controllers;
using System.Collections.Generic;

namespace DefaultApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        //public IActionResult Test(string id)
        //{
        //    //redirect to action controller
        //    //return RedirectToAction("City", "Home");
        //    return View(new TestModel { Id = id });
        //}

        // To test - run multiple projects
        //Default controller
        //https://localhost:{yourport}/Home/City?name=Warsaw
        //WebApi controller
        //"https://localhost:{yourport}/WeatherForecast"



        //public List<CityWeatherForecastDto> JsonData()
        //{
        //    ReadWriteDataService getData = new ReadWriteDataService("C:/Users/mcwynar/source/repos/Internships 2021/src/Interns/DefaultApp/temp/data.json");

        //    return getData.readData();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
