using Bb.Sdk.Helpers;
using System;
using System.Runtime.CompilerServices;

namespace Bb.Suggestion.Service
{
    public class ArrayTypeEqulityComparer : System.Collections.Generic.IEqualityComparer<Type[]>
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(Type[] x, Type[] y)
        {

            return GetHashCode(x) == GetHashCode(y);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(Type[] obj)
        {
            uint crc = 0;
            int length = obj.Length;
            for (int index = 0; index < length; index++)
                crc ^= Crc32.Calculate(obj[index].AssemblyQualifiedName);
            return (int)(crc & 0x7fffffff);
        }

    }

}