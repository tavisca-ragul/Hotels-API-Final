using System;

namespace HotelsServices.Model
{
    public class LogInfo
    {
        public LogInfo(string request, string response, string exception, string comment, DateTime dateTime)
        {
            Request = request;
            Response = response;
            Exception = exception;
            Comment = comment;
            DateTime = dateTime;
        }

        public string Request { get; }
        public string Response { get; }
        public string Exception { get; }
        public string Comment { get; }
        public DateTime DateTime { get; }
    }
}