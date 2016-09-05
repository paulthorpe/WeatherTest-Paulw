using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherTest.LogLoader.DataTypes;

namespace WeatherTest.LogLoader.DataStores
{
    public sealed class FileStore : IStrorageStrategy
    {
        private string _FileName; 
        private string  _LogFilePath = @"c:\"; 
        private string _FilePrefix = "LogData-"; 

        public FileStore()
        {
            var LogFilePath = ConfigurationManager.AppSettings["FileStorePath"];
            if (LogFilePath != null) {
                if (LogFilePath.Length > 0) {
                    _LogFilePath = LogFilePath;
                }
            }

            if (!_LogFilePath.EndsWith("\\")) {
                _LogFilePath+="\\";
            }

            var FilePrefix = ConfigurationManager.AppSettings["FileNamePrefix"];
            if (FilePrefix != null) {
                if (FilePrefix.Length > 0) {
                    _FilePrefix = FilePrefix;
                }
            }

            _FileName = _LogFilePath + "LogFile-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year + ".txt";
        }

        public void LogData(Log data )
        {
            string LogData;
           
            Log AppData = data as Log;
            LogData = DateTime.Now + " : " + AppData.GetType().ToString() + " " + AppData.Message + " " + AppData.LogMessageEX;

            if (AppData.PreservedStackTrace != null) {
                LogData = LogData + " : " + AppData.PreservedStackTrace.ToString();
            }

            File.AppendAllText(_FileName, LogData + Environment.NewLine);
        }
        
    }
}
