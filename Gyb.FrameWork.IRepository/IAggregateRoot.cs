using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.IRepositoryUOW
{
    /// <summary>
    /// 用于识别充当聚合根的领域实体
    /// </summary>
    public interface IAggregateRoot:IEntity
    {
    }
}
