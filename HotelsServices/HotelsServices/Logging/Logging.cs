using Cassandra;
using System;
using HotelsServices.Model;

namespace HotelsServices.Logging
{
    public class Logging : ILogging
    {
        Cluster cluster;
        ISession session;

        private static Logging _Instance = null;
        public static Logging Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new Logging();
                return _Instance;
            }
        }

        private Logging()
        {
            cluster = Cluster.Builder().AddContactPoint("127.0.0.1").Build();
            session = cluster.Connect("hotel_log");
        }

        public void ProcessLogMessage(LogInfo logInfo)
        {
            try
            {
                var insertquery = session.Prepare("insert into log_message (request, response, exception, comment, date_time) VALUES ( ?, ?, ?, ?, ?)");
                var batch = new BatchStatement().Add(insertquery.Bind(logInfo.Request, logInfo.Response, logInfo.Exception, logInfo.Comment, logInfo.DateTime));
                session.Execute(batch);
            } 
            catch(Exception ex)
            {
                throw new Exception("Internal Server Error");
            }
        }
    }
}