using Bb.Sdk.Expressions;
using Bb.Suggestion.Service;
using Bb.Suggestion.SuggestionParser;
using Black.Beard.Suggestion.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Black.Beard.Suggestion.UnitTests
{
    [TestClass]
    public class ParsingUnitTests
    {

        [TestMethod]
        public void EvaluateISpecification()
        {

            QueryParser parser = new QueryParser();

            parser.Parse("WHERE Suggerable() & InIndex(1, 2, 3)");

        }
        
    }
}
/*
 
    ORIGIN (x 1 y 1) 
    ORIGIN (ad1 '' ad2 '' zipcode '' country '') 

    SOURCE ALL

    WHERE Suggerable() & not Overloaded() & InIndex(1, 2, 3)
     
    FACETS FACTURE, CHARGE

 */
