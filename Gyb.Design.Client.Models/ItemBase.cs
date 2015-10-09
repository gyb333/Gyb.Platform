using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Client.Models
{
    public class ItemBase
    {
        public ItemBase(string strName,string strDescription)
        {
            Name = strName;
            Description = strDescription;
        }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
