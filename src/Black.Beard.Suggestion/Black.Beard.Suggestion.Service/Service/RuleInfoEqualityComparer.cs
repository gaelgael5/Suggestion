using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Bb.Suggestion.Service
{
    internal class RuleInfoEqualityComparer : IEqualityComparer<RuleInfo>
    {

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(RuleInfo x, RuleInfo y)
        {
            return x.ctor.GetHashCode() == y.ctor.GetHashCode();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetHashCode(RuleInfo obj)
        {
            return obj.ctor.GetHashCode();
        }

    }

}