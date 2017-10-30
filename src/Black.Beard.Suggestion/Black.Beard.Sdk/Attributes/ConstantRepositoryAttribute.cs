using System;

namespace Bb.Attributes
{

    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ConstantRepositoryAttribute : Attribute
    {

        public ConstantRepositoryAttribute()
        {
        }

    }

}