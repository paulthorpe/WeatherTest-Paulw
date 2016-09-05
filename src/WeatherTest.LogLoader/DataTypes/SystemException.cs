using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.LogLoader.DataTypes
{
    public sealed class SystemException : Log
    {
        public SystemException(string message, StackTrace stack, string username, string msgEx) : base(message)
        {
            this.LogType = ApplicationLogTypes.SystemExceptionLog;
            this.PreservedStackTrace = stack;
            this.LogUserName = username;
            this.LogMessageEX = msgEx;
            this.Save();
        }

        public SystemException(string message,string CustomLogType, StackTrace stack,string username, string msgEx) : base(message)
        {
            this.LogType = CustomLogType;
            this.PreservedStackTrace = stack;
            this.LogUserName = username;
            this.LogMessageEX = msgEx;
            this.Save();
        }
    }
}
