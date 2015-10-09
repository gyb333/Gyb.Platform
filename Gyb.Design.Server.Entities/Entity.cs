using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.Entities
{
    public class Entity:BaseEntity
    {
        public string Definition { get; set; }
        public int ProjectId { get; set; }
    }
}
