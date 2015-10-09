using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    public interface ISpecification
    {
        bool IsSatisfiedBy(object obj);
        Expression<Func<object, bool>> Expression { get; }
         

 
    } 
}
