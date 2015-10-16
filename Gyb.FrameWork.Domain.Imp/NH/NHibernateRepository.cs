using NHibernate;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    internal class NHibernateRepository<TEntity> : IRepository<TEntity>
     where TEntity : EntityObject, IAggregateRoot
    {
        ISession session;
        public NHibernateRepository(ISession session)
        {
            this.session = session;
        }

     

        public void Insert(TEntity entity)
        {
            this.session.Save(entity);
        }


        public TEntity GetById(int id)
        {
            return (TEntity)this.session.Get(typeof(TEntity), id);
        }
 
      
        public void Delete(TEntity entity)
        {
            this.session.Delete(entity);
        }
        public void Update(TEntity entity)
        {
            this.session.SaveOrUpdate(entity);
        }




        public IEnumerable<TEntity> FindAll()
        {
            throw new NotImplementedException();
            //    IQuery query = session.CreateQuery("from " +TEntity);
            //    var objects = query.List().AsQueryable();
                
            //return objects;
        }


        public IEnumerable<TEntity> FindBySpecification(Func<TEntity, bool> spec)
        {
            throw new NotImplementedException();
        }


        public TEntity Get(Func<TEntity, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageSize, out int total, Func<TEntity, bool> filter, Func<TEntity, KProperty> orderBy, bool ascending = true, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetFiltered<KProperty>(Func<TEntity, bool> filter, Func<TEntity, KProperty> orderBy, bool ascending = true, string[] includes = null)
        {
            throw new NotImplementedException();
        }


        public void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public void Delete(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Get(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Filter(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Filter(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50)
        {
            throw new NotImplementedException();
        }

        public bool Contains(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(params object[] keys)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool IsContains(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetDataByPaged<KProperty>(int pageIndex, int pageSize, out int total, Func<TEntity, bool> filter, Func<TEntity, KProperty> orderBy, bool ascending = true, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> GetDataByFiltered<KProperty>(Func<TEntity, bool> filter, Func<TEntity, KProperty> orderBy, bool ascending = true, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetData(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetDataByPaged(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetData(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    } 
}
