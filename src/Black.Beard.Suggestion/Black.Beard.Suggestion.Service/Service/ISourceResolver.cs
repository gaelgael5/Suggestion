using System.Collections.Generic;
using Bb.Suggestion.Models;

namespace Bb.Suggestion.Service
{
    public interface ISourceResolver
    {

        IEnumerable<TEntities> Resolve<TEntities>(ServiceRequest request);

    }
}