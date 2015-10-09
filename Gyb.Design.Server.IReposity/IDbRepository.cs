using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.IRepository
{
    public interface IDbRepository : IBaseRepository
    {
        DbContext GetDbContext();
    }
}
