using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    public interface IRepositoryTransactionContext : IDisposable
    {
        //IRepository<TEntity> GetRepository<TEntity>()
        //    where TEntity : IAggregateRoot;
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
