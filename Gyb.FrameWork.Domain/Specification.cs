using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Gyb.FrameWork.Domain
{
    public abstract class Specification : ISpecification
    {
  
        public bool IsSatisfiedBy(object obj)
        {
            return this.Expression.Compile()(obj);
        }
        public abstract Expression<Func<object, bool>> Expression { get; }


        public static ISpecification Eval(Expression<Func<object, bool>> expression)
        {
            return new ExpressionSpec(expression);
        }

        internal class ExpressionSpec : Specification
        {
            private Expression<Func<object, bool>> exp;
            public ExpressionSpec(Expression<Func<object, bool>> expression)
            {
                this.exp = expression;
            }
            public override Expression<Func<object, bool>> Expression
            {
                get { return this.exp; }
            }
        } 
    } 
}
