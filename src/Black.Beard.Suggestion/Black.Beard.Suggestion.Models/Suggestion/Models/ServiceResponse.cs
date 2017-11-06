using Bb.Specifications;
using System.Collections.Generic;

namespace Bb.Suggestion.Models
{

    public class ServiceResponse<TEntity> : List<SuggestionResult<TEntity>>
        where TEntity : ISuggerableModel
    {

    }

}