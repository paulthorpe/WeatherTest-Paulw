using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherTest.WebFrontEnd.Wind
{
    public class WindKph : IWind
    {
        public WindType Type
        {
            get
            {
                return WindType.KPH;
            }
        }

        public double Process(List<string> data)
        {
            double WindInKph = 0;
            foreach (string item in data)
            {

                Dictionary<string, string> resultData = JsonConvert.DeserializeObject<Dictionary<string, string>>(item);
                var temp = resultData.Where(d => d.Key.Contains("windSpeed")).FirstOrDefault();
                if (temp.Key.Contains("Mph"))
                {
                    var ConvertedValue = MphToKph(temp.Value[0]);
                    WindInKph += ConvertedValue;
                }
                else
                {
                    WindInKph += temp.Value[0];
                }
            }

            WindInKph = WindInKph / data.Count; 
            return WindInKph ;
        }

        public double MphToKph(double MphValue)
        {
            double mphValue = MphValue * 1.609344;
            return Math.Round(mphValue , 2);
        }
    }
}