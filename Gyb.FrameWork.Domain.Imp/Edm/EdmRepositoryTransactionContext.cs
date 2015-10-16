using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    internal class EdmRepositoryTransactionContext : IRepositoryTransactionContext
    {
        private ObjectContext objContext;
        private Dictionary<Type, object> repositoryCache = new Dictionary<Type, object>();

        public EdmRepositoryTransactionContext(ObjectContext objContext)
        {
            this.objContext = objContext;
        }


        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : EntityObject, IAggregateRoot
        {
            if (repositoryCache.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)repositoryCache[typeof(TEntity)];
            }
            IRepository<TEntity> repository = new EdmRepository<TEntity>(this.objContext);
            this.repositoryCache.Add(typeof(TEntity), repository);
            return repository;
        }
        public void BeginTransaction()
        {
            // We do not need to begin a transaction here because the object context,
            // which would handle the transaction, was created and injected into the
            // constructor by Castle Windsor framework.
        }
        public void Commit()
        {
            this.objContext.SaveChanges();
        }
        public void Rollback()
        {
            // We also do not need to perform the rollback operation because
            // entity framework will handle this for us, just when the execution
            // point is stepping out of the using scope.
        }


        public void Dispose()
        {
            this.repositoryCache.Clear();
            this.objContext.Dispose();
        }


        IRepository<TEntity> IRepositoryTransactionContext.GetRepository<TEntity>()
        {
            throw new NotImplementedException();
        }

        void IRepositoryTransactionContext.BeginTransaction()
        {
            throw new NotImplementedException();
        }

        void IRepositoryTransactionContext.Commit()
        {
            throw new NotImplementedException();
        }

        void IRepositoryTransactionContext.Rollback()
        {
            throw new NotImplementedException();
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    } 
}
