using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.Specifications.Leafs
{

    public class SpecificationLeafNot<TEntity> : ISpecification<TEntity>
        where TEntity : ISuggerableModel
    {

        public SpecificationLeafNot(ISpecification<TEntity> rigth)
        {
            this._right = rigth;
        }

        public void Initialize(ISpecificationFactory<TEntity> specificationFactory)
        {

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSatisfiedBy(TEntity entity)
        {
            return !this._right.IsSatisfiedBy(entity);
        }


        private readonly ISpecification<TEntity> _right;

    }
}
