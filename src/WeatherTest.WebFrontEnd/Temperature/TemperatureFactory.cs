
using WeatherTest.WebFrontEnd.utils;

namespace WeatherTest.WebFrontEnd.Temperature
{
    public class TemperatureFactory : ITemperatureFactory
    {
        public ITemperature CreateTemperature(TempType type)
        {
            if (type == TempType.CEL)
            {
                return new TemperatureCelsius();
            }
            else
            {
                return new TemperatureFahrenheit();
            }
        }
    }
}