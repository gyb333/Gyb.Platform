using Gyb.FrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.Design.Server.Entities.EO
{
    public class EntityObject : EntityBase<int>
    {
        public Type Value { get; set; }

        protected override void Validate()
        {
            //if (String.IsNullOrEmpty(AddressLine1))
            //    base.AddBusinessRule(AddressBusinessRules.AddressLine1Required);
        }


    }
}
