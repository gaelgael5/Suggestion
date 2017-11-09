using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Sdk
{
    public class GlobalParameter
    {

        public GlobalParameter()
        {

        }

        public string Name { get; set; }

        public object Value { get; set; }

        public DateTime LastUpdate { get; set; }

        public Type Type { get; set; }
        public Exception Exception { get; set; }

        public Expression GetVariableExpression(MethodInfo method, Expression instance)
        {
            if (this._expression == null)
                this._expression = Expression.Convert(Expression.Call(instance, method, Expression.Constant(this.Name)), this.Type);
            return this._expression;
        }

        private UnaryExpression _expression;

    }

}