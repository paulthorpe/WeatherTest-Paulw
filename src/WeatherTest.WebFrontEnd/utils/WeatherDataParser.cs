using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherTest.WebFrontEnd.Models;
using Newtonsoft.Json;

namespace WeatherTest.WebFrontEnd.utils
{
    public class WeatherDataParser
    {
        private string jsonData;
             
        public WeatherDataParser(string json)
        {
            jsonData = json;
        }

        public LocationData ProcessData()
        {
            LocationData data = JsonConvert.DeserializeObject<LocationData>(this.jsonData);
            return data;
        }
    }
}