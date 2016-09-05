using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.LogLoader.DataTypes
{
    public sealed class ApplicationException : Log
    {
        public ApplicationException(string message , string username , string msgEx ) : base(message)
        {
            this.LogType = ApplicationLogTypes.ApplicationActionLog;
            this.LogUserName = username;
            this.LogMessageEX = msgEx;
            this.Save();
        }

        public ApplicationException(string message, string CustomLogType , string username , string msgEx ) : base(message)
        {
            this.LogType = CustomLogType;
            this.LogUserName = username;
            this.LogMessageEX = msgEx;
            this.Save();
        }
    }
}
