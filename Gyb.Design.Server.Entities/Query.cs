using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.Entities
{
    public class Query:BaseEntity
    {
        public string Definition { get; set; }
        public int EntityId { get; set; } 

    }
}
