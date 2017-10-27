using Bb.Sdk.Expressions;
using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.Suggestion.Service
{

    public class RuleInfo
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
            this.Method = type.GetMethod("IsSatisfiedBy");
        }

        public readonly Type Type;
        public readonly string Name;
        public readonly ConstructorInfo ctor;
        public readonly ParameterInfo[] Parameters;

        public static ArrayTypeEqulityComparer Comparer { get; private set; }

        protected readonly object factory;

        public int HashParameters { get; }
        public MethodInfo Method { get; private set; }
    }
    
}