using HotelsServices.Model;

namespace HotelsServices.Logging
{
    interface ILogging
    {
        void ProcessLogMessage(LogInfo logInfo);
    }
}