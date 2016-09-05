using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTest.WebFrontEnd.utils;

namespace WeatherTest.WebFrontEnd.Wind
{
    public interface IWindFactory
    {
        IWind CreateWind(WindType type);
    }
    
}
