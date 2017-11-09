using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Sdk.Expressions
{


    /// <summary>
    /// Constant finder
    /// </summary>
    public class ConstantFinder : ExpressionVisitor
    {

        private dynamic value;

        /// <summary>
        /// Gets the constant value embedded in the specified expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static dynamic Get(Expression self)
        {
            ConstantFinder visitor = new ConstantFinder();
            visitor.Visit(self);
            return visitor.value;
        }

        /// <summary>
        /// Visits the <see cref="T:System.Linq.Expressions.ConstantExpression" />.
        /// </summary>
        /// <param name="node">The expression to visit.</param>
        /// <returns>
        /// The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.
        /// </returns>
        protected override Expression VisitConstant(ConstantExpression node)
        {
            this.value = node.Value;
            return base.VisitConstant(node);
        }


    }

}
