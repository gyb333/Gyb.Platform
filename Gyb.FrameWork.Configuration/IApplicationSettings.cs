using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gyb.FrameWork.Configuration
{
    /// <summary>
    /// 获取页面上显示的商品数目
    /// </summary>
    public interface IApplicationSettings
    {
        string LoggerName { get; }              //日志文件名称
        string ServiceUri { get; }              //WebAPI地址
        

    }
}
