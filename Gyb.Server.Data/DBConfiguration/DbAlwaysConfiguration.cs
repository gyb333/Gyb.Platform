using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Server.Data
{
    //表示每次都重新创建数据库。
    public class DbAlwaysConfiguration : DropCreateDatabaseAlways<DataBaseContext>
    {

#if DEBUG
        protected override void Seed(DataBaseContext context)
        {
            new DataBaseContextInitializer().Seed(context);
            base.Seed(context);
        }
#endif
    }
}
