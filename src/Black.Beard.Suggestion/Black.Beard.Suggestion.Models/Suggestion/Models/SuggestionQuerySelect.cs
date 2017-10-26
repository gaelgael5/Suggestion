using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Suggestion.Models
{

    public class SuggestionQuerySelect : SuggestionQuery
    {

        public Origin Origin { get; set; }

        public SuggestionQueryFilter Filter { get; set; }

        public string[] Facets { get; set; }

    }

}
