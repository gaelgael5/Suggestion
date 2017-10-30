using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Bb.Suggestion.Service;
using Bb.Sdk.QuadTreeSorter;

namespace Black.Beard.Suggestion.UnitTests.Models
{

    public class Site : ISuggerableModel
    {

        public Site()
        {
            this.Location = new Point();
        }

        public bool IsSuggrable { get; set; }

        public IPoint Location { get; }
        public int Key { get; internal set; }
        public object Value { get; internal set; }
    }
}
