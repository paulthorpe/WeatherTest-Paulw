using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherTest.WebFrontEnd.Temperature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.WebFrontEnd.Temperature.Tests
{
    [TestClass()]
    public class TemperatureCelsiusTests
    {
        [TestMethod()]
        public void FahrenheitToCelsiusTest()
        {
            TemperatureCelsius classUndertest = new TemperatureCelsius();
            double FahValue = 50.0;
            double expected = Math.Round(10.00, 2);
            double calculated = classUndertest.FahrenheitToCelsius(FahValue);

            Assert.AreEqual(expected, calculated);
        }
    }
}