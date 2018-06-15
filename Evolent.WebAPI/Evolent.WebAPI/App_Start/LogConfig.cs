using Evolent.WebAPI.Logging;
using System;

namespace Evolent.WebAPI.App_Start
{
    public class LogConfig
    {
        private static ILogAdapter _logAdapter;
        private static object syncRoot = new Object();

        public static void Configure()
        {
            LoggerFactory.InitializeLogFactory(LoggerSource);
        }

        public static ILogAdapter LoggerSource
        {
            get
            {
                if (_logAdapter == null)
                {
                    lock (syncRoot)
                    {
                        if (_logAdapter == null)
                            _logAdapter = new NLogAdapter();
                    }
                }

                return _logAdapter;
            }
        }
    }
}