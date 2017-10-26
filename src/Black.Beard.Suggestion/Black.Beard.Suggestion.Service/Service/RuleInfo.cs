using Bb.Sdk.Expressions;
using Bb.Sdk.Factories;
using Bb.Sdk.Helpers;
using Bb.Suggestion.Models;
using System;
using System.Linq;
using System.Reflection;

namespace Bb.Suggestion.Service
{

    internal class RuleInfo
    {

        static RuleInfo()
        {
            RuleInfo.Comparer = new ArrayTypeEqulityComparer();
        }

        public RuleInfo(string name, Type type, ConstructorInfo ctor, object factory)
        {
            this.Type = type;
            this.Name = name;
            this.ctor = ctor;
            this.factory = factory;
            this.Parameters = ctor.GetParameters();
            this.HashParameters = Comparer.GetHashCode(this.Parameters.Select(c => c.ParameterType).ToArray());
        }

        public readonly Type Type;
        public readonly string Name;
        public readonly ConstructorInfo ctor;
        public readonly ParameterInfo[] Parameters;

        public static ArrayTypeEqulityComparer Comparer { get; private set; }

        protected readonly object factory;

        public int HashParameters { get; }

    }

    internal class RuleInfo<TEntities> : RuleInfo
        where TEntities : ISuggerableModel
    {

        public RuleInfo(string name, Type type, ConstructorInfo ctor) : base(name, type, ctor, ObjectCreator.GetActivator<ISpecification<TEntities>>(ctor))
        {
            
        }

        public ObjectActivator<ISpecification<TEntities>> Factory {  get { return base.factory as ObjectActivator<ISpecification<TEntities>>; } }

    }

}