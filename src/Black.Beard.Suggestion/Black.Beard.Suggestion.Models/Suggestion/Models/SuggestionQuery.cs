using Bb.Specifications;
using System;
using System.Collections.Generic;

namespace Bb.Suggestion.Models
{

    public abstract class SuggestionQuery
    {

        public SuggestionQuery()
        {
            this.Parameters = new List<SuggestionQueryParameter>();
        }

        public string Source { get; set; }
        
        public List<SuggestionQueryParameter> Parameters { get; set; }        


    }

}