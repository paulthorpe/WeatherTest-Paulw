using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using WeatherTest.LogLoader.DataTypes;

namespace WeatherTest.LogLoader.Utils
{
    /// <summary>
    /// Is called by a client that requires a log implmenetation to be loaded dynamically 
    /// Class is shared (static)
    /// </summary>
    /// <remarks>Factory Pattern used to contain the code making suitable for unit testing</remarks>
    public static class LogClassFactory
    {
        /// <summary>
        /// static object which is the loaded library to use
        /// </summary>
        /// <remarks></remarks>
        private static IStrorageStrategy _StoreStragtegy = null;

        /// <summary>
        /// Creates the required log class based on the IStrorageStrategy interface
        /// </summary>
        /// <returns>a class of type IStrorageStrategy</returns>
        /// <remarks>factory pattern method the default returned value in the event of an error is a filestore</remarks>
        public static IStrorageStrategy CreateLogImplementation(string StoreNamespace, string StoreType)
        {
            //only reflect if required improved perfmoance for performance
            if (_StoreStragtegy == null)
            {
                // generate dynamic object based on configured value using reflection
                Type StorageTypeClass = null;

                // get a handle to the current .net assmbley i could load any assmebly for isolation reasons all storage code 
                // could be in a single dll rather than in the main dll
                Module[] RunningAssembly = Assembly.GetExecutingAssembly().GetModules(false);

                //I know there is only one assmbley for this app some extra code will be required if not
                Module myModule = RunningAssembly[0];

                //If the config is asking to load up a non default DLL we need 
                // to get it in to the running assmbley App Domain should use the loaded dll name rather than a string
                if(StoreNamespace != "LogLoader")
                {
                    Assembly LoadedAssembly = Assembly.Load(StoreNamespace); // this will try to find the class

                    //bind to the require class in the loaded DLL file based on config values
                    StorageTypeClass = LoadedAssembly.GetType(StoreNamespace + ".DataStores." + StoreType, false, false);
                }
                else
                {
                    //default only need is to lod the required class in the bas LogLoader running DLL
                    //get the reflected type class based on the provided configured string
                    StorageTypeClass = myModule.GetType(StoreNamespace + "." + StoreType, false, false);
                }
                
                //null is thrown back if type not found so check for it other wise fallback to default
                if (StorageTypeClass != null)
                {
                    //the configured storage
                    _StoreStragtegy = Activator.CreateInstance(StorageTypeClass) as IStrorageStrategy;
                }
                else
                {
                    //the default setup based on LoagLoader not a custom DLL file
                    Type DefaultStorageTypeClass = myModule.GetType("LogLoader.FileStore", false, false);
                    _StoreStragtegy = Activator.CreateInstance(DefaultStorageTypeClass) as IStrorageStrategy;
                }
                
            }

            return _StoreStragtegy;
        }
        
    }
}
