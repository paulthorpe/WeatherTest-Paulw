using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherTest.LogLoader.DataTypes
{
    public interface IStrorageStrategy
    {
        /// <summary>
        /// Interface method that must be implemenated in concreate classes
        /// </summary>
        /// <param name="data">The data to log as Log Class</param>
        /// <remarks></remarks>
        void LogData(Log data);
    }
}
