using Bb.Specifications;
using Bb.Suggestion.Models;

namespace Bb.Specifications
{
    public interface ISuggestionService<TEntities>
        where TEntities : ISuggerableModel
    {
        ServiceResponse<TEntities> Resolve(ServiceRequest query);
    }
}