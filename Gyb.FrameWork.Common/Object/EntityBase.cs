using Gyb.FrameWork.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Common
{
    /// <summary>
    /// 领域层超类型
    /// 提供检查领域实体有效性
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityBase<T>
    {
        private IList<BusinessRule> _businessRules = new List<BusinessRule>();

        public T Id { get; set; }

        protected abstract void Validate();

        public IEnumerable<BusinessRule> BusinessRules()
        {
            _businessRules.Clear();
            Validate();
            return _businessRules;
        }

        protected void AddBusinessRule(BusinessRule businessRule)
        {
            _businessRules.Add(businessRule);
        }

        public override bool Equals(object entity)
        {
            return entity != null && entity is EntityBase<T> && this == (EntityBase<T>)entity;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<T> entityLeft, EntityBase<T> entityRight)
        {
            if ((object)entityLeft == null && (object)entityRight == null)
            {
                return true;
            }

            if ((object)entityLeft == null || (object)entityRight == null)
            {
                return false;
            }

            if (entityLeft.Id.ToString() == entityRight.Id.ToString())
                return true;
            return false;
        }

        public static bool operator !=(EntityBase<T> entityLeft, EntityBase<T> entityRight)
        {
            return (!(entityLeft == entityRight));
        }
    }
}
