using NHibernate;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    internal class NHibernateRepositoryTransactionContext : IRepositoryTransactionContext
    {
        ITransaction transaction;

        Dictionary<Type, object> repositoryCache = new Dictionary<Type, object>();
        public ISession Session { get { return DatabaseSessionFactory.Instance.Session; } }

        #region IRepositoryTransactionContext Members
        public IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : EntityObject, IAggregateRoot
        {
            if (repositoryCache.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)repositoryCache[typeof(TEntity)];
            }
            IRepository<TEntity> repository = new NHibernateRepository<TEntity>(this.Session);
            this.repositoryCache.Add(typeof(TEntity), repository);
            return repository;
        }
        public void BeginTransaction()
        {
            transaction = DatabaseSessionFactory.Instance.Session.BeginTransaction();
        }
        public void Commit()
        {
            transaction.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }
        #endregion
        #region IDisposable Members
        public void Dispose()
        {
            transaction.Dispose();
            ISession dbSession = DatabaseSessionFactory.Instance.Session;
            if (dbSession != null && dbSession.IsOpen)
                dbSession.Close();
        }
        #endregion
    } 
}
