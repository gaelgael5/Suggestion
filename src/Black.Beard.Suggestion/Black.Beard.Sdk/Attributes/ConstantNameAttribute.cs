using System;

namespace Bb.Attributes
{
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class ConstantNameAttribute : Attribute
    {

        public ConstantNameAttribute(string name)
        {

            if (!name.StartsWith("$"))
                name = "$" + name;

            this.Name = name.ToLower();

        }

        public string Name { get; set; }

    }

}