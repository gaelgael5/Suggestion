using Bb.Sdk.Expressions;
using Bb.Sdk.Factories;
using Bb.Sdk.Helpers;
using Bb.Suggestion.Models;
using System;
using System.Linq;
using System.Reflection;

namespace Bb.Suggestion.Service
{

    public class RuleInfo<TEntities> : RuleInfo
        where TEntities : ISuggerableModel
    {

        public RuleInfo(string name, Type type, ConstructorInfo ctor) : base(name, type, ctor, ObjectCreator.GetActivator<ISpecification<TEntities>>(ctor))
        {
            
        }

        public ObjectActivator<ISpecification<TEntities>> Factory {  get { return base.factory as ObjectActivator<ISpecification<TEntities>>; } }

    }

}