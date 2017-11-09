using Bb.Specifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Suggestion.Models
{

    public class SuggestionQuerySelect<TEntity> : SuggestionQuery
         where TEntity : ISuggerableModel
    {

        public SuggestionQuerySelect()
        {
            //   this.Parameters = new List<SuggestionQueryParameter>();
        }


        public Origin Origin { get; set; }

        public IFilterFactory<TEntity> Filter { get; set; }

        public string[] Facets { get; set; }

        public SuggestionWhere<TEntity> Where { get; set; }

    }

}
