using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Client.Models
{
    public class TypeBase
    {
        /// <summary>
        /// 类型名
        /// </summary>
        public string Name { get; set; }

        public IQueryable<ItemBase> Items { get; set; }

        public EItemTypes Type { get; set; }

        public bool IgnoreInAll { get; set; }

    }
}
