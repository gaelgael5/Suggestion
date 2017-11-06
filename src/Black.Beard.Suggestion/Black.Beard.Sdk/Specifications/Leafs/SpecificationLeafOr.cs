using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bb.Specifications.Leafs
{

    public class SpecificationLeafOr<TEntity> : ISpecification<TEntity>
        where TEntity : ISuggerableModel
    {


        public SpecificationLeafOr(ISpecification<TEntity> left, ISpecification<TEntity> rigth)
        {
            this._left = left;
            this._rigth = rigth;
        }


        public void Initialize(ISpecificationFactory<TEntity> specificationFactory)
        {

        }


        /// <summary>
        /// Return true/false whethe the Entity object meet the criteria encapsulated by the specification.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsSatisfiedBy(TEntity entity)
        {

            return this._left.IsSatisfiedBy(entity) || this._rigth.IsSatisfiedBy(entity);

        }


        private ISpecification<TEntity> _left;
        private ISpecification<TEntity> _rigth;

    }
}
