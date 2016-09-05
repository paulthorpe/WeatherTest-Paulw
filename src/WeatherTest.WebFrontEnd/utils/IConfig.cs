using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.WebFrontEnd.utils
{
    public interface IConfig
    {
        string getBbcUri();
        string getAccuUri();
    }
}
