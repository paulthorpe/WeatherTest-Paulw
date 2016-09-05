
using WeatherTest.WebFrontEnd.Models;
using WeatherTest.WebFrontEnd.utils;

namespace WeatherTest.WebFrontEnd.WeatherApis
{
    public interface IWeatherStrategy
    {
        string gatherData(string location, IProcessApi requestData, IConfig config);
    }
}
