using Bb.Sdk.Expressions;
using Bb.Specifications;
using Bb.Suggestion.Models;
using Bb.Suggestion.Service;
using Bb.Suggestion.SuggestionParser;
using Black.Beard.Suggestion.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Black.Beard.Suggestion.UnitTests
{
    [TestClass]
    public class ParsingUnitTests
    {


        [TestMethod]
        public void EvaluateQueryFilterWithoutArgument()
        {
            var filter = GetFilter("WHERE Suggerable()");
            Assert.AreEqual(filter(new Site() { IsSuggrable = true }), true);
            Assert.AreEqual(filter(new Site() { IsSuggrable = false }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterWithArgument()
        {
            var filter = GetFilter("WHERE InIndex([1, 2, 3])");
            Assert.AreEqual(filter(new Site() { Key = 1 }), true);
            Assert.AreEqual(filter(new Site() { Key = 4 }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryAnd()
        {
            var filter = GetFilter("WHERE Suggerable() & Suggerable()");
            Assert.AreEqual(filter(new Site() { IsSuggrable = true }), true);
            Assert.AreEqual(filter(new Site() { IsSuggrable = false }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterWithoutArgumentNot()
        {
            var filter = GetFilter("WHERE !Suggerable()");
            Assert.AreEqual(filter(new Site() { IsSuggrable = true }), false);
            Assert.AreEqual(filter(new Site() { IsSuggrable = false }), true);
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryAnd2()
        {
            var filter = GetFilter("WHERE Suggerable() & Suggerable() & Suggerable()");
            Assert.AreEqual(filter(new Site() { IsSuggrable = true }), true);
            Assert.AreEqual(filter(new Site() { IsSuggrable = false }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryAnd3()
        {
            var filter = GetFilter("WHERE Suggerable() & (Suggerable() & Suggerable())");
            Assert.AreEqual(filter(new Site() { IsSuggrable = true }), true);
            Assert.AreEqual(filter(new Site() { IsSuggrable = false }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryAndAlso()
        {
            var filter = GetFilter("WHERE Suggerable() && Suggerable()");
            Assert.AreEqual(filter(new Site() { IsSuggrable = true }), true);
            Assert.AreEqual(filter(new Site() { IsSuggrable = false }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryOr()
        {
            var filter = GetFilter("WHERE Suggerable() | Suggerable()");
            Assert.AreEqual(filter(new Site() { IsSuggrable = true }), true);
            Assert.AreEqual(filter(new Site() { IsSuggrable = false }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterBinaryOrExclusive()
        {
            var filter = GetFilter("WHERE Suggerable() || Suggerable()");
            Assert.AreEqual(filter(new Site() { IsSuggrable = true }), true);
            Assert.AreEqual(filter(new Site() { IsSuggrable = false }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterString()
        {
            var filter = GetFilter(@"WHERE MatchString(""toto"")");
            Assert.AreEqual(filter(new Site() { Value = "toto" }), true);
            Assert.AreEqual(filter(new Site() { Value = "titi" }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterChar()
        {
            var filter = GetFilter(@"WHERE MatchChar('t')");
            Assert.AreEqual(filter(new Site() { Value = 't' }), true);
            Assert.AreEqual(filter(new Site() { Value = 'i' }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterBoolTrue()
        {
            var filter = GetFilter(@"WHERE MatchBool($TRUE)");
            Assert.AreEqual(filter(new Site() { Value = true }), true);
            Assert.AreEqual(filter(new Site() { Value = false }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterBoolWithParameter()
        {
            var filter = GetFilter(@"WHERE MatchBool(:param1)", new SuggestionQueryParameter() { Name = ":param1", Type = typeof(bool).AssemblyQualifiedName, Value = "false" });
            Assert.AreEqual(filter(new Site() { Value = false }), true);
            Assert.AreEqual(filter(new Site() { Value = true }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterBoolFalse()
        {
            var filter = GetFilter(@"WHERE MatchBool($false)");
            Assert.AreEqual(filter(new Site() { Value = false }), true);
            Assert.AreEqual(filter(new Site() { Value = true }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterDate()
        {
            var filter = GetFilter(@"WHERE MatchDate(/2010-20-10/ ""yyyy-dd-MM"")");
            Assert.AreEqual(filter(new Site() { Value = new DateTime(2010, 10, 20) }), true);
            Assert.AreEqual(filter(new Site() { Value = new DateTime(2020, 10, 20) }), false);

        }

        [TestMethod]
        public void EvaluateQueryFilterDate2()
        {
            var filter = GetFilter(@"WHERE MatchDate(/20-10-2020/ ""dd-MM-yyyy"")");
            Assert.AreEqual(filter(new Site() { Value = new DateTime(2010, 10, 20) }), false);
            Assert.AreEqual(filter(new Site() { Value = new DateTime(2020, 10, 20) }), true);
        }

        [TestMethod]
        public void EvaluateQueryFilterDate5()
        {
            var filter = GetFilter(@"WHERE MatchDate($CURRENT_DATE)");
            Assert.IsTrue(filter(new Site() { Value = DateTime.Now.Date }));
        }

        [TestMethod]
        public void EvaluateQueryFilterDate3()
        {
            var filter = GetFilter(@"WHERE MatchDate(/20-10-2020 23:25:34/ ""dd-MM-yyyy hh:mm:ss"")");
            Assert.AreEqual(filter(new Site() { Value = new DateTime(2020, 10, 20, 23, 25, 34) }), true);
            Assert.AreEqual(filter(new Site() { Value = new DateTime(2020, 10, 20) }), false);
        }

        [TestMethod]
        public void EvaluateQueryFilterDate4()
        {
            var filter = GetFilter(@"WHERE MatchDate(/20-10-2020 20:10:00.23/  ""dd-MM-yyyy hh:mm:ss.ff"")");
        }

        [TestMethod]
        public void EvaluateQueryFilterDate6()
        {
            var filter = GetFilter(@"WHERE MatchTime($CURRENT_TIME)");
        }

        [TestMethod]
        public void EvaluateQueryFilterDate7()
        {
            var filter = GetFilter(@"WHERE MatchDateTime($CURRENT_TIMESTAMP)");
        }

        [TestMethod]
        public void EvaluateShowMethods()
        {
            var filter = GetFilter("SHOW METHODS");
        }

        [TestMethod]
        public void EvaluateShowMethod()
        {
            var filter = GetFilter("SHOW METHOD InIndex");
        }

        [TestMethod]
        public void EvaluateSetGlobalPArameter()
        {
            var filter = GetFilter(@"SET toto = ""aa""");
            var filter2 = GetFilter(@"GET toto");
            var filter3 = GetFilter(@"WHERE MatchString(""toto"")");
            var filter4 = GetFilter(@"DEL toto");
            var filter5 = GetFilter(@"WHERE MatchString(""toto"")");
        }

        private static Func<Site, bool> GetFilter(string query, params SuggestionQueryParameter[] parameters)
        {
            var parser = CreateParser(parameters);
            var _query = parser.Parse(query) as SuggestionQuerySelect<Site>;
            var arg = parameters.Select(c => c.GetValue()).Cast<object>().ToArray();
            ISpecification<Site> filter = _query.Where(arg); //.Filter.Build(parser.Context);
            return filter.IsSatisfiedBy;
        }

        private static QueryParser<Site> CreateParser(SuggestionQueryParameter[] parameters)
        {
            RuleRepository<Site> repository1 = new RuleRepository<Site>();
            ConstantRepository repository2 = new ConstantRepository();
            SpecificationFactory<Site> _factory = new SpecificationFactory<Site>(repository1, repository2);
            var a = repository1.ResolveRuleType(typeof(RuleSuggerable).Assembly);

            var ctx = new QueryContext<Site>(_factory, parameters);

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
