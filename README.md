# Weather Test Paul Wyatt

This application is a web based system that allows users to view weather data for specific locations on a map. The weather data is an aggregation of numerous Weather feeds. Hover over one of the Icons and wait to see the weather conditions for the location. You an also select the links to change to different locations

### Adding Apis

There are currently two Apis that can be called the process to add new Apis is as follows, this follows the Strategy pattern

* Create a new class that implements the interface IWeatherStrategy (placed in the WeatherStructures folder)  
* The gatherData implementation can call the its API directly or make use of the ProcessApi class if it is a Web based APIs
* Within the  WeatherController Get method add an instance of the new Class to the WeatherApis List

### Adding new units

Currently Wind and temperature have two units of measurement the following steps can be followed to add new units, this follows the factory pattern

* Add a new type in either the WindType or TempType Enums
* Create a concrete class implementing IWind or ITemp
* Add a clause to the factory methods to create the correct new instance
* Add any frontend changes to send the correcdt data to the WebAPI 

### Refactoring
* Improve the start-up of the AutoFac DI framework So it can be used across more classes with the need for start-up code
* Make use of either reflection or a Dependency injection framework AutoFac to load API classes dynamically with the need to alter the WeatherController methods 
* Further Unit test to be added to increase code coverage 
* Abstract both HttpWebRequest and WebResponse to allow for Unit testing of ProcessApi.request(string) including a test for exceptions thrown 
* Use AngularJS on the front End to make a real single page application
* PreLoad the Apis calls so the first action is not slow. (this is the .Net framework starting up). 
* Remove LogLoader for logging and use System.Diagnostics for simpler logging configuration
