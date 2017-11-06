using Bb.Sdk.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.Specifications
{

    public class RuleInfo
    {

        static RuleInfo()
        {
            RuleInfo.Comparer = new ArrayTypeEqualityComparer();
        }

        public RuleInfo(string name, Type type, ConstructorInfo ctor)
        {
            this.Type = type;
            this.Name = name;
            this.ctor = ctor;            
            this.Parameters = ctor.GetParameters();
            this.HashParameters = Comparer.GetHashCode(this.Parameters.Select(c => c.ParameterType).ToArray());
            this.Method = type.GetMethod("IsSatisfiedBy");
        }

        public readonly Type Type;
        public readonly string Name;
        public readonly ConstructorInfo ctor;
        public readonly ParameterInfo[] Parameters;

        public static ArrayTypeEqualityComparer Comparer { get; private set; }        

        public int HashParameters { get; }
        public MethodInfo Method { get; private set; }

    }
    
}