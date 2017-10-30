using Bb.Sdk.Factories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Expressions
{
    public static partial class ExpressionExtension
    {

        public static object GetValue(this Expression e)
        {

            switch (e)
            {

                case MemberExpression c:
                    if (c.Type == typeof(object))
                        return Expression.Lambda<Func<object>>(c).Compile();
                    else
                        return Expression.Lambda<Func<object>>(Expression.Convert(c, typeof(object))).Compile();

                case ConstantExpression c:
                    return c.Value;

                case NewArrayExpression c:
                    return CompileArray(c);

                default:
                    if (System.Diagnostics.Debugger.IsAttached)
                        System.Diagnostics.Debugger.Break();
                    break;
            }

            return null;

        }

        private static object CompileArray(NewArrayExpression c)
        {
            int length = c.Expressions.Count;
            var ctor = c.Type.GetConstructor(new Type[] { typeof(int) });
            var activator = ObjectCreator.GetActivator<Array>(ctor);

            var myArray = activator(length);

            for (int index = 0; index < length; index++)
            {
                var item = c.Expressions[index];
                var value = GetValue(item);
                myArray.SetValue(value, index);
            }

            return myArray;

        }


    }

}
