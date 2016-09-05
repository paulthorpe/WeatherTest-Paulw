using System.Configuration;
using System.Diagnostics;
using System.IO;
using WeatherTest.LogLoader.Utils;

// <summary>
// Log is a custom exception that is used to define the log data the composite IStrorageStrategy is the strategy pattern used to 
// actually define what logging is carried out be it file based database or other
// 
// The constructor collects the StoreType or StoreNamespace if set in the client config if not the defualt are used
// The createStorageBuilder uses reflection to load up the correct class at runtime using (Dependancy Injection pattern)
// the default is the FileStore. This method can be overidden by client class if new logging features are required.
// 
// the Log method calls the Stategy pattern's real implemenation which logs the data to the correct location and then uses
// the Dispose pattern to clean up if the Stategy pattern's real implemenation if it is supported through IDisposable
// 
// </summary>
// <remarks></remarks>

namespace WeatherTest.LogLoader.DataTypes
{
    public abstract class Log : System.Exception
    {
        /// <summary>
        /// Strategy pattern interface based Class the conccreate class will implemenat this Interface
        /// </summary>
        /// <remarks></remarks>
        protected IStrorageStrategy _StoreStragtegy;

        /// <summary>
        /// LogDate Proprety
        /// </summary>
        /// <value>Value of the Log</value>
        /// <returns>Date</returns>
        public System.DateTime LogDate { get; set; }

        /// <summary>
        /// Logtype Proprety
        /// </summary>
        /// <value>Log Type enum value</value>
        /// <returns>LogType Enum</returns>
        public string LogType { get; set; }

        /// <summary>
        /// LogUsername Proprety which is the user who carried out the current activity
        /// </summary>
        /// <value>Log Username</value>
        /// <returns>LogUsername</returns>
        public string LogUserName { get; set; }

        /// <summary>
        /// Store type Proprety
        /// </summary>
        /// <value>What storage is being set</value>
        /// <returns>String</returns>
        public string StoreType { get; set; }

        private string _StoreNameSpace = "LogLoader";
        /// <summary>
        /// DLL namepsace of the concreate implementation of the IStrategy pattern 
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string StoreNameSpace
        {
            get
            {
                return _StoreNameSpace;
            }
            set
            {
                _StoreNameSpace = value;
            }
        }

        /// <summary>
        /// Stack trace to store
        /// </summary>
        /// <value>The stack trace to store</value>
        /// <returns>Stored stack trace</returns>
        public StackTrace PreservedStackTrace { get; set;}

        /// <summary>
        /// LogMessageEX Proprety is the optional extended message info, if supplied, if the stack trace is added 
        /// this is added to the stack trace information
        /// </summary>
        /// <value>Log ex message</value>
        /// <returns>Log ex messag</returns>
        public string LogMessageEX { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="message">Message of the Log</param>
        /// <remarks>The message is staored as part of the exception parent class</remarks>
        public Log(string message, string user = "", string exmsg = "") : base(message)
        {
            this.LogDate = System.DateTime.Now;
            this.LogUserName = user;
            this.LogMessageEX = exmsg;

            //get configured store type if set use it otherwise use the default
            string StoreTypeConfiguration = ConfigurationManager.AppSettings.Get("StoreType");
            if( StoreTypeConfiguration != null) {
                if(StoreTypeConfiguration.Length > 0)
                {
                    this.StoreType = StoreTypeConfiguration;
                }
            }

            //get the confiured dll namespace or use the default DLL of LogLoader
            string StoreNamespace = ConfigurationManager.AppSettings.Get("StoreNamespace");
            if(StoreNamespace != null)
            {
                if(StoreNamespace.Length > 0)
                {
                    this.StoreNameSpace = StoreNamespace;
                }
            }

            //create the storage method based on config entries using reflection
            //call the factory pattern so that we can create the required log implementation
            _StoreStragtegy = LogClassFactory.CreateLogImplementation(this.StoreNameSpace, this.StoreType);
        }

        /// <summary>
        /// Log the data using the Strategy patterns implemenation and if IDisposable is supported calls the clean up code 
        /// </summary>
        public void Save() {
            if (_StoreStragtegy != null)
            {
                _StoreStragtegy.LogData(this);

                if(_StoreStragtegy is System.IDisposable){
                    //late binding of the disposable pattern
                    System.IDisposable Disposable = _StoreStragtegy as System.IDisposable;
                    Disposable.Dispose();
                }
            }
        }
    }
}