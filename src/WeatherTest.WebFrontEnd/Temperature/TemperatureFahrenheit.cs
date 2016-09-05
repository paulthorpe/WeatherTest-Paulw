using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using WeatherTest.WebFrontEnd.Models;
using System.Linq;
using WeatherTest.WebFrontEnd.utils;

namespace WeatherTest.WebFrontEnd.Temperature
{
    public class TemperatureFahrenheit : ITemperature
    {
        public TempType Type
        { 
            get {
                return TempType.FAH;
            }
        }

        public double Process(List<string> data)
        {
            double tempInFahrenheit = 0;
            foreach (string item in data)
            {
                
                Dictionary<string, string> resultData = JsonConvert.DeserializeObject<Dictionary<string, string>>(item);
                var temp = resultData.Where(d => d.Key.Contains("temperature")).FirstOrDefault();
                if (temp.Key.Contains("Celsius"))
                {
                    var ConvertedValue = CelsiusToFahrenheit(temp.Value[0]);
                    tempInFahrenheit += ConvertedValue;
                }
                else
                {
                    tempInFahrenheit += temp.Value[0];
                }
            }

            tempInFahrenheit = tempInFahrenheit / data.Count;
            return tempInFahrenheit;
        }
        
        public double CelsiusToFahrenheit(double CelsiusValue)
        {
            double fahrenheitValue = ((CelsiusValue * 1.8) + 32);
            return Math.Round(fahrenheitValue,2);
        }
    }
}