using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.EF
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _dbContext;
 
        private bool _disposed;

        public DbContextFactory(DbContext dbContext)
        {
            // the context is new()ed up instead of being injected to avoid direct dependency on EF
            // not sure if this is good approach...but it removes direct dependency on EF from web tier
            _dbContext = dbContext;
        }

        public DbContext GetDbContext()
        {
            return _dbContext;
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

    }
}
