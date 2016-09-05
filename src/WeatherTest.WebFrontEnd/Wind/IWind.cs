using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherTest.WebFrontEnd.utils;

namespace WeatherTest.WebFrontEnd.Wind
{
    public interface IWind
    {
        WindType Type { get; }
        double Process(List<string> data);
    }
}