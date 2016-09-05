using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherTest.WebFrontEnd.utils;

namespace WeatherTest.WebFrontEnd.Wind
{
    public class WindFactory : IWindFactory
    {
        public IWind CreateWind(WindType type)
        {
            if (type == WindType.KPH)
            {
                return new WindKph();
            }
            else
            {
                return new WindMph();
            }
        }
        
    }
}