using Gyb.FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.EF
{
    /// <summary>
    /// 其中IQueryable<T>的扩展方法会先收集需求，到最后一步再生成相应的SQL语句进行数据查询；
    /// 而IEnumerable<T>的扩展方法则是在查询的第一步就生成相应的SQL语句获取数据到内存中，后面的操作都是以内存中的数据为基础进行操作的。
    /// Func<TObject, bool>是委托(delegate) Expression<Func<TObject, bool>>是表达式, Expression编译后就会变成delegate，才能运行。
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class EFRepository<TEntity> : EFUnitWork, IRepository<TEntity>
    where TEntity : EntityObject, IAggregateRoot
    {

        #region 构造函数
        protected readonly DbSet<TEntity> _dbSet;

        public EFRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }


        protected DbSet<TEntity> DbSet
        {
            get { return _dbContext.Set<TEntity>(); }
        }
        #endregion


        #region 增删改

        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);

        }

        public void Delete(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }


        public void Delete(object id)
        {
            var entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);

        }

        public void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            var entitiesToDelete = GetData(predicate);
            foreach (var entity in entitiesToDelete)
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
                DbSet.Remove(entity);
            }
        }

        public void Update(TEntity entity)
        {
            var entry = _dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                var entityToUpdate = Find(entity.Id);
                EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<TEntity, TEntity>().Map(entity, entityToUpdate);

                DbSet.Attach(entity);
                entry.State = EntityState.Modified;



                //TEntity oldEntity = DbSet.Find(entity.Id);
                //_dbContext.Entry(oldEntity).CurrentValues.SetValues(entity);
                 //entry.State = EntityState.Unchanged;
                 // entry.Property("Password").IsModified = true;

            }

        }

        #endregion

        public bool IsContains(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Count(predicate) > 0;
        }

        #region 获取单个实体
        //先在EF的本地数据集Local中进行查询，如果没有，再去数据库中查询。
        public TEntity Find(object id)
        {
            //return DbSet.SingleOrDefault(entity => entity.Id == id);
            return DbSet.Find(id);
        }


        public TEntity Find(params object[] keys)
        {
            return DbSet.Find(keys);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }
        #endregion

        /// <summary>
        /// 相当于把整个表的数据都加载到内存中
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> FindAll()
        {
            return DbSet;
        }

       

        public IEnumerable<TEntity> FindBySpecification(Func<TEntity, bool> spec)
        {
            return DbSet.Where(spec);
        }


        #region 分页

        public IEnumerable<TEntity> GetDataByPaged<KProperty>(int pageIndex, int pageSize, out int total, 
            Func<TEntity, bool> filter, Func<TEntity, KProperty> orderBy, bool ascending = true, string[] includes = null)
        {
            pageIndex = pageIndex > 0 ? pageIndex : 1;

            var result = this.GetDataByFiltered(filter, orderBy, ascending, includes);

            total = result.Count();

            return result.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public IEnumerable<TEntity> GetDataByFiltered<KProperty>(Func<TEntity, bool> filter, Func<TEntity, KProperty> orderBy,
            bool ascending = true, string[] includes = null)
        {
            var result = filter == null ? this.DbSet : this.DbSet.Where(filter);

            if (ascending)
                result = result.OrderBy(orderBy);
            else
                result = result.OrderByDescending(orderBy);

            var temp = result.AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    temp = temp.Include(include);
                }
            }
            return temp.ToList();
        }

        #endregion



        public IQueryable<TEntity> GetData(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!String.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).AsQueryable();
            }
            else
            {
                return query.AsQueryable();
            }
        }

        public IQueryable<TEntity> GetDataByPaged(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50)
        {
            int skipCount = index * size;
            var resetSet = filter != null ? DbSet.Where(filter).AsQueryable() : DbSet.AsQueryable();
            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);
            total = resetSet.Count();
            return resetSet.AsQueryable();
        }

        public IQueryable<TEntity> GetData(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable();
        }
 








       

     

    }
}
