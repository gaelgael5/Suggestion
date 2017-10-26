using Bb.Suggestion.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Suggestion.Models
{
    
    public interface ISuggerableModel
    {

        IPoint Location { get; }

    }
}
