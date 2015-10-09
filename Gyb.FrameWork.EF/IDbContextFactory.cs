using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.EF
{
    public interface IDbContextFactory : IDisposable
    {
        DbContext GetDbContext();

        
    }
}
