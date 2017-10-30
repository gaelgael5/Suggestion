using Bb.Sdk.Expressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Suggestion.Models
{

    public class SuggestionQueryFilter
    {

        public Expression FilterExpression { get; set; }

        public ParameterExpression ArgumentModel { get; set; }

        public object Filter { get; private set; }

        public List<KeyValuePair<string, object>> Parameters { get; set; }

        internal void Initialize<TEntity>() where TEntity : ISuggerableModel
        {

            if (Parameters.Count > 0)
            {

                var lst = new List<Expression>();

                foreach (var item in Parameters)
                {

                    // Func<ISpecification<TEntitie>>
                    var v = item.Value as Func<ISpecification<TEntity>>;
                    ISpecification<TEntity> s = v();

                }

                lst.Add(FilterExpression);
                
                var block = Expression.Block(lst);
                var result = Expression.Lambda<Func<TEntity, bool>>(block, true, ArgumentModel);

            }
            else
            {
                var result = Expression.Lambda<Func<TEntity, bool>>(FilterExpression, true, ArgumentModel);
                Filter = result.Compile();
            }

        }
    }
}
