using Bb.Suggestion.Models;

namespace Bb.Suggestion.Service
{
    public interface ISuggestionService<TEntities>
        where TEntities : ISuggerableModel
    {
        ServiceResponse<TEntities> Resolve(ServiceRequest query);
    }
}