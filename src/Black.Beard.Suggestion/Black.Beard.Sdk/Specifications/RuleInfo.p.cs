using Bb.Sdk.Factories;
using Bb.Specifications;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.Specifications
{

    public class RuleInfo<TEntity> : RuleInfo
        where TEntity : ISuggerableModel
    {

        public RuleInfo(string name, Type type, ConstructorInfo ctor)
            : base(name, type, ctor)
        {

        }

        //public ObjectActivator<ISpecification<TEntity>> Factory(Expression[] values)
        //{

        //    ObjectActivator<ISpecification<TEntity>> factory;
        //    if (values.Length == 0)
        //        factory = ObjectCreator.GetActivator<ISpecification<TEntity>>(ctor);
        //    else
        //        factory = ObjectCreator.GetActivator<ISpecification<TEntity>>(ctor, values);

        //    return factory;

        //}

    }

}