using Bb.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Suggestion.Models
{

    public class SuggestionWhere<TEntity>
         where TEntity : ISuggerableModel
    {

        public SuggestionWhere(Func<object[], ISpecification<TEntity>> fnc, IEnumerable<WhereQueryParameter> parameters)
        {
            this.Filter = fnc;
            this.Parameters = new List<WhereQueryParameter>(parameters);
        }

        public List<WhereQueryParameter> Parameters { get; private set; }

        public Func<object[], ISpecification<TEntity>> Filter { get; private set; }

    }

}
