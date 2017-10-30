using Bb.Attributes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Reflection;

namespace Bb.Service
{

    [ConstantRepository]
    public class _ConstantRepository
    {

        public _ConstantRepository()
        {
            this.utcNow = typeof(DateTime).GetProperty("UtcNow", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
            this.now = typeof(DateTime).GetProperty("Now", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
        }

        [ConstantName("true")]
        public Expression GetTrue()
        {
            return Expression.Constant(true);
        }

        [ConstantName("false")]
        public Expression GetFalse()
        {
            return Expression.Constant(false);
        }

        [ConstantName("null")]
        public Expression GetNull()
        {
            return Expression.Constant(null);
        }

        [ConstantName("current_time")]
        public Expression GetCurrentTime()
        {
            return Expression.Property(Expression.Property(null, this.now), "TimeOfDay");
        }

        [ConstantName("current_utc_time")]
        public Expression GetCurrentUtcTime()
        {                        
            return Expression.Property(Expression.Property(null, this.utcNow), "TimeOfDay");
        }

        [ConstantName("current_date")]
        public Expression GetCurrentDate()
        {
            return Expression.Property(Expression.Property(null, this.now), "Date");
        }


        [ConstantName("current_utc_date")]
        public Expression GetCurrentUtcDate()
        {
            return Expression.Property(Expression.Property(null, this.utcNow), "Date");
        }

        [ConstantName("$current_timestamp")]
        public Expression GetCurrentTimestamp()
        {
            return Expression.Property(null, this.now);
        }


        [ConstantName("current_utc_timestamp")]
        public Expression GetCurrentUtcTimestamp()
        {
            return Expression.Property(null, this.utcNow);
        }


        private readonly PropertyInfo utcNow;
        private readonly PropertyInfo now;

    }

}
