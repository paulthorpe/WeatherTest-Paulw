using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTest.WebFrontEnd.Models;
using WeatherTest.WebFrontEnd.utils;

namespace WeatherTest.WebFrontEnd.Temperature
{
    public interface ITemperature
    {
        TempType Type { get; }
        double Process(List<string> data);
    }
}
