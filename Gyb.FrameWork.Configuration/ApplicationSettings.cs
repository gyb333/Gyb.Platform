using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Gyb.FrameWork.Configuration
{
    public class ApplicationSettings : IApplicationSettings
    {
        public string LoggerName
        {
            get { return ConfigurationManager.AppSettings["LoggerName"]; }
        }





        public string ServiceUri
        {
            get { return ConfigurationManager.AppSettings["ServiceUri"]; }
        }
    }

}
