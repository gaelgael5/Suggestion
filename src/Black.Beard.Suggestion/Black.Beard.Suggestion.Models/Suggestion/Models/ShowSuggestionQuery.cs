using System;
using System.Collections.Generic;
using System.Text;
using Bb.Specifications;
using System.Collections;

namespace Bb.Suggestion.Models
{

    public class ShowSuggestionQuery : SuggestionQuery
    {

        public ShowSuggestionQuery(string objectName)
        {
            this.ObjectName = objectName;
        }

        public string ObjectName { get; private set; }

        public IEnumerable Datas { get; set; }

    }
}
