using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Bb.Suggestion.Service;

namespace Bb.Specifications
{

    /// <summary>
    /// Inteface for Specification pattern.
    /// </summary>
    public interface ISpecificationInitializer<TEntity> : ISpecification<TEntity> where TEntity : ISuggerableModel
    {
        
        void Initialize(ISpecificationFactory<TEntity> specificationFactory);

    }

}
