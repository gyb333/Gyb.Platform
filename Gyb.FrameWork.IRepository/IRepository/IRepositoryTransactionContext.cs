using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.IRepositoryUOW
{
    public interface IRepositoryTransactionContext : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : IAggregateRoot, IObjectState;
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
