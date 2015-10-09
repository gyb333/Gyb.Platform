using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gyb.FrameWork.Configuration
{
    /// <summary>
    /// 把应用程序配置设置抽象成一个组件
    /// </summary>
    public class ApplicationSettingsFactory
    {
        private static IApplicationSettings _applicationSettings;

        public static void InitializeApplicationSettingsFactory(
                                      IApplicationSettings applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        public static IApplicationSettings GetApplicationSettings()
        {
            return _applicationSettings;
        }
    }
}
