using System;
using System.Collections.Generic;
 
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.IRepositoryUOW
{
    /// <summary>
    /// 提供聚合
    /// 只能够检索的实体
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="E"></typeparam>
    public interface IReadOnlyRepository<TEntity> where TEntity : IAggregateRoot, IObjectState
    {      
        bool IsContains(Expression<Func<TEntity, bool>> predicate);


        
        TEntity Find(params object[] keys);


        TEntity Find(Expression<Func<TEntity, bool>> filter);



        IEnumerable<TEntity> FindAll();

        IEnumerable<TEntity> FindBySpecification(Func<TEntity, bool> spec);



        IEnumerable<TEntity> GetDataByPaged<KProperty>
            (int pageIndex, int pageSize, out int total, Func<TEntity, bool> filter, Func<TEntity, KProperty> orderBy, bool ascending = true, string[] includes = null);

        IEnumerable<TEntity> GetDataByFiltered<KProperty>(Func<TEntity, bool> filter, Func<TEntity, KProperty> orderBy, bool ascending = true, string[] includes = null);


    

        
        IQueryable<TEntity> GetData(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");



        IQueryable<TEntity> GetDataByPaged(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50);

        IQueryable<TEntity> GetData(Expression<Func<TEntity, bool>> predicate);
 



    }
}
