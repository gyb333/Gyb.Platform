using Gyb.FrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

namespace Gyb.Server.Entities.VO
{
    public class ValueObject : ValueObjectBase
    {
        private readonly Type _value;
        public ValueObject(Type value)
        {
            _value = value;
            base.ThrowExceptionIfInvalid();
        }


        public Type Value
        {
            get { return _value; }
        }

        protected override void Validate()
        {
            //if (string.IsNullOrEmpty(_value))
            //    base.AddBrokenRule(PaymentBusinessRules.TransactionIdRequired);
        }

    }
}
