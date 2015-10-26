using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.IRepositoryUOW
{
    public interface IUnitOfWork
    {
        void RegisterUpdated(IAggregateRoot entity,
                             IUnitOfWorkRepository unitofWorkRepository);
        void RegisterAdded(IAggregateRoot entity,
                         IUnitOfWorkRepository unitofWorkRepository);
        void RegisterDeleted(IAggregateRoot entity,
                             IUnitOfWorkRepository unitofWorkRepository);

        IRepository<T> Repository<T>() where T :  IAggregateRoot, IObjectState;

        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();

        bool IsCommitted { get; }
 
    }
}
