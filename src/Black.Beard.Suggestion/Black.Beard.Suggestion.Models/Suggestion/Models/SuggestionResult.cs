using Bb.Specifications;

namespace Bb.Suggestion.Models
{
    public class SuggestionResult<TEntities> where TEntities : ISuggerableModel
    {

        public TEntities Poi { get; set; }

        public double Distance { get; set; }

    }

}