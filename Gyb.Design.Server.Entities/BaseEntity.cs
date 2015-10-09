using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
    }
}
