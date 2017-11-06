using Bb.Sdk.Expressions;
using Bb.Suggestion.Sdk.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Black.Beard.Suggestion.UnitTests.Models
{

    public class MatchChar : ExpressionSpecification<Site>
    {

        [RuleName("MatchChar")]
        public MatchChar(char value)
            : base(GetExpression(value))
        {

        }

        private static Expression<Func<Site, bool>> GetExpression(object value)
        {
            return (site) => object.Equals(site.Value, value);
        }
    }

}
