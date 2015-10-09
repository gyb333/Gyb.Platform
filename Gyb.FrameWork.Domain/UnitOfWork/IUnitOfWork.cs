using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        void RegisterUpdated(IAggregateRoot entity,
                             IUnitOfWorkRepository unitofWorkRepository);
        void RegisterAdded(IAggregateRoot entity,
                         IUnitOfWorkRepository unitofWorkRepository);
        void RegisterDeleted(IAggregateRoot entity,
                             IUnitOfWorkRepository unitofWorkRepository);

        IRepository<T> Repository<T>() where T :  IAggregateRoot;

 
        bool IsCommitted { get; }

        void Commit();
 
         void Rollback();
    }
}
