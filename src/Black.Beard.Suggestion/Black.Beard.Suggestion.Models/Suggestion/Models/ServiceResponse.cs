using System.Collections.Generic;

namespace Bb.Suggestion.Models
{

    public class ServiceResponse<TEntities> : List<SuggestionResult<TEntities>>
        where TEntities : ISuggerableModel
    {

    }

}