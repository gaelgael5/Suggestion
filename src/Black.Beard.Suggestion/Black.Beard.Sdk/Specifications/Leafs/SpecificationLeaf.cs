using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Specifications.Leafs
{

    public class SpecificationLeaf<TEntity> : ISpecification<TEntity>
        where TEntity : ISuggerableModel
    {


        public void Initialize(ISpecificationFactory<TEntity> specificationFactory)
        {

        }

        public bool IsSatisfiedBy(TEntity entity)
        {

            throw new NotImplementedException();

        }
        
    }
}
