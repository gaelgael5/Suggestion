using Bb.Specifications;
using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Suggestion.SuggestionParser
{

    public class QueryParameter
    {

        public QueryParameter(SuggestionQueryParameter parameter)
        {
            this.Name = parameter.Name;
            this.Value = parameter.Value;
            this.Expression = System.Linq.Expressions.Expression.Variable(Type.GetType(parameter.Type), parameter.Name);
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public ParameterExpression Expression { get; set; }


    }
}
