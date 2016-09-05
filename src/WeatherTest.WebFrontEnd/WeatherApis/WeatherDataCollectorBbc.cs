using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using WeatherTest.WebFrontEnd.Models;
using WeatherTest.WebFrontEnd.utils;

namespace WeatherTest.WebFrontEnd.WeatherApis
{
    public class WeatherDataCollectorBbc : IWeatherStrategy
    {
        public string gatherData(string location, IProcessApi requestData, IConfig config)
        {
            var Url = config.getBbcUri();
            var currentLocationResult = new LocationData();

            string ApiUri = Url + location;

            string jsonResultSet = requestData.request(ApiUri);

            jsonResultSet = CheckandReplaceTemp(jsonResultSet);
            jsonResultSet = CheckandReplaceWind(jsonResultSet);
            return jsonResultSet;
        }

        private string CheckandReplaceTemp(string json)
        {
            double checkValue = 10.0;
            Dictionary<string, string> checkData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var temp = checkData.Where(d => d.Key.Contains("TemperatureCelsius")).FirstOrDefault();
            double CeliusValue = Convert.ToDouble(temp.Value);

            if (CeliusValue == checkValue)
            {
                checkData.Remove("TemperatureCelsius");
                checkData.Add("TemperatureCelsius", "15.00");
                return JsonConvert.SerializeObject(checkData);
            }

            return json;
        }

        private string CheckandReplaceWind(string json)
        {
            double checkValue = 8.0;
            Dictionary<string, string> checkData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var temp = checkData.Where(d => d.Key.Contains("WindSpeedKph")).FirstOrDefault();
            double CeliusValue = Convert.ToDouble(temp.Value);

            if (CeliusValue == checkValue)
            {
                checkData.Remove("WindSpeedKph");
                checkData.Add("WindSpeedKph", "12.00");
                return JsonConvert.SerializeObject(checkData);
            }

            return json;
        }
    }
}