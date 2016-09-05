# Weather Test Paul Wyatt

This application is a web based system that allows users to view weather data for specific locations on a map. The weather data is an aggreation of numerous Weather feeds. Hoover over one of the Icons and witi to see the weather contitions for the location. You an also select the links to change to different locations

### Adding Apis

There are currently two Apis that can be called the process to add new Apis is as follows, this follows the Strategy pattern

* Create a new class that implements the interface IWeatherStrategy (placed in the WeatherStructures folder)  
* The gatherData implementation can call the its API directly or make use of the ProcessApi class if it is a Web based APIs
* Within the  WeatherController Get method add an instance of the new Class to the WeatherApis List

### Adding new units

Currently Wind and temperature have two units of mesaurements the following steps can be followed to add new units, this follows the factory pattern

* Add a new type in either the WindType or TempType Enums
* Create a concreate class implementing IWind or ITemp
* Add a clause to the factory methods to create the correct new instance
* Add any frontend changes to send the correcdt data to the WebAPI 

### Refactorings
* Improve the startup of the AutoFac DI framework So it can be used across more classes with the need for startup code
* Make use of either reflection or a Dependacy injection framework AutoFac to load API classes dynamically with the need to alter the WeatherController methods 
* Further Unit test to be added to increase code coverage 
* Abstract both HttpWebRequest and WebResponse to allow for Unit testing of ProcessApi.request(string) including a test for exceptions thrown 
* Use AngualarJS on the front End to make a real single page application
* PreLoad the Apis calls so the first action is not slow. (this is the .Net framwork starting up). 
* Remove LogLoader for logging and use System.Diagnostics for simpler logging configuration 
