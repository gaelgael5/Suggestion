using System;
using System.Linq.Expressions;
using Bb.Suggestion.Models;
using Bb.Sdk.Expressions;
using Bb.Suggestion.Service;

namespace Bb.Suggestion.SuggestionParser
{

    public partial class SelectVisitor<TEntitie> where TEntitie : ISuggerableModel
    {
        public class parameter
        {

            public parameter(string Name, Func<ISpecification<TEntitie>> specification, bool tardive, RuleInfo rule)
            {
                this.Name = Name;
                this.Specification = specification;
                this.Tardive = tardive;

                if (tardive)
                {
                    this.Variable = Expression.Variable(rule.Type, Name);
                }
                else
                {
                    var speci = specification();
                    this.Constant = Expression.Constant(speci);
                }

            }

            public string Name { get; }

            public ConstantExpression Constant { get; private set; }

            public Func<ISpecification<TEntitie>> Specification { get; private set; }

            public ParameterExpression Variable { get; internal set; }

            public bool Tardive { get; private set; }

        }
    }

}
