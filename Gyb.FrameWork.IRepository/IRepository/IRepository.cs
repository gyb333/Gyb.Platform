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
    /// 能够检索和持久化的实体
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="E"></typeparam>
    public interface IRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : IAggregateRoot, IObjectState
    {
        void Insert(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);


        void Delete(params object[] keys);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : IAggregateRoot, IObjectState;

    }
}
