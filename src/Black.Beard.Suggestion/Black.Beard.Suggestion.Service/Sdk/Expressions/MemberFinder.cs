using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Sdk.Expressions
{

    /// <summary>
    /// find Member info in the expression
    /// </summary>
    public class MemberFinder : ExpressionVisitor
    {

        private System.Reflection.MemberInfo member;

        /// <summary>
        /// Gets the member embedded in the specified expression
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static System.Reflection.MemberInfo Get<T, T2>(System.Linq.Expressions.Expression<Func<T, T2>> self)
        {
            MemberFinder visitor = new MemberFinder();
            visitor.Visit(self);
            return visitor.member;
        }

        /// <summary>
        /// Visits the children of the <see cref="T:System.Linq.Expressions.MemberExpression" />.
        /// </summary>
        /// <param name="node">The expression to visit.</param>
        /// <returns>
        /// The modified expression, if it or any subexpression was modified; otherwise, returns the original expression.
        /// </returns>
        protected override Expression VisitMember(MemberExpression node)
        {
            this.member = node.Member;
            return base.VisitMember(node);
        }

    }

}
