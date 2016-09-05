using System;
using System.IO;
using System.Net;
using System.Text;
using WeatherTest.LogLoader.DataTypes;

namespace WeatherTest.WebFrontEnd.utils
{
    public class ProcessApi : IProcessApi
    {
        //Call the api URL and return the result as a string ( JSON )
        public string request(string uri)
        {

            new ApplicationAction("Calling Api", "user", uri).Save();

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            try
            {
                WebResponse response = request.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                WebResponse errorResponse = ex.Response;
                using (Stream responseStream = errorResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                    string errorText = reader.ReadToEnd();

                    new LogLoader.DataTypes.ApplicationException("Error making call","user","The error is " + errorText);
                }
            }

            return "";
        }
    }
}