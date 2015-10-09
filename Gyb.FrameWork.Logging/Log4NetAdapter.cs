using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;
using log4net.Config;

namespace Gyb.FrameWork.Logging
{
    public class Log4NetAdapter : ILogger
    {
        private readonly log4net.ILog _log;
        private readonly string strLogName = "Gyb.FrameWork.Logging";

        public Log4NetAdapter()
        {
            XmlConfigurator.Configure();
            _log = LogManager.GetLogger(strLogName);
        }

        public void Log(string message)
        {
            _log.Info(message);
        }
    }

}
