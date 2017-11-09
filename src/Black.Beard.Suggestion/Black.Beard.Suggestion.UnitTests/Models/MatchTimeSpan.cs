using Bb.Sdk.Expressions;
using Bb.Suggestion.Sdk.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Black.Beard.Suggestion.UnitTests.Models
{

    public class MatchTimeSpan : ExpressionSpecification<Site>
    {

        [RuleName("MatchTime")]
        public MatchTimeSpan(TimeSpan value)
            : base(GetExpression(value))
        {

        }

        private static Expression<Func<Site, bool>> GetExpression(object value)
        {
            return (site) => 
            
                ((TimeSpan)site.Value).Hours == ((TimeSpan)value).Hours &&
                ((TimeSpan)site.Value).Minutes == ((TimeSpan)value).Minutes &&
                ((TimeSpan)site.Value).Seconds == ((TimeSpan)value).Seconds

            ;
        }

    }

}
