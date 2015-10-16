
using Gyb.FrameWork.Domain;
using Gyb.FrameWork.Domain.UnitOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Gyb.FrameWork.EF
{
    public class EFUnitWork : IUnitOfWork
    {
        private Hashtable _repositories;


        protected readonly DbContext _dbContext;
        private bool _disposed;

        public EFUnitWork(IDbContextFactory dbContextFactory)
        {
            _dbContext = dbContextFactory.GetDbContext();
            _repositories = new Hashtable();
        }




        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }





        public IRepository<T> Repository<T>() where T : IAggregateRoot
        {
            var typeName = typeof(T).Name;

            if (!this._repositories.ContainsKey(typeName))
            {

                var paramDict = new Dictionary<string, object>();
                paramDict.Add("context", this._dbContext);

                //Repository接口的实现统一在UnitOfWork中执行，通过Unity来实现IOC，同时把IDbContext的实现通过构造函数参数的方式传入
                //var repositoryInstance = UnityConfig.Resolve<IRepository<T>>(paramDict);

                //if (repositoryInstance != null)
                //    this._repositories.Add(typeName, repositoryInstance);
            }

            return (IRepository<T>)this._repositories[typeName];
        }

        public void Commit()
        {
            if (!IsCommitted)
            {
                if (_dbContext != null)
                {
                    if (_dbContext.GetValidationErrors().Any())
                    {
                        // TODO: move validation errors into domain level exception and then throw it instead of EF related one
                    }
                    try
                    {

                        using (var scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                        {
                            _dbContext.SaveChanges();
                            scope.Complete();
                            IsCommitted = true;
                        }
                    }
                    catch (DbUpdateConcurrencyException concurrencyException)
                    {
                        concurrencyException.Entries.Single().OriginalValues.SetValues(concurrencyException.Entries.Single().GetDatabaseValues());
                        //concurrencyException.Entries.Single().Reload();
                        throw;
                    }

                }
            }
        }

        public void RegisterUpdated(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            IsCommitted = false;
        }

        public void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            IsCommitted = false;
        }

        public void RegisterDeleted(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            IsCommitted = false;
        }

        /// <summary>
        /// 表示是否已经提交
        /// </summary>
        public bool IsCommitted
        {
            get;
            private set;
        }

        /// <summary>
        /// 回滚成未提交状态
        /// </summary>
        public void Rollback()
        {
            IsCommitted = false;
        }
    }
}
