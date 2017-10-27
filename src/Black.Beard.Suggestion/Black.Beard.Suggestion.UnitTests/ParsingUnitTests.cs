using Bb.Sdk.Expressions;
using Bb.Suggestion.Models;
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
        public void EvaluateQueryFilterWithArgument()
        {
            var parser = CreateParser();
            parser.Parse("WHERE InIndex(1, 2, 3)");
        }

        [TestMethod]
        public void EvaluateQueryFilterWithArgumentComplex()
        {
            var parser = CreateParser();
            parser.Parse("WHERE InIndex(1, 2 + 2, 3)");
        }

        [TestMethod]
        public void EvaluateQueryFilterWithoutArgument()
        {
            QueryParser<Site> parser = CreateParser();
            parser.Parse("WHERE Suggerable()");
        }
    
        [TestMethod]
        public void EvaluateQueryFilterBinaryAnd()
        {
            var parser = CreateParser();
            parser.Parse("WHERE Suggerable() & Suggerable()");
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryAnd2()
        {
            var parser = CreateParser();
            parser.Parse("WHERE Suggerable() & Suggerable() & Suggerable()");
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryAnd3()
        {
            var parser = CreateParser();
            parser.Parse("WHERE Suggerable() & (Suggerable() & Suggerable())");
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryAndAlso()
        {
            var parser = CreateParser();
            parser.Parse("WHERE Suggerable() && Suggerable()");
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryOr()
        {
            var parser = CreateParser();
            parser.Parse("WHERE Suggerable() | Suggerable()");
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryOrExclusive()
        {
            var parser = CreateParser();
            parser.Parse("WHERE Suggerable() || Suggerable()");
        }



        private static QueryParser<Site> CreateParser()
        {
            RuleRepository<Site> repository = new RuleRepository<Site>();
            SpecificationFactory<Site> _factory = new SpecificationFactory<Site>(repository);
            var a = repository.ResolveType(typeof(RuleSuggerable).Assembly);

            var ctx = new QueryContext<Site>(_factory);

            QueryParser<Site> parser = new QueryParser<Site>(ctx);
            return parser;
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
