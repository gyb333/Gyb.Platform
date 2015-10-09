
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Gyb.FrameWork.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> addedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> updatedEntities;
        private Dictionary<IAggregateRoot, IUnitOfWorkRepository> deletedEntities;

        private Hashtable _repositories;

        public UnitOfWork()
        {
            addedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            updatedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            deletedEntities = new Dictionary<IAggregateRoot, IUnitOfWorkRepository>();
            _repositories = new Hashtable();
        }



        public void RegisterUpdated(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!updatedEntities.ContainsKey(entity))
            {
                updatedEntities.Add(entity, unitofWorkRepository);
                IsCommitted = false;
            }
        }

        public void RegisterAdded(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!addedEntities.ContainsKey(entity))
            {
                addedEntities.Add(entity, unitofWorkRepository);
                IsCommitted = false;
            };
        }

        public void RegisterDeleted(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            if (!deletedEntities.ContainsKey(entity))
            {
                deletedEntities.Add(entity, unitofWorkRepository);
                IsCommitted = false;
            }
        }

        public IRepository<T> Repository<T>() where T :
             IAggregateRoot
        {
            var typeName = typeof(T).Name;

            if (!this._repositories.ContainsKey(typeName))
            {
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
                using (TransactionScope scope = new TransactionScope())
                {
                    foreach (IAggregateRoot entity in this.addedEntities.Keys)
                    {
                        this.addedEntities[entity].PersistAdded(entity);
                    }

                    foreach (IAggregateRoot entity in this.updatedEntities.Keys)
                    {
                        this.updatedEntities[entity].PersistUpdated(entity);
                    }

                    foreach (IAggregateRoot entity in this.deletedEntities.Keys)
                    {
                        this.deletedEntities[entity].PersistDeleted(entity);
                    }

                    scope.Complete();
                    IsCommitted = true;
                }
            }
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
