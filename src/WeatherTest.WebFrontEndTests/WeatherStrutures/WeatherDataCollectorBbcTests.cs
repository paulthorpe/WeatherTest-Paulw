using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherTest.WebFrontEnd.WeatherStrutures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherTest.WebFrontEnd.utils;
using Moq;
using WeatherTest.WebFrontEnd.WeatherApis;

namespace WeatherTest.WebFrontEnd.WeatherStrutures.Tests
{

    public class TestDataC    {
        public double TemperatureCelsius { get; set; }
        public string where { get; set; }
        public double WindSpeedKph { get; set; }
    }

    [TestClass()]
    public class WeatherDataCollectorBbcTests
    {
        private TestDataC inputData = null;

        [TestInitialize()]
        public void Initialize()
        {
            //test setup method not really need but shows the use of the TestInitialize attribute
            inputData = new TestDataC();
            inputData.where = "mylocation";
        }

        [TestMethod()]
        public void WeatherDataCollectorBbc_gatherData_TestForMarkedTemp_ReplaceValue()
        {
            inputData.TemperatureCelsius = 10.0;
            inputData.WindSpeedKph = 10.0;

            double RequiredValue = 15.0;
            
            Mock<IProcessApi> mockApi = new Mock<IProcessApi>();
            mockApi.Setup(m => m.request("Bbcuri")).Returns(JsonConvert.SerializeObject(inputData));

            Mock<IConfig> mockConf = new Mock<IConfig>();
            mockConf.Setup(m => m.getAccuUri()).Returns("Accu");
            mockConf.Setup(m => m.getBbcUri()).Returns("Bbc");

            WeatherDataCollectorBbc accu = new WeatherDataCollectorBbc();
            string result = accu.gatherData("uri", mockApi.Object, mockConf.Object);
            Dictionary<string, string> checkData = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            var temp = checkData.Where(d => d.Key.Contains("TemperatureCelsius")).FirstOrDefault();
            double CelsiusValue = Convert.ToDouble(temp.Value);

            Assert.AreEqual(RequiredValue, CelsiusValue);
        }

        [TestMethod()]
        public void WeatherDataCollectorBbc_gatherData_TestForMarkedTemp_OriginalValue()
        {
            inputData.TemperatureCelsius = 20.0;
            inputData.WindSpeedKph= 10.0;

            double RequiredValue = 20.0;

            Mock<IProcessApi> mockApi = new Mock<IProcessApi>();
            mockApi.Setup(m => m.request("Bbcuri")).Returns(JsonConvert.SerializeObject(inputData));

            Mock<IConfig> mockConf = new Mock<IConfig>();
            mockConf.Setup(m => m.getAccuUri()).Returns("Accu");
            mockConf.Setup(m => m.getBbcUri()).Returns("Bbc");

            WeatherDataCollectorBbc accu = new WeatherDataCollectorBbc();
            string result = accu.gatherData("uri", mockApi.Object, mockConf.Object);
            Dictionary<string, string> checkData = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            var temp = checkData.Where(d => d.Key.Contains("TemperatureCelsius")).FirstOrDefault();
            double CelsiusValue = Convert.ToDouble(temp.Value);

            Assert.AreEqual(RequiredValue, CelsiusValue);
        }

        [TestMethod()]
        public void WeatherDataCollectorBbc_gatherData_TestForMarkedWind_ReplaceValue()
        {
            inputData.TemperatureCelsius = 10.0;
            inputData.WindSpeedKph = 8.0;

            double RequiredValue = 12.0;

            Mock<IProcessApi> mockApi = new Mock<IProcessApi>();
            mockApi.Setup(m => m.request("Bbcuri")).Returns(JsonConvert.SerializeObject(inputData));

            Mock<IConfig> mockConf = new Mock<IConfig>();
            mockConf.Setup(m => m.getAccuUri()).Returns("Accu");
            mockConf.Setup(m => m.getBbcUri()).Returns("Bbc");

            WeatherDataCollectorBbc accu = new WeatherDataCollectorBbc();
            string result = accu.gatherData("uri", mockApi.Object, mockConf.Object);
            Dictionary<string, string> checkData = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            var temp = checkData.Where(d => d.Key.Contains("WindSpeedKph")).FirstOrDefault();
            double KphValue = Convert.ToDouble(temp.Value);

            Assert.AreEqual(RequiredValue, KphValue);
        }

        [TestMethod()]
        public void WeatherDataCollectorBbc_gatherData_TestForMarkedWind_OriginalValue()
        {
            inputData.TemperatureCelsius = 10.0;
            inputData.WindSpeedKph = 10.0;

            double RequiredValue = 10.0;

            Mock<IProcessApi> mockApi = new Mock<IProcessApi>();
            mockApi.Setup(m => m.request("Bbcuri")).Returns(JsonConvert.SerializeObject(inputData));

            Mock<IConfig> mockConf = new Mock<IConfig>();
            mockConf.Setup(m => m.getAccuUri()).Returns("Accu");
            mockConf.Setup(m => m.getBbcUri()).Returns("Bbc");

            WeatherDataCollectorBbc accu = new WeatherDataCollectorBbc();
            string result = accu.gatherData("uri", mockApi.Object, mockConf.Object);
            Dictionary<string, string> checkData = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            var temp = checkData.Where(d => d.Key.Contains("WindSpeedKph")).FirstOrDefault();
            double KphValue = Convert.ToDouble(temp.Value);

            Assert.AreEqual(RequiredValue, KphValue);
        }
    }
}