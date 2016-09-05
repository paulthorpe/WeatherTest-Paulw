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
    public class TemperatureFahrenheitTests
    {
        [TestMethod()]
        public void CelsiusToFahrenheitTest()
        {
            TemperatureFahrenheit classUndertest = new TemperatureFahrenheit();
            double CelValue = 10.0;
            double expected = Math.Round(50.00, 2);
            double calculated = classUndertest.CelsiusToFahrenheit(CelValue);

            Assert.AreEqual(expected, calculated);
        }
    }
}