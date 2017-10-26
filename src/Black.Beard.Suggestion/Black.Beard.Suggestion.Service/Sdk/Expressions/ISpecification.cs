using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bb.Suggestion.Models;
using Bb.Suggestion.Service;

namespace Bb.Sdk.Expressions
{

    /// <summary>
    /// Inteface for Specification pattern.
    /// </summary>
    public interface ISpecification<TEntity>
    {

        /// <summary>
        /// The criteria of the Specification.
        /// </summary>
        Expression<Func<TEntity, bool>> Predicate { get; }

        /// <summary>
        /// Return true/false whethe the Entity object meet the criteria encapsulated by the specification.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool IsSatisfiedBy(TEntity entity);

        void Initialize<TEntities>(SpecificationFactory<TEntities> specificationFactory) where TEntities : ISuggerableModel;

    }

}
