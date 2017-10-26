using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Sdk.Expressions
{

    /// <summary>
    /// http://blogs.msdn.com/b/meek/archive/2008/05/02/linq-to-entities-combining-predicates.aspx
    /// </summary>
    public static class ExpressionExtension
    {

        /// <summary>
        /// Composes a new expression with the specified expressions.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <param name="merge">The merge.</param>
        /// <returns></returns>
        public static Expression<T> Compose<T>(this Expression<T> first, 
            Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        /// <summary>
        /// combine the specified expressions in new "and" logique expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        /// <summary>
        /// combine the specified expressions in new "and also" logique expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.AndAlso);
        }

        /// <summary>
        /// combine the specified expressions in "or" and logique expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.Or);
        }

        /// <summary>
        /// combine the specified expressions in "exclusive or" and logique expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first">The first.</param>
        /// <param name="second">The second.</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> ExclusiveOrr<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.ExclusiveOr);
        }

        /// <summary>
        /// Gets the member.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static MemberInfo GetMember<T, T1>(this Expression<Func<T, T1>> self)
        {
            System.Diagnostics.Contracts.Contract.Assert(self != null, "expression can'tbe null");
            return MemberFinder.Get<T, T1>(self);
        }

        /// <summary>
        /// Constants the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static ConstantExpression HasConstant(this object value)
        {

            return Expression.Constant(value);

        }

        /// <summary>
        /// Assigneds the left item with the value of the right item.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns></returns>
        public static Expression AssignedFrom(this Expression left, Expression right)
        {
            var result = Expression.Assign(left, right);
            return result;
        }

        /// <summary>
        /// Throws the specified n.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns></returns>
        public static UnaryExpression Throw(this Expression self)
        {
            return Expression.Throw(self);
        }

        /// <summary>
        /// resolve the constructor for the specified arguments and create a new object with the specified arguments.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        public static NewExpression New(this Type type, params dynamic[] arguments)
        {

            var c1 = type.GetCtor(arguments);

            var constants = new List<Expression>();
            foreach (var item in arguments)
            {
                Expression e = item as Expression;
                if (e == null)
                    e = Expression.Constant(item);
                constants.Add(e);
            }

            NewExpression n = Expression.New(c1, constants.ToArray());

            return n;

        }


        /// <summary>
        /// resolve the type of the arguments and with them resolve the constructor.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        public static ConstructorInfo GetCtor(this Type type, params dynamic[] arguments)
        {
            var types = ResolveTypes(arguments);
            var ctor = typeof(Exception).GetConstructor(types);
            return ctor;
        }

        /// <summary>
        /// for the specified items,
        /// if the items are an expression resolves the type in this
        /// or return the type of the instance.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public static Type[] ResolveTypes(params dynamic[] args)
        {
            var ty = args
                .Select(c => ResolveType(c))
                .Cast<Type>()
                .ToArray();
            return ty;
        }

        /// <summary>
        /// for the specified item,
        /// if the item is an expression resolves the type in this
        /// or return the type of the instance.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public static Type ResolveType(dynamic item)
        {

            Expression e = item as Expression;
            if (e == null)
                return item.GetType();

            return TypeFinder.Get(e);

        }

        #region Resolve Type

        class TypeFinder : ExpressionVisitor
        {

            private Type result;

            /// <summary>
            /// Gets the member embedded in the specified expression
            /// </summary>
            /// <param name="self">The self.</param>
            /// <returns></returns>
            internal static Type Get(Expression self)
            {
                TypeFinder visitor = new TypeFinder();
                visitor.Visit(self);
                return visitor.result;
            }

            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                if (result == null)
                    result = node.Type;
                return base.VisitLambda<T>(node);
            }

            //protected override Expression VisitDynamic(DynamicExpression node)
            //{
            //    if (result == null)
            //        result = node.Type;
            //    return base.VisitDynamic(node);
            //}

            protected override Expression VisitParameter(ParameterExpression node)
            {
                if (result == null)
                    result = node.Type;

                return base.VisitParameter(node);
            }
            protected override Expression VisitNew(NewExpression node)
            {
                if (result == null)
                    result = node.Type;
                return base.VisitNew(node);
            }
            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                if (result == null)
                    result = node.Method.ReturnType;

                return base.VisitMethodCall(node);
            }
            protected override Expression VisitDefault(DefaultExpression node)
            {
                if (result == null)
                    result = node.Type;

                return base.VisitDefault(node);
            }
            protected override Expression VisitConstant(ConstantExpression node)
            {

                if (result == null && node.Value != null)
                    result = node.Value.GetType();

                return base.VisitConstant(node);
            }
            protected override Expression VisitConditional(ConditionalExpression node)
            {
                if (result == null)
                    result = typeof(bool);
                return base.VisitConditional(node);
            }
            protected override Expression VisitBinary(BinaryExpression node)
            {

                if (result == null)
                {

                    switch (node.NodeType)
                    {
                        case ExpressionType.Add:
                            break;
                        case ExpressionType.AddAssign:
                            break;
                        case ExpressionType.AddAssignChecked:
                            break;
                        case ExpressionType.AddChecked:
                            break;
                        case ExpressionType.And:
                        case ExpressionType.AndAlso:
                        case ExpressionType.AndAssign:
                        case ExpressionType.Equal:
                        case ExpressionType.ExclusiveOr:
                        case ExpressionType.GreaterThan:
                        case ExpressionType.GreaterThanOrEqual:
                        case ExpressionType.IsFalse:
                        case ExpressionType.IsTrue:
                        case ExpressionType.LessThan:
                        case ExpressionType.LessThanOrEqual:
                        case ExpressionType.Or:
                        case ExpressionType.OrAssign:
                        case ExpressionType.Negate:
                        case ExpressionType.NegateChecked:
                        case ExpressionType.Not:
                        case ExpressionType.NotEqual:
                        case ExpressionType.OrElse:
                        case ExpressionType.TypeEqual:
                        case ExpressionType.TypeIs:
                            result = typeof(bool);
                            break;

                        default:
                            break;
                    }

                }

                return base.VisitBinary(node);
            }
            protected override Expression VisitMember(MemberExpression node)
            {
                if (result == null)
                {
                    var i = node.Member;

                    switch (i.MemberType)
                    {
                        case MemberTypes.Constructor:
                            result = (i as ConstructorInfo).DeclaringType;
                            break;
                        case MemberTypes.Event:
                            result = (i as EventInfo).EventHandlerType;
                            break;
                        case MemberTypes.Field:
                            result = (i as FieldInfo).FieldType;
                            break;
                        case MemberTypes.Method:
                            result = (i as MethodInfo).ReturnType;
                            break;
                        case MemberTypes.NestedType:
                            result = (i as Type);

                            break;
                        case MemberTypes.Property:
                            result = (i as PropertyInfo).PropertyType;
                            break;
                        case MemberTypes.TypeInfo:
                            result = (i as Type);
                            break;
                        default:
                            break;
                    }
                }

                return base.VisitMember(node);

            }

        }

        #endregion Resolve Type


    }


}
