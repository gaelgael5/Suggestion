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
    /// a specification is a Expression of <see cref="Specification&lt;T&gt;"/> return <c>bool</c>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Specification<T> : ISpecification<T> where T : class, ISuggerableModel
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Specification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        protected Specification(Expression<Func<T, bool>> predicate)
        {

            this._predicate = predicate;

        }

        public void Initialize<TEntities>(ISpecificationFactory<TEntities> specificationFactory) where TEntities : ISuggerableModel
        {

            this._diagnostics = (specificationFactory as SpecificationFactory<TEntities>).RuleRepository.Diagnostic;

            if (this._diagnostics.DiagnosticMode)
            {

                var t = _predicate.Compile();
                int crc = GetType().GetHashCode();

                Func<T, bool> e = (ff) =>
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
        public Expression<Func<T, bool>> Predicate { get { return _predicate; } }


        /// <summary>
        /// Determines whether [is satisfied by] [the specified entity].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// 	<c>true</c> if [is satisfied by] [the specified entity]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsSatisfiedBy(T entity)
        {
            if (fnc == null)
                fnc = _predicate.Compile();

            return this.fnc.Invoke(entity);
        }


        #region Operators

        /// <summary>
        /// Performs an implicit conversion from <see cref="Bb.Sdk.Expressions.Specification&lt;T&gt;"/>
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
        {
            return specification.Predicate;
        }


        /// <summary>
        /// Performs an implicit conversion from <see cref="Bb.Sdk.Expressions.Specification&lt;T&gt;"/>
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Func<T, bool>(Specification<T> specification)
        {
            return specification.Predicate.Compile();
        }


        /// <summary>
        /// Implements the operator &amp;.
        /// Concat two Specifications
        /// </summary>
        /// <param name="leftSide">The left side.</param>
        /// <param name="rightSide">The right side.</param>
        /// <returns>The result of the operator.</returns>
        public static Specification<T> operator &(Specification<T> leftSide, Specification<T> rightSide)
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
        public static Specification<T> operator |(Specification<T> leftSide, Specification<T> rightSide)
        {
            return leftSide._predicate.Or(rightSide._predicate);
        }


        /// <summary>
        /// Performs an implicit conversion from Expression to Specification
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Specification<T>(Expression<Func<T, bool>> specification)
        {
            return new Specification<T>(specification);
        }

        #endregion Operators


        private Expression<Func<T, bool>> _predicate;
        private Func<T, bool> fnc;
        private PerformanceDiagnosticExpression _diagnostics;

    }


}
