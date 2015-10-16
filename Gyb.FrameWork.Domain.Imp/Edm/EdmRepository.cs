using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    internal class EdmRepository<TEntity> : IRepository<TEntity>
     where TEntity : EntityObject, IAggregateRoot
    {
        #region Private Fields

        private readonly ObjectContext objContext;
        private readonly string entitySetName;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objContext"></param>
        public EdmRepository(ObjectContext objContext)
        {
            this.objContext = objContext;
            if (!typeof(TEntity).IsDefined(typeof(AggregateRootAttribute), true))
                throw new Exception();
            AggregateRootAttribute aggregateRootAttribute = (AggregateRootAttribute)typeof(TEntity)
                .GetCustomAttributes(typeof(AggregateRootAttribute), true)[0];
            this.entitySetName = aggregateRootAttribute.EntitySetName;
        }
        #endregion

        #region IRepository<TEntity> Members
        public void Add(TEntity entity)
        {
            this.objContext.AddObject(EntitySetName, entity);
        }

        public TEntity GetById(int id)
        {
            string eSql = string.Format("SELECT VALUE ent FROM {0} AS ent WHERE ent.Id=@id", EntitySetName);
            var objectQuery = objContext.CreateQuery<TEntity>(eSql,
                new ObjectParameter("id", id));
            if (objectQuery.Count() > 0)
                return objectQuery.First();
            throw new Exception("Not found");
        }
 
        public void Remove(TEntity entity)
        {
            this.objContext.DeleteObject(entity);
        }
        public void Update(TEntity entity)
        {
           
        }
        public IEnumerable<TEntity> FindBySpecification(Func<TEntity, bool> spec)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Protected Properties
        protected string EntitySetName
        {
            get { return this.entitySetName; }
        }
        protected ObjectContext ObjContext
        {
            get { return this.objContext; }
        }
        #endregion




        public void Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
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

        public bool IsContains(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(object id)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(params object[] keys)
        {
            throw new NotImplementedException();
        }

        public TEntity Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindAll()
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
