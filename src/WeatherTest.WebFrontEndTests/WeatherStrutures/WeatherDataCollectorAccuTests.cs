using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WeatherTest.WebFrontEnd.utils;
using System.Collections.Generic;
using System.Linq;
using System;
using Newtonsoft.Json;
using WeatherTest.WebFrontEnd.WeatherApis;

namespace WeatherTest.WebFrontEnd.WeatherStrutures.Tests
{
    public class TestDataF
    {
        public double TemperatureFahrenheit { get; set; }
        public string where { get; set; }
        public double windSpeedMph { get; set; }
    }

    [TestClass()]
    public class WeatherDataCollectorAccuTests
    {
        private TestDataF inputData = null;

        [TestInitialize()]
        public void Initialize()
        {
            //test setup method not really need but shows the use of the TestInitialize attribute
            inputData = new TestDataF();
            inputData.where = "mylocation";
        }

        [TestMethod()]
        public void WeatherDataCollectorAccu_gatherData_TestForMarkedTemp_ReplaceValue()
        {
            double RequiredValue = 59.0;
            
            inputData.TemperatureFahrenheit = 68.0;
            inputData.windSpeedMph = 19.0;
            
            Mock<IProcessApi> mockApi = new Mock<IProcessApi>();
            mockApi.Setup(m => m.request("Accuuri")).Returns(JsonConvert.SerializeObject(inputData));

            Mock<IConfig> mockConf = new Mock<IConfig>();
            mockConf.Setup(m => m.getAccuUri()).Returns("Accu");
            mockConf.Setup(m => m.getBbcUri()).Returns("Bbc");

            WeatherDataCollectorAccu accu = new WeatherDataCollectorAccu();
            string result = accu.gatherData("uri", mockApi.Object, mockConf.Object);
            Dictionary<string, string> checkData = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            var temp = checkData.Where(d => d.Key.Contains("TemperatureFahrenheit")).FirstOrDefault();
            double FahrenheitValue = Convert.ToDouble(temp.Value);

            Assert.AreEqual(RequiredValue, FahrenheitValue);
        }


        [TestMethod()]
        public void WeatherDataCollectorAccu_gatherData_TestForMarkedTemp_OrignalValue()
        {
            double RequiredValue = 70.0;
            
            inputData.TemperatureFahrenheit = 70.0;
            inputData.windSpeedMph = 19.0;

            Mock<IProcessApi> mockApi = new Mock<IProcessApi>();
            mockApi.Setup(m => m.request("Accuuri")).Returns(JsonConvert.SerializeObject(inputData));

            Mock<IConfig> mockConf = new Mock<IConfig>();
            mockConf.Setup(m => m.getAccuUri()).Returns("Accu");
            mockConf.Setup(m => m.getBbcUri()).Returns("Bbc");

            WeatherDataCollectorAccu accu = new WeatherDataCollectorAccu();
            string result = accu.gatherData("uri", mockApi.Object, mockConf.Object);
            Dictionary<string, string> checkData = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            var temp = checkData.Where(d => d.Key.Contains("TemperatureFahrenheit")).FirstOrDefault();
            double FahrenheitValue = Convert.ToDouble(temp.Value);

            Assert.AreEqual(RequiredValue, FahrenheitValue);
        }

        [TestMethod()]
        public void WeatherDataCollectorAccu_gatherData_TestForMarkedWind_ReplaceValue()
        {
            double RequiredValue = 7.5;
            
            inputData.TemperatureFahrenheit = 68.0;
            inputData.windSpeedMph = 10.0;

            Mock<IProcessApi> mockApi = new Mock<IProcessApi>();
            mockApi.Setup(m => m.request("Accuuri")).Returns(JsonConvert.SerializeObject(inputData));

            Mock<IConfig> mockConf = new Mock<IConfig>();
            mockConf.Setup(m => m.getAccuUri()).Returns("Accu");
            mockConf.Setup(m => m.getBbcUri()).Returns("Bbc");

            WeatherDataCollectorAccu accu = new WeatherDataCollectorAccu();
            string result = accu.gatherData("uri", mockApi.Object, mockConf.Object);
            Dictionary<string, string> checkData = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            var temp = checkData.Where(d => d.Key.Contains("windSpeedMph")).FirstOrDefault();
            double MphValue = Convert.ToDouble(temp.Value);

            Assert.AreEqual(RequiredValue, MphValue);
        }

        [TestMethod()]
        public void WeatherDataCollectorAccu_gatherData_TestForMarkedWind_OrignalValue()
        {
            double RequiredValue = 15.0;
            
            inputData.TemperatureFahrenheit = 68.0;
            inputData.windSpeedMph = 15.0;

            Mock<IProcessApi> mockApi = new Mock<IProcessApi>();
            mockApi.Setup(m => m.request("Accuuri")).Returns(JsonConvert.SerializeObject(inputData));

            Mock<IConfig> mockConf = new Mock<IConfig>();
            mockConf.Setup(m => m.getAccuUri()).Returns("Accu");
            mockConf.Setup(m => m.getBbcUri()).Returns("Bbc");

            WeatherDataCollectorAccu accu = new WeatherDataCollectorAccu();
            string result = accu.gatherData("uri", mockApi.Object, mockConf.Object);
            Dictionary<string, string> checkData = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            var temp = checkData.Where(d => d.Key.Contains("windSpeedMph")).FirstOrDefault();
            double MphValue = Convert.ToDouble(temp.Value);

            Assert.AreEqual(RequiredValue, MphValue);
        }
    }
}

