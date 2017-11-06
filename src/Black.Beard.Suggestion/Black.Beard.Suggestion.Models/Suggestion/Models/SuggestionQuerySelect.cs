using Bb.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Suggestion.Models
{

    public class SuggestionQuerySelect<TEntity> : SuggestionQuery
         where TEntity : ISuggerableModel
    {

        public Origin Origin { get; set; }

        public IFilterFactory<TEntity> Filter { get; set; }

        public string[] Facets { get; set; }

        public Func<object[], ISpecification<TEntity>> Where { get; set; }

    }

}
