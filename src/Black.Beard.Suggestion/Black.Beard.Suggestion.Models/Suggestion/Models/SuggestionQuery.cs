using System;

namespace Bb.Suggestion.Models
{

    public abstract class SuggestionQuery
    {

        public string Source { get; set; }

        public abstract void Initialize<TEntities>() where TEntities : ISuggerableModel;

    }

}