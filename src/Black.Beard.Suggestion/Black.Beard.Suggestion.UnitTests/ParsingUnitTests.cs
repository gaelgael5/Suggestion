using Bb.Sdk;
using Bb.Sdk.Expressions;
using Bb.Service;
using Bb.Specifications;
using Bb.Suggestion.Models;
using Bb.Suggestion.Service;
using Bb.Suggestion.SuggestionParser;
using Black.Beard.Caching.Runtime;
using Black.Beard.Suggestion.UnitTests.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace Black.Beard.Suggestion.UnitTests
{
    [TestClass]
    public class ParsingUnitTests
    {


        #region Select

        #region filter

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
        public void EvaluateQueryFilterDate3()
        {
            var filter = GetFilter(@"WHERE MatchDate(/20-10-2020 23:25:34/ ""dd-MM-yyyy HH:mm:ss"" ""en-US"")");
            Assert.AreEqual(filter(new Site() { Value = new DateTime(2020, 10, 20, 23, 25, 34) }), true);
            Assert.AreEqual(filter(new Site() { Value = new DateTime(2020, 10, 20) }), false);
        }

        //[TestMethod]
        //public void EvaluateQueryFilterDate4()
        //{
        //    var filter = GetFilter(@"WHERE MatchDate(/20-10-2020 20:10:00.23/ ""dd-MM-yyyy HH:mm:ss.ff"")");
        //    Assert.AreEqual(filter(new Site() { Value = new DateTime(2020, 10, 20, 20, 10, 00, 23) }), true);
        //    Assert.AreEqual(filter(new Site() { Value = new DateTime(2020, 10, 20) }), false);
        //}

        [TestMethod]
        public void EvaluateQueryFilterDate5()
        {
            var filter = GetFilter(@"WHERE MatchDate($CURRENT_DATE)");
            Assert.IsTrue(filter(new Site() { Value = DateTime.Now.Date }));
        }

        [TestMethod]
        public void EvaluateQueryFilterDate6()
        {
            var filter = GetFilter(@"WHERE MatchTime($CURRENT_TIME)");
            Assert.AreEqual(filter(new Site() { Value = DateTime.Now.TimeOfDay }), true);
            Assert.AreEqual(filter(new Site() { Value = DateTime.Now.AddMinutes(1).TimeOfDay }), false);
        }

        #endregion

        #endregion

        #region Show

        [TestMethod]
        public void EvaluateShowMethods()
        {

            var filter = GetQuery("SHOW METHODS").FirstOrDefault();

            if (filter is ShowSuggestionQuery q)
            {
                if (q.Datas is IEnumerable<RuleInfo<Site>> e)
                    Assert.IsTrue(e.Count() > 1);
                else
                    Assert.Fail("result empty");
            }
            else
                Assert.Fail("invalid type result");

        }

        [TestMethod]
        public void EvaluateShowMethod()
        {
            var filter = GetQuery("SHOW METHOD InIndex").FirstOrDefault();

            if (filter is ShowSuggestionQuery q)
            {
                if (q.Datas is IEnumerable<RuleInfo<Site>> e)
                    Assert.IsTrue(e.Count() == 1);
                else
                    Assert.Fail("result empty");
            }
            else
                Assert.Fail("invalid type result");
        }

        [TestMethod]
        public void EvaluateShowConstants()
        {

            var filter = GetQuery("SHOW CONSTANTS").FirstOrDefault();

            if (filter is ShowSuggestionQuery q)
            {
                if (q.Datas is IEnumerable<KeyValuePair<string, string>> e)
                    Assert.IsTrue(e.Count() > 1);
                else
                    Assert.Fail("result empty");
            }
            else
                Assert.Fail("invalid type result");
        }

        [TestMethod]
        public void EvaluateShowConstant()
        {

            var filter = GetQuery("SHOW CONSTANT current_utc_time").FirstOrDefault();

            if (filter is ShowSuggestionQuery q)
            {
                if (q.Datas is IEnumerable<KeyValuePair<string, string>> e)
                    Assert.IsTrue(e.Count() == 1);
                else
                    Assert.Fail("result empty");
            }
            else
                Assert.Fail("invalid type result");
        }

        #endregion

        [TestMethod]
        public void EvaluateSetGlobalPArameter()
        {

            GetQuery(@"SET @toto = ""aa""");

            if (GetQuery(@"SHOW PARAMETER toto").FirstOrDefault() is ShowSuggestionQuery q)
            {
                if (q.Datas is List<GlobalParameter> r)
                    Assert.AreEqual(r.FirstOrDefault().Value, "aa");
                else
                    Assert.Fail();
            }

            var filter1 = GetFilter(@"WHERE MatchString(@toto)");
            Assert.AreEqual(filter1(new Site() { Value = "aa" }), true);

            GetQuery(@"SET @toto = ""bb""");
            var filter2 = GetFilter(@"WHERE MatchString(@toto)");
            Assert.AreEqual(filter2(new Site() { Value = "bb" }), true);

            GetQuery(@"DEL @toto");

            if (GetQuery(@"SHOW PARAMETER toto").FirstOrDefault() is ShowSuggestionQuery q2)
            {
                if (q2.Datas is List<GlobalParameter> r)
                    Assert.AreEqual(r.Count, 0);
                else
                    Assert.Fail();
            }

        }

        [TestMethod]
        public void EvaluateMultiline()
        {

            var result = GetQuery(@"
            DEL @toto1;
            DEL @toto1;
            SET @toto1 = ""aa"";
            SET @toto2 = ""bb"";
");

            if (GetQuery(@"SHOW PARAMETERS").FirstOrDefault() is ShowSuggestionQuery q)
            {
                if (q.Datas is List<GlobalParameter> r)
                    Assert.AreEqual(r.FirstOrDefault().Value, "aa");
                else
                    Assert.Fail();
            }

        }






        private static List<SuggestionQuery> GetQuery(string query, params SuggestionQueryParameter[] parameters)
        {
            var parser = CreateParser(parameters);
            var _query = parser.Parse(query);
            return _query.ToList();
        }

        private static Func<Site, bool> GetFilter(string query, params SuggestionQueryParameter[] parameters)
        {
            var parser = CreateParser(parameters);
            var _query = parser.Parse(query).FirstOrDefault() as SuggestionQuerySelect<Site>;
            var arg = parameters.Select(c => c.GetValue()).Cast<object>().ToArray();
            ISpecification<Site> filter = _query.Where.Filter(arg); //.Filter.Build(parser.Context);
            return filter.IsSatisfiedBy;
        }

        private static QueryParser<Site> CreateParser(SuggestionQueryParameter[] parameters)
        {

            var clock = new SystemClock();
            var cache = new RuntimeLocalCache(new MemoryCache(new MemoryCacheOptions() { Clock = clock, }));
            GlobalParameterStorageService storageService = new GlobalParameterStorageService(Path.GetTempPath());

            RuleRepository<Site> repository1 = new RuleRepository<Site>();
            ConstantRepository repository2 = new ConstantRepository();
            IGlobalParameterService repository3 = new GlobalParameterService(storageService, cache);

            SpecificationFactory<Site> _factory = new SpecificationFactory<Site>(repository1, repository2, repository3);
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
