using Gyb.Design.Server.Data;
using Gyb.Design.Server.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.Repository
{
    public class DbRepository:IDbRepository
    {
        private DataBaseContext _ctx;
        public DbRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
        }

        public DbContext GetDbContext()
        {

            return _ctx;
        }

        public string GetServerNO()
        {
            throw new NotImplementedException();
        }

        public string GetServerIP()
        {
            throw new NotImplementedException();
        }

        public string GetServerHostName()
        {
            throw new NotImplementedException();
        }

        public DateTime GetServerDateTime()
        {
            throw new NotImplementedException();
        }
    }
}
