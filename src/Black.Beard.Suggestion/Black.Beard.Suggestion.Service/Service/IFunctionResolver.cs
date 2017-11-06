using Bb.Specifications;
using Bb.Suggestion.Models;
using System;

namespace Bb.Suggestion.Service
{
    public interface IFunctionResolver<TEntities>
        where TEntities : ISuggerableModel
    {

        Func<TEntities, bool> Filter { get; }

        int MaxDistance { get; }

        Origin Origin { get; }

        void Initialize(ServiceRequest request);

        //Func<TEntities, TKey> KeySelector;

    }
}