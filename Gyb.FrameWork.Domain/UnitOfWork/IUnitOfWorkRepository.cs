using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain.UnitOfWork
{ 
    /// <summary>
    /// 能够跟踪多个领域实体聚合的变化并在一个原子操作中完成持久化，确保有效的业务领域
    /// </summary>
    public interface IUnitOfWorkRepository
    {
        void PersistAdded(IAggregateRoot entity);
        void PersistUpdated(IAggregateRoot entity);
        void PersistDeleted(IAggregateRoot entity);
    }
}
