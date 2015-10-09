using Gyb.Design.Client.IServices;
using Gyb.Design.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Client.Services
{
    public class TypeService:ITypeService
    {

        public IQueryable<TypeBase> GetAllTypes()
        {
            return new List<TypeBase>()
            {
                new TypeBase(){ Type= EItemTypes.Entity, Name="实体", Items= new List<ItemBase>{ new ItemBase("空的实体","新建一个新的实体")}.AsQueryable() },
                new TypeBase(){ Type= EItemTypes.Entity, Name="查询", IgnoreInAll=true, Items= new List<ItemBase>{ new ItemBase("空的查询","新建一个新的查询")}.AsQueryable() },
                new TypeBase(){ Type= EItemTypes.Entity, Name="界面", Items= new List<ItemBase>{ new ItemBase("空的界面","新建一个新的界面")}.AsQueryable() },
                new TypeBase(){ Type= EItemTypes.Entity, Name="工作流", Items= new List<ItemBase>{ new ItemBase("空的工作流","新建一个新的工作流")}.AsQueryable() },
            }.AsQueryable();
        }
    }
}
