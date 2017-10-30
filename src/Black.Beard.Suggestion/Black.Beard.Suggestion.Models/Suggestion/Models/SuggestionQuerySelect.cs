using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Suggestion.Models
{

    public class SuggestionQuerySelect : SuggestionQuery
    {

        public Origin Origin { get; set; }

        public SuggestionQueryFilter Where { get; set; }

        public string[] Facets { get; set; }

        public override void Initialize<TEntities>()
        {

            if (Origin != null)
                Origin.Initialize();

            if (Where != null)
                Where.Initialize<TEntities>();

        }
    }

}
