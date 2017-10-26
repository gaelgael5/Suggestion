using Bb.Sdk.Expressions;
using Bb.Suggestion.Sdk.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Black.Beard.Suggestion.UnitTests.Models
{

    public class RuleIndex : Specification<Site>
    {

        [RuleName("InIndex")]
        public RuleIndex(int[] index)
            : base(GetExpression(index))
        {

        }

        private static Expression<Func<Site, bool>> GetExpression(int[] index)
        {
            var indexs = new HashSet<int>(index);
            return (e) => indexs.Contains(e.Key);
        }
    }

}
