using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherTest.WebFrontEnd.utils;

namespace WeatherTest.WebFrontEnd.Temperature
{
    public class TemperatureCelsius : ITemperature
    {
        public TempType Type
        {
            get
            {
                return TempType.CEL;
            }
        }

        public double Process(List<string> data)
        {
            double tempInCelsius = 0;
            foreach (string item in data)
            {
                Dictionary<string, string> resultData = JsonConvert.DeserializeObject<Dictionary<string, string>>(item);
                var temp = resultData.Where(d => d.Key.Contains("temperature")).FirstOrDefault();
                if (temp.Key.Contains("Fahrenheit"))
                {
                    var ConvertedValue = FahrenheitToCelsius(temp.Value[0]);
                    tempInCelsius += ConvertedValue;
                }
                else
                {
                    tempInCelsius += temp.Value[0];
                }
            }

            tempInCelsius = tempInCelsius / data.Count;
            return tempInCelsius;
        }

        public double FahrenheitToCelsius(double fahrenheitValue)
        {
            double celsiusValue = ((fahrenheitValue - 32) * 5) / 9;
            return Math.Round(celsiusValue,2);
        }
    }
}