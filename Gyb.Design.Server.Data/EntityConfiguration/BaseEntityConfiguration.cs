using Gyb.Design.Server.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.Data.EntityConfiguration
{
    public class BaseEntityConfiguration: EntityTypeConfiguration<BaseEntity>
    {
        public BaseEntityConfiguration()
        {
            //配置Identifier映射到TripId列，并设为主键，且默认值为newid()
            //HasKey(t => t.CustomerId).
            //    Property(t => t.CustomerId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity).HasColumnName("CustomerId");
            ////配置CostUSD的精度为20，小数位数为3
            //Property(t => t.CostUSD).HasPrecision(20, 3);
            ////配置Description的长度为500
            //Property(t => t.Description).HasMaxLength(500);
            ////配置RowVersion乐观并发检查
            //Property(t => t.RowVersion).IsRowVersion();

            //IsRequired（）：通过这个方法指定该列是not-null的。

            //HasMaxLength（）：设定nvarchar列的最大字符数。

            //HasPercision(percison,scale):设定decimal列的最大值和小数点后位数。

            //HasColumnType(“TypeName”)：设定列的类型，但是指定的列的类型必须与类中的属性的类型相兼容。这个兼容规则后面将详细介绍。

            //HasDatabaseGeneratedOption（DatabaseGeneratedOption）：指定列是否是自增长列。

            //DatabaseGeneratedOption有三个选项：Idnetity：自增长

            //None：非自增长

            //Computed：用于一些通过计算得到值的列。

            //modelBuilder的Entity<Customer>方法的返回值还有一个HasKey方法用于设置数据表的主键。
        }
    }
}
