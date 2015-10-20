using Gyb.Server.Data;
using Gyb.Server.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Server.Repository
{
    public class BaseRepository :IBaseRepository
    {

        //Join()两表必须含有外键关系
        //Include()，两表必须含有外键关系,并且Include()是立即查询的，像ToList()一样，不会稍后延迟优化后再加载。
        private DataBaseContext _ctx;
        public BaseRepository(DataBaseContext ctx)
        {
            _ctx = ctx;
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

        public DbContext GetDataBaseContext()
        {
            return _ctx;
        }
    }
}
