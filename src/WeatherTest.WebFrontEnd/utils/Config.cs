using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WeatherTest.WebFrontEnd.utils
{
    public class Config : IConfig
    {
        public string getAccuUri()
        {
           return ConfigurationManager.AppSettings["ApiAccu"].ToString();
        }

        public string getBbcUri()
        {
            return ConfigurationManager.AppSettings["ApiBbc"].ToString();
        }
    }
}