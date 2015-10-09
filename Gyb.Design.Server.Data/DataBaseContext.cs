using Gyb.Design.Server.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.Data
{
        //CreateDatabaseIfNotExists<>：只有在没有数据库的时候才会根据数据库连接配置创建新的数据库。
        //这种配置主要用于production环境，因为你不可能把你现在使用的数据库删除掉，那样会损失重要的数据。
        //你需要让你的实施人员拿着与Fluent API配置对应的数据库脚本去更新数据库。

 

        //DropCreateDatabaseIfModelChanges<>：只要配置的数据库映射发生变化或者domain中的model发生变化了，
        //就把以前的数据库删除掉，根据新的配置重新建立数据库。这种方式比较适合开发数据库，可以减少开发人员的工作量。

 

        //DropCreateDatabaseAlways<>：不管数据库映射或者model是否发生变化，每次都重新删除并根据配置重建数据库。
        //这种方式可以适用于一些特殊情况的测试，比如说当每次测试结束之后把所有的测试数据都删除掉，并且在测试开始前插入一些基础数据。

    public class DataBaseContext:DbContext
    {
        #region 构造函数
        public DataBaseContext()
            : base("name=strDBConn")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;

#if DEBUG

            Database.SetInitializer(new ModelChangesDBConfiguration());
  
#else
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContext, DBMigrationConfiguration>());
#endif
        }
        #endregion


        public DbSet<Entity> Entities { get; set; }

        public DbSet<Query> Queries { get; set; }

        public DbSet<Screen> Screens { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Workflow> Workflows { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
