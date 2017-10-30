using Bb.Sdk.Expressions;
using Bb.Suggestion.Service;
using Black.Beard.Suggestion.UnitTests.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Black.Beard.Suggestion.UnitTests
{
    [TestClass]
    public class ConstantUnit
    {

        [TestMethod]
        public void EvaluateConstantTrue()
        {
            Assert.AreEqual(Resolve("$true")(), true);
        }

        [TestMethod]
        public void EvaluateConstantFalse()
        {
            Assert.AreEqual(Resolve("$false")(), false);
        }

        [TestMethod]
        public void EvaluateConstantnull()
        {
            Assert.AreEqual(Resolve("$null")(), null);
        }


        [TestMethod]
        public void EvaluateConstantCurrentUtcTime()
        {
            var t1 = DateTime.UtcNow.TimeOfDay;
            var t2 = (TimeSpan)Resolve("$current_utc_time")();
            var t3 = DateTime.UtcNow.TimeOfDay;

            Assert.IsTrue(t1 < t2);
            Assert.IsTrue(t2 < t3);
        }

        [TestMethod]
        public void EvaluateConstantCurrentTime()
        {
            var t1 = DateTime.Now.TimeOfDay;
            var t2 = (TimeSpan)Resolve("$current_time")();
            var t3 = DateTime.Now.TimeOfDay;

            Assert.IsTrue(t1 <= t2);
            Assert.IsTrue(t2 <= t3);

        }

        [TestMethod]
        public void EvaluateConstantCurrentDate()
        {
            var t3 = DateTime.Now.Date;
            var t = Resolve("$current_date")();
            Assert.AreEqual(t, DateTime.Now.Date);
        }
    
        [TestMethod]
        public void EvaluateConstantCurrentUtcDate()
        {
            var t3 = DateTime.UtcNow.Date;
            var t = Resolve("$current_utc_date")();
            Assert.AreEqual(t, t3);
        }


        [TestMethod]
        public void EvaluateConstantCurrentTimestamp()
        {
            var t1 = DateTime.Now;
            var t2 = (DateTime)Resolve("$current_timestamp")();
            var t3 = DateTime.Now;

            Assert.IsTrue(t1 < t2);
            Assert.IsTrue(t2 < t3);

        }

        [TestMethod]
        public void EvaluateConstantCurrentUtcTimestamp()
        {
            var t1 = DateTime.UtcNow;
            var t2 = (DateTime)Resolve("$current_utc_timestamp")();
            var t3 = DateTime.UtcNow;

            Assert.IsTrue(t1 <= t2);
            Assert.IsTrue(t2 <= t3);

        }


        private static Func<object> Resolve(string constantName)
        {
            ConstantRepository repository = new ConstantRepository();
            var a = repository.Resolve(constantName);
            var fnc = Expression.Lambda<Func<object>>(Expression.Convert(a, typeof(object))).Compile();
            return fnc;
        }


    }
}
