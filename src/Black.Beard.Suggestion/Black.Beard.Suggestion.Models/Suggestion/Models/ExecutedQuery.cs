using System;
using System.Collections.Generic;
using System.Text;
using Bb.Specifications;
using System.Collections;

namespace Bb.Suggestion.Models
{

    public class ExecutedQuery : SuggestionQuery
    {

        public ExecutedQuery(string messageResult, bool inError)
        {
            this.MessageResult = messageResult;
            this.InError = inError;
        }

        public ExecutedQuery(string messageResult, Exception e = null)
        {
            this.MessageResult = messageResult;
            this.Exception = e;
            if (e != null)
                this.InError = true;
        }

        public string MessageResult { get; set; }

        public Exception Exception { get; }

        public bool InError { get; }

        public override string ToString()
        {
            var t = InError
                ? "Failed" + Exception?.Message ?? string.Empty
                : "Success";

            return $"{MessageResult.ToString()} : ";
        }

    }
}
