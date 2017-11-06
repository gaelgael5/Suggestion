using System;
using System.Linq.Expressions;
using Bb.Suggestion.Models;
using Bb.Sdk.Expressions;
using Bb.Suggestion.Service;
using System.Collections.Generic;
using Bb.Sdk.Factories;
using Bb.Specifications;

namespace Bb.Suggestion.SuggestionParser
{

    public class _Expression_parameter
    {


        public static _Expression_parameter Create<TEntity>(string Name, RuleInfo rule, Expression[] expression_values)
            where TEntity : ISuggerableModel
        {

            var value = new _Expression_parameter(Name, rule, expression_values);
            return value;

        }

        private _Expression_parameter(string Name, RuleInfo rule, Expression[] expression_values)
        {

            this.Name = Name;
            this.Rule = rule;

            int length = expression_values.Length;

            if (rule.Parameters.Length != length)
                throw new InvalidOperationException($" function called with invalid arguments");

            Expression[] args = new Expression[length];

            for (int i = 0; i < length; i++)
            {
                Expression expression_value = expression_values[i];
                if (expression_value.Type != rule.Parameters[i].ParameterType)
                    args[i] = Expression.Convert(expression_value, rule.Parameters[i].ParameterType);
                else
                    args[i] = expression_value;
            }

            this.Expression = Expression.New(rule.ctor, expression_values);

        }

        public string Name { get; }

        public Expression Expression { get; private set; }

        public RuleInfo Rule { get; }

    }

}
