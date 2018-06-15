using System;

namespace Evolent.WebAPI.App_Start
{
    public interface ILogAdapter
    {
        void WriteMessage(string source, WebAPI.Logging.NLogAdapter.LogLevel level, Exception ex);
        void WriteMessage(string source, WebAPI.Logging.NLogAdapter.LogLevel level, string message);
    }
}
