# Weather Test Paul Wyatt

This application is a web based system that allows users toview weather data for specific locations on a map. The weather data is an aggreation of numerous
Weather feeds.

### Adding Apis

There are currently two Apis that can be called the process to add new Apis is as follows, this follows the Strategy pattern
* Create a new class that implements the interface IWeatherStrategy (placed in the WeatherStructures folder)  
* The gatherData implementation can call the its API directly or make use of the ProcessApi class if it is a Web based APIs
* Within the  WeatherController Get method add an instance of the new Class to the WeatherApis List

# Refacting of Adding Apis

The folloiwng are steps that should be carried out to simply the process of adding APIs
* Make use of either reflection or a Dependacy injection framework to load APi class dymaiclaly with the need to alter the WeatherController methods

### Adding new units

Currently Wind and temperature have two units of mesaurements the following steps can be followed to add new units, this follows the factory pattern
* Add a new type in either the WindType or TempType Enums
* Create a concreate class implementing IWind or ITemp
* Add a clause to the factory methods to create the correct new instance
* Add any frontend changes to send the correcdt data to the WebAPI 

# Refacting of Adding new units
The following change would simplify the prcoess of adding new units
* Within the factory method create the correct instances using reflection and configuration values. 

### Futher Refactorings
* Make use of a dependacy injection framework to manage Configurations and other dependancies
* Further Unit test to be added to increase code coverage 
* Use AngualarJS on the front End to make a real single page application
* Abstract both HttpWebRequest and WebResponse to allow for Unit testing of ProcessApi.request(string) including a test for exceptions thrown 
