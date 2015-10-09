using Gyb.FrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    class AggregateRoot : IAggregateRoot
    {
        public virtual IEnumerable<BusinessRule> Validate()
        {
            return new BusinessRule[] { };
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            IAggregateRoot ar = obj as IAggregateRoot;

            if (ar == null)
                return false;

            return Id == ar.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public int Id
        {
            get;
            set;
        }
    }
}
