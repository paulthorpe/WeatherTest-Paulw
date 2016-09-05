using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherTest.WebFrontEnd.Wind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.WebFrontEnd.Wind.Tests
{
    [TestClass()]
    public class WindMphTests
    {
        [TestMethod()]
        public void KphToMphTest()
        {
            WindMph classUndertest = new WindMph();
            double KPHValue = 10.0;
            double expected = Math.Round(6.21371,2);
            double calculated = classUndertest.KphToMph(KPHValue);
        
            Assert.AreEqual(expected, calculated);
        }
    }
}