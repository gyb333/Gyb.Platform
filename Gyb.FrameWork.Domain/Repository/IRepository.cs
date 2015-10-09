using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    /// <summary>
    /// 提供聚合
    /// 能够检索和持久化的实体
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="E"></typeparam>
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity :  IAggregateRoot
    {
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);


        void Delete(object id);

        void Delete(Expression<Func<TEntity, bool>> predicate);



    }
}
