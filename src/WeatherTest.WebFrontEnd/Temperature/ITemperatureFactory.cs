
using WeatherTest.WebFrontEnd.utils;

namespace WeatherTest.WebFrontEnd.Temperature
{
    public interface ITemperatureFactory
    {
        ITemperature CreateTemperature(TempType type);
    }
}
