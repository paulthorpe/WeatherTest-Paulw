using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Web.Http;
using WeatherTest.WebFrontEnd.utils;
using WeatherTest.WebFrontEnd.WeatherApis;
using WeatherTest.WebFrontEnd.Temperature;
using WeatherTest.WebFrontEnd.Wind;
using WeatherTest.LogLoader.DataTypes;
using Autofac;

namespace WeatherTest.WebFrontEnd.Controllers
{
    public class WeatherController : ApiController
    {
        public string Get(string id,string temp,string wind)
        {
            new ApplicationAction("Starting Weather Api Calls","user", "WeatherTest for " + id).Save();

            new ApplicationAction("Using AutoFac", "user", "DI using a Framework").Save();

            //Dependency Injection with framework Autofac
            var builder = new ContainerBuilder();
            builder.RegisterType<ProcessApi>().As<IProcessApi>();
            builder.RegisterType<Config>().As<IConfig>();
            IContainer Container = builder.Build();


            TempType UserSelectTemp = (TempType) Enum.Parse(typeof(TempType),temp.ToUpper());
            WindType UserSelectWind = (WindType)Enum.Parse(typeof(WindType), wind.ToUpper());

           
            //List of Apis to call all based on the Strategy pattern
            var WeatherApis = new List<IWeatherStrategy>();

            // add new API which would have been created - TODO make this a dynaimc process so this file does not need to be edited
            WeatherApis.Add(new WeatherDataCollectorBbc());
            WeatherApis.Add(new WeatherDataCollectorAccu());

            new ApplicationAction("Added Apis", "user", "Two Apis").Save();

            //List to hold API call data
            var LocationDataSets = new List<string>();

            using (var scope = Container.BeginLifetimeScope())
            {
                foreach (IWeatherStrategy api in WeatherApis)
                {
                    // call each of the APIs and store the result
                    LocationDataSets.Add(api.gatherData(id, scope.Resolve<IProcessApi>(), scope.Resolve<IConfig>()));
                }
            }

            new ApplicationAction("Creating objects", "user", "Using factory pattern").Save();

            ITemperatureFactory tempFactory = new TemperatureFactory();
            ITemperature selectedTemp = tempFactory.CreateTemperature(UserSelectTemp);

            IWindFactory windFactory = new WindFactory();
            IWind selectedWind = windFactory.CreateWind(UserSelectWind);

            new ApplicationAction("Calcuating results", "user", "Aggregated result data").Save();

            //call the aggregator to work out the results
            var calculatedLocationWeather = new Aggregator(selectedTemp, selectedWind).AggregateData(LocationDataSets);
            calculatedLocationWeather.Location = id;

            new ApplicationAction("Completed prcoessing", "user", "TReturn data to client").Save();
            //return to client final result
            return JsonConvert.SerializeObject(calculatedLocationWeather);
        }
    }
}
