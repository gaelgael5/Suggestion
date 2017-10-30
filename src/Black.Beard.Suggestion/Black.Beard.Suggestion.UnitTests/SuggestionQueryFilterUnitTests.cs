using Bb.Sdk.Expressions;
using Bb.Suggestion.Service;
using Black.Beard.Suggestion.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Black.Beard.Suggestion.UnitTests
{
    [TestClass]
    public class SuggestionQueryFilterUnitTests
    {

        [TestMethod]
        public void EvaluateQuery()
        {

            // $arg_MatchDate = new Black.Beard.Suggestion.UnitTests.Models.MatchDate(DateTime.Now);

            // .Call ((Black.Beard.Suggestion.UnitTests.Models.MatchDate)$arg_MatchDate).IsSatisfiedBy($model)

        }


        private void t()
        {

            DateTime Date1 = DateTime.Now;

            var i = Date1 > new DateTime(2017, 01, 01);

        }



    }
}
