using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gyb.FrameWork.IRepositoryUOW
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot, IObjectState
    {
        Task<TEntity> FindAsync(params object[] keys);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keys);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
    }
}
