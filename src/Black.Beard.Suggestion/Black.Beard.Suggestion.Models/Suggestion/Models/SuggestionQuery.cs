using Bb.Specifications;
using System;
using System.Collections.Generic;

namespace Bb.Suggestion.Models
{

    public abstract class SuggestionQuery
    {

        public SuggestionQuery()
        {

        }

        public string Source { get; set; }

    }

}