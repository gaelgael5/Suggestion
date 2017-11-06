using Bb.Specifications;
using Bb.Suggestion.Models;
using Bb.Suggestion.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Sdk.Expressions
{


    /// <summary>
    /// a specification is a Expression of <see cref="ExpressionSpecification&lt;T&gt;"/> return <c>bool</c>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class ExpressionSpecification<TEntity> : ISpecificationInitializer<TEntity>, ISpecification<TEntity> where TEntity : class, ISuggerableModel
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionSpecification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        protected ExpressionSpecification(Expression<Func<TEntity, bool>> predicate)
        {

            this._predicate = predicate;

        }

        public void Initialize(ISpecificationFactory<TEntity> specificationFactory)
        {

            this._diagnostics = (specificationFactory as SpecificationFactory<TEntity>).RuleRepository.Diagnostic;

            if (this._diagnostics.DiagnosticMode)
            {

                var t = _predicate.Compile();
                int crc = GetType().GetHashCode();

                Func<TEntity, bool> e = (ff) =>
                {
                    Stopwatch s = new Stopwatch();
                    s.Start();
                    bool result = t(ff);
                    s.Stop();

                    this._diagnostics.Append(crc, s.ElapsedTicks);


                    return result;
                };
                _predicate = (a) => e(a);

            }

        }

        /// <summary>
        /// Gets the predicate.
        /// </summary>
        /// <value>The predicate.</value>
        public Expression<Func<TEntity, bool>> Predicate { get { return _predicate; } }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified entity]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSatisfiedBy(TEntity entity)
        {
            if (fnc == null)
                fnc = _predicate.Compile();

            return this.fnc.Invoke(entity);
        }


        #region Operators

        /// <summary>
        /// Performs an implicit conversion from <see cref="Bb.Sdk.Expressions.ExpressionSpecification&lt;T&gt;"/>
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Expression<Func<TEntity, bool>>(ExpressionSpecification<TEntity> specification)
        {
            return specification._predicate;
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="Bb.Sdk.Expressions.ExpressionSpecification&lt;T&gt;"/>
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Func<TEntity, bool>(ExpressionSpecification<TEntity> specification)
        {
            return specification._predicate.Compile();
        }


        /// <summary>
        /// Implements the operator &amp;.
        /// Concat two Specifications
        /// </summary>
        /// <param name="leftSide">The left side.</param>
        /// <param name="rightSide">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static ExpressionSpecification<TEntity> operator &(ExpressionSpecification<TEntity> leftSide, ExpressionSpecification<TEntity> rightSide)
        {
            return leftSide._predicate.AndAlso(rightSide._predicate);
        }


        /// <summary>
        /// Implements the operator |.
        /// execute or logic
        /// </summary>
        /// <param name="leftSide">The left side.</param>
        /// <param name="rightSide">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static ExpressionSpecification<TEntity> operator |(ExpressionSpecification<TEntity> leftSide, ExpressionSpecification<TEntity> rightSide)
        {
            return leftSide._predicate.Or(rightSide._predicate);
        }


        /// <summary>
        /// Performs an implicit conversion from Expression to Specification
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator ExpressionSpecification<TEntity>(Expression<Func<TEntity, bool>> specification)
        {
            return new ExpressionSpecification<TEntity>(specification);
        }

        #endregion Operators


        private Expression<Func<TEntity, bool>> _predicate;
        private Func<TEntity, bool> fnc;
        private PerformanceDiagnosticExpression _diagnostics;

    }


}
