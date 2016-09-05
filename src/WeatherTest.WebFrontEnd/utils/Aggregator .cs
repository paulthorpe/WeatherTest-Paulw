using System.Collections.Generic;
using WeatherTest.WebFrontEnd.Models;
using WeatherTest.WebFrontEnd.Temperature;
using WeatherTest.WebFrontEnd.Wind;

namespace WeatherTest.WebFrontEnd.utils
{
    public class Aggregator
    {
        private ITemperature tempHandler;
        private IWind windHandler;

        public Aggregator(ITemperature temp, IWind wind)
        {
            tempHandler = temp;
            windHandler = wind;
        }

        public LocationData AggregateData(List<string> data)
        {
            LocationData locationDataAverages = new LocationData();

            double wind = AverageWind(data);
            double temp = AverageTemp(data);
            
            locationDataAverages.temperature = temp;
           
            locationDataAverages.windSpeed = wind;

            return locationDataAverages;
        }
        
        private double AverageTemp(List<string> data)
        {
            double temp = tempHandler.Process(data);
            return temp;
        }

        private double AverageWind(List<string> data)
        {
            double windSpeed = windHandler.Process(data);
            return windSpeed;
        }
    }
}