using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WeatherTest.WebFrontEnd.Wind
{
    public class WindMph : IWind
    {
        public WindType Type
        {
            get
            {
                return WindType.MPH;
            }
        }

        public double Process(List<string> data)
        {
            double WindInMph = 0;
            foreach (string item in data)
            {

                Dictionary<string, string> resultData = JsonConvert.DeserializeObject<Dictionary<string, string>>(item);
                var temp = resultData.Where(d => d.Key.Contains("windSpeed")).FirstOrDefault();
                if (temp.Key.Contains("Kph"))
                {
                    var ConvertedValue = KphToMph(temp.Value[0]);
                    WindInMph += ConvertedValue;
                }
                else
                {
                    WindInMph += temp.Value[0];
                }
            }

            WindInMph = WindInMph / data.Count;
            return WindInMph;
        }

        public double KphToMph(double KphValue)
        {
            double mphValue = KphValue / 1.609344;
            return Math.Round( mphValue, 2);
        }
    }
}