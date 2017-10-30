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
    public class RuleUnitTest
    {

        [TestMethod]
        public void EvaluateISpecification()
        {

            RuleSuggerable rule = new RuleSuggerable();
            var actual = rule.IsSatisfiedBy(new Site() { IsSuggrable = true });
            Assert.AreEqual(actual, true);

        }

        [TestMethod]
        public void EvaluateAndISpecification()
        {

            RuleSuggerable rule1 = new RuleSuggerable();
            RuleSuggerable rule2 = new RuleSuggerable();
            var rule3 = rule1 & rule2;

            var actual = rule3.IsSatisfiedBy(new Site() { IsSuggrable = true });

            Assert.AreEqual(actual, true);

        }

        [TestMethod]
        public void EvaluateORISpecification()
        {

            RuleSuggerable rule1 = new RuleSuggerable();
            RuleSuggerable rule2 = new RuleSuggerable();
            var rule3 = rule1 | rule2;

            var actual = rule3.IsSatisfiedBy(new Site() { IsSuggrable = true });

            Assert.AreEqual(actual, true);

        }

        [TestMethod]
        public void EvaluateDiscovery()
        {

            RuleRepository<Site> repository = new RuleRepository<Site>();

            var a = repository.ResolveRuleType(typeof(RuleSuggerable).Assembly);

            Assert.IsTrue(a > 0);

        }

        [TestMethod]
        public void EvaluateDiscoveryResolverAndActivateWithNoArgument()
        {

            ConstantRepository repository1 = new ConstantRepository();
            RuleRepository<Site> repository2 = new RuleRepository<Site>();
            SpecificationFactory<Site> _factory = new SpecificationFactory<Site>(repository2, repository1);
            var a = repository2.ResolveRuleType(typeof(RuleSuggerable).Assembly);

            var specification = _factory.Get("Suggerable", new object[] { });

            Assert.IsTrue(specification != null);

        }


        [TestMethod]
        public void EvaluateDiscoveryResolverAndActivateWithArguments()
        {
            ConstantRepository repository1 = new ConstantRepository();
            RuleRepository<Site> repository2 = new RuleRepository<Site>();
            SpecificationFactory<Site> _factory = new SpecificationFactory<Site>(repository2, repository1);
            var a = repository2.ResolveRuleType(typeof(RuleSuggerable).Assembly);

            var specification = _factory.Get("InIndex", new object[] { new int[] { 1, 2, 3 } });

            Assert.IsTrue(specification != null);

            Assert.IsTrue(specification.IsSatisfiedBy(new Site() { Key = 3 }));

        }

        [TestMethod]
        public void EvaluateDiscoveryResolverAndActivateWithDiagnostic()
        {

            PerformanceDiagnosticExpression diag = new PerformanceDiagnosticExpression() { DiagnosticMode = true };
            ConstantRepository repository1 = new ConstantRepository();
            RuleRepository<Site> repository2 = new RuleRepository<Site>(diag);
            SpecificationFactory<Site> _factory = new SpecificationFactory<Site>(repository2, repository1);
            var a = repository2.ResolveRuleType(typeof(RuleSuggerable).Assembly);


            var site = new Site() { Key = 4, IsSuggrable = true };

            _factory.Get("Suggerable", new object[] { }).IsSatisfiedBy(site);
            _factory.Get("InIndex", new object[] { new int[] { 1, 2, 3 } }).IsSatisfiedBy(site);

            var d1 = diag.Get(typeof(RuleSuggerable)).Items.First();
            var d2 = diag.Get(typeof(RuleIndex)).Items.First();

            Assert.IsTrue(d1 > 0);
            Assert.IsTrue(d2 > 0);

        }


        [TestMethod]
        public void EvaluateDiscoveryResolverAndActivateWithDiagnosticAverage()
        {

            PerformanceDiagnosticExpression diag = new PerformanceDiagnosticExpression() { DiagnosticMode = true };
            ConstantRepository repository1 = new ConstantRepository();
            RuleRepository<Site> repository2 = new RuleRepository<Site>(diag);
            SpecificationFactory<Site> _factory = new SpecificationFactory<Site>(repository2, repository1);
            var a = repository2.ResolveRuleType(typeof(RuleSuggerable).Assembly);


            var site = new Site() { Key = 4, IsSuggrable = true };

            var specification = _factory.Get("Suggerable", new object[] { });

            for (int i = 0; i < 10; i++)
                specification.IsSatisfiedBy(site);

            var d1 = diag.Get(typeof(RuleSuggerable)).Items.Average();

            Assert.IsTrue(d1 > 0);

        }


        [TestMethod]
        public void EvaluateDiscoveryResolverAndActivateWithDiagnosticPercentile()
        {

            PerformanceDiagnosticExpression diag = new PerformanceDiagnosticExpression() { DiagnosticMode = true };
            ConstantRepository repository1 = new ConstantRepository();
            RuleRepository<Site> repository2 = new RuleRepository<Site>(diag);
            SpecificationFactory<Site> _factory = new SpecificationFactory<Site>(repository2, repository1);
            var a = repository1.ResolveRuleType(typeof(RuleSuggerable).Assembly);


            var site = new Site() { Key = 4, IsSuggrable = true };

            var specification = _factory.Get("Suggerable", new object[] { });

            for (int i = 0; i < 200; i++)
                specification.IsSatisfiedBy(site);

            var d1 = diag.Get(typeof(RuleSuggerable)).Percentile(2);

            Assert.IsTrue(d1 > 0);

        }

        [TestMethod]
        public void EvaluateQuery()
        {



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
