using Bb.Suggestion.Models;
using System;
using System.Reflection;

namespace Bb.Suggestion.Service
{
    public interface IRuleRepository<TEntities>
        where TEntities : ISuggerableModel
    {


    }
}