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
    public class WindKphTests
    {
        [TestMethod()]
        public void MphToKphTest()
        {
            WindKph classUndertest = new WindKph();
            double MPHValue = 10.0;
            double expected = Math.Round(16.0934, 2);
            double calculated = classUndertest.MphToKph(MPHValue);

            Assert.AreEqual(expected, calculated);
        }
    }
}