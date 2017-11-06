using Bb.Sdk.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Bb.Suggestion.Sdk.Attributes;

namespace Black.Beard.Suggestion.UnitTests.Models
{

    public class RuleSuggerable : ExpressionSpecification<Site>
    {
        
        [RuleName("Suggerable")]
        public RuleSuggerable()
            : base((e) => e.IsSuggrable)
        {

        }

    }

}
