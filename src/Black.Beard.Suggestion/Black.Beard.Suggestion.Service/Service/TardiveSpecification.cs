//using Bb.Sdk.Expressions;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using Bb.Suggestion.Models;
//using Bb.Suggestion.Service;
//using System.Linq.Expressions;
//using static Bb.Suggestion.SuggestionParser.SelectVisitor<TEntitie>;

//namespace Bb.Service.Expressions
//{

//    public class TardiveSpecification<T> : ISpecification<T>
//        where T : class, ISuggerableModel
//    {

//        public TardiveSpecification(parameter[] parameters)
//        {
//            this._parameters = parameters;
//        }

//        /// <summary>
//        /// Gets the predicate.
//        /// </summary>
//        /// <value>The predicate.</value>
//        public Expression<Func<T, bool>> Predicate { get { return _predicate; } }

//        public void Initialize<TEntities>(ISpecificationFactory<TEntities> specificationFactory)
//            where TEntities : ISuggerableModel
//        {

//            foreach (parameter p in this._parameters)
//            {

//                var s = p.Specification();



//            }

//            if (fnc == null)
//                fnc = _predicate.Compile();

//        }

//        /// <summary>
//        /// Determines whether [is satisfied by] [the specified entity].
//        /// </summary>
//        /// <param name="entity">The entity.</param>
//        /// <returns>
//        /// 	<c>true</c> if [is satisfied by] [the specified entity]; otherwise, <c>false</c>.
//        /// </returns>
//        public bool IsSatisfiedBy(T entity)
//        {
//            return this.fnc.Invoke(entity);
//        }

//        private Func<T, bool> fnc;
//        private Expression<Func<T, bool>> _predicate;
//        private readonly parameter[] _parameters;
//    }

//}
