using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Suggestion.Sdk.Attributes
{

    [System.AttributeUsage(AttributeTargets.Constructor, Inherited = false, AllowMultiple = false)]
    public sealed class RuleNameAttribute : Attribute
    {

        // See the attribute guidelines at 
        //  http://go.microsoft.com/fwlink/?LinkId=85236

        public RuleNameAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

    }

}
