using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Gyb.FrameWork.Logging
{
    public class LoggingFactory
    {
        private static ILogger _logger;

        public static void InitializeLogFactory(ILogger logger)
        {
            _logger = logger;
        }

        public static ILogger GetLogger()
        {
            if (_logger == null)
            {
                _logger = new Log4NetAdapter();
            }
            return _logger;
        }
    }
}
