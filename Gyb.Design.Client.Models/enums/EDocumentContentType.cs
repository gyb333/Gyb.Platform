using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Client.Models
{
    public enum EDocumentContentType
    {
        /// <summary>
        /// 起始页
        /// </summary>
        StartPage = 0,

        /// <summary>
        /// 实体设计器
        /// </summary>
        EntityDesigner = 1,

        /// <summary>
        /// 界面设计器
        /// </summary>
        UIDesigner = 2,

        /// <summary>
        /// 工作流设计器
        /// </summary>
        WorkflowDesigner = 3
    }
}
