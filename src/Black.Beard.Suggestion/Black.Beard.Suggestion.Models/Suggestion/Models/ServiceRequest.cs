using System.Collections.Generic;

namespace Bb.Suggestion.Models
{

    public class ServiceRequest
    {

        public SuggestionQuery Query { get; set; }

        public List<SuggestionQueryParameter> Parameters { get; set; }

    }

}