using System;
using System.Collections.Generic;
using DefaultApp.Models;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DefaultApp.Services
{
    public class ReadWriteDataService
    {
        private readonly string directoryPath;

        public ReadWriteDataService(string directoryPath)
        {
            this.directoryPath = directoryPath;
        }

        public void saveData(CityWeatherForecast cityWeatherForecast)
        {

            //DateTime date = DateTime.Today;
            //serialize cityWeatherForecast do 
            //string newResponse = response.Insert(1, $"\"date\": \"{date.ToString("d")}\",");
            //System.IO.File.AppendAllText(path, date.ToString()+ response + Environment.NewLine);
            if(cityWeatherForecast != null)
            {
                string serializedString = JsonSerializer.Serialize(cityWeatherForecast);
                File.AppendAllText(directoryPath, serializedString + Environment.NewLine);
            }

        }

        public List<CityWeatherForecast> readData(string cityName)
        {
            //var filecontent = System.IO.File.ReadAllLines .ReadAllText(directoryPath);
            var filecontent = System.IO.File.ReadAllLines(directoryPath);

            List<CityWeatherForecast> cityWeatherForecastList = new List<CityWeatherForecast>();

            foreach (var item in filecontent)
            {

                CityWeatherForecast cityWeatherForecast = JsonSerializer.Deserialize<CityWeatherForecast>(item);
                if(cityWeatherForecast.Name.ToUpper() == cityName.ToUpper())
                {
                    cityWeatherForecastList.Add(cityWeatherForecast);
                }
               
            }

            cityWeatherForecastList.Sort((x, y) => DateTime.Compare(y.Date, x.Date));

            var filteredList = cityWeatherForecastList.Take(5).ToList();
           
            //    int listLength = cityWeatherForecastList.Count;
            //cityWeatherForecastList.RemoveRange(4, listLength-5);


            return filteredList;
        }


    }
}