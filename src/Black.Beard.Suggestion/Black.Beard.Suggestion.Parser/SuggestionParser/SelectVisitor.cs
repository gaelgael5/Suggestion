using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Linq.Expressions;
using Bb.Suggestion.Models;
using Bb.Sdk.Expressions;
using Bb.Suggestion.Service;
using System.Globalization;
using System.Data;
using Bb.Sdk.Factories;
using Bb.Expressions;
using System.Linq;

namespace Bb.Suggestion.SuggestionParser
{

    public partial class SelectVisitor<TEntitie> : Bb.Suggestion.SuggestionParser.SuggestionBaseVisitor<Expression>
         where TEntitie : ISuggerableModel
    {

        public SelectVisitor(QueryContext<TEntitie> context)
        {
            this._context = context;
            this._result = new SuggestionQuerySelect();
            this._dic = new Dictionary<string, parameter>();
        }

        public override Expression VisitAny_name([NotNull] SuggestionParser.Any_nameContext context)
        {
            return base.VisitAny_name(context);
        }

        public override Expression VisitErrorNode(IErrorNode node)
        {
            return base.VisitErrorNode(node);
        }

        public override Expression VisitFunction_args_stmt([NotNull] SuggestionParser.Function_args_stmtContext context)
        {
            //context.expr
            return base.VisitFunction_args_stmt(context);
        }

        public override Expression VisitFunction_stmt([NotNull] SuggestionParser.Function_stmtContext context)
        {

            RuleInfo rule;
            MethodCallExpression methodCallExpression;
            parameter p;
            string ruleName = context.function_name().GetText();
            Type[] _types = new Type[0];
            object[] _values = new object[0];

            var args = context.function_args_stmt();
            if (args != null)
            {

                var __args = args.expr();
                int length = __args.Length;
                _types = new Type[length];
                _values = new object[length];

                Expression[] _args = new Expression[length];
                for (int index = 0; index < length; index++)
                {
                    var expr = __args[index];
                    var _e = this.Visit(expr);
                    _args[index] = _e;
                    _types[index] = _e.Type;
                    _values[index] = _e.GetValue();
                }

                rule = this._context.Factory.ResolveRule(ruleName, _types);
                p = GetParameter("arg_" + ruleName, _values, rule);
                if (p.Tardive)
                {
                    //Expression i = p.Constant.Type == rule.Type
                    //        ? (Expression)p.Variable
                    //        : Expression.Convert(p.Variable, rule.Type);
                    methodCallExpression = Expression.Call(Expression.Convert(p.Variable, rule.Type), rule.Method, GetModelParameter());
                }
                else
                {
                    Expression i = p.Constant.Type == rule.Type
                            ? (Expression)p.Constant
                            : (Expression)Expression.Convert(p.Constant, rule.Type);

                    methodCallExpression = Expression.Call(i, rule.Method, GetModelParameter());
                }
                return methodCallExpression;

            }

            rule = this._context.Factory.ResolveRule(ruleName, new Type[] { });
            p = GetParameter("arg_" + ruleName, _values, rule);
            methodCallExpression = Expression.Call(Expression.Convert(p.Constant, rule.Type), rule.Method, GetModelParameter());

            return methodCallExpression;

        }

        /// <summary>
        /// Determines one of arguments is function.
        /// if true, the specification be re-created every time for evaluation
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>
        ///   <c>true</c> if the specified arguments is tardive; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsTardive(object[] args)
        {
            for (int i = 0; i < args.Length; i++)
                if (args[i] is Func<object> r)
                    return true;
            return false;
        }

        private ParameterExpression GetModelParameter()
        {
            if (this.argumentModel == null)
                this.argumentModel = Expression.Parameter(typeof(TEntitie), "model");
            return this.argumentModel;
        }

        private parameter GetParameter(string argName, object[] _values, RuleInfo rule)
        {

            parameter p;

            if (!this._dic.TryGetValue(argName, out p))
            {
                bool tardive = IsTardive(_values);
                Func<ISpecification<TEntitie>> s = this._context.Factory.Get(rule, _values);
                p = p = new parameter(argName, s, tardive, rule);
                this._dic.Add(argName, p);
            }

            return p;

        }

        public override Expression VisitWhere_stmt([NotNull] SuggestionParser.Where_stmtContext context)
        {
            this._result.Where = new SuggestionQueryFilter();
            var result = base.VisitWhere_stmt(context);
            this._result.Where = new SuggestionQueryFilter()
            {
                FilterExpression = result,
                ArgumentModel = GetModelParameter(),
                Parameters = this._dic.Values
                .Where(c => c.Tardive)
                .Select(c => new KeyValuePair<string, object>(c.Name, c.Specification))
                .ToList(),
            };
            return result;
        }

        public override Expression VisitExpr([NotNull] SuggestionParser.ExprContext context)
        {

            var binary = context.binary_operator();
            if (binary != null)
            {

                var e = context.expr();

                var left = this.Visit(e[0]);
                var right = this.Visit(e[1]);

                var p = binary.GetText();
                switch (p)
                {
                    case "&":
                        return Expression.And(left, right);
                    case "&&":
                        return Expression.AndAlso(left, right);
                    case "|":
                        return Expression.Or(left, right);
                    case "||":
                        return Expression.OrElse(left, right);
                    default:
                        if (System.Diagnostics.Debugger.IsAttached)
                            System.Diagnostics.Debugger.Break();
                        throw new NotImplementedException($"binary operator {p} not emplemented in expressionVisitor");
                }

            }

            return base.VisitExpr(context);

        }

        public override Expression VisitUnary_operator_expr([NotNull] SuggestionParser.Unary_operator_exprContext context)
        {

            var _operator = context.unary_operator().GetText();
            var expr = context.expr();
            var expression = this.Visit(expr);
            switch (_operator)
            {
                case "!":
                    return Expression.Not(expression);
                default:
                    if (System.Diagnostics.Debugger.IsAttached)
                        System.Diagnostics.Debugger.Break();
                    throw new NotImplementedException($"unary operator {_operator} not emplemented in expressionVisitor");
            }


        }

        public override Expression VisitSub_expr([NotNull] SuggestionParser.Sub_exprContext context)
        {
            var r = this.Visit(context.expr());
            return r;
        }

        public override Expression VisitBind_parameter([NotNull] SuggestionParser.Bind_parameterContext context)
        {
            return base.VisitBind_parameter(context);
        }

        public override Expression VisitBoolean_binary_operator([NotNull] SuggestionParser.Boolean_binary_operatorContext context)
        {
            return base.VisitBoolean_binary_operator(context);
        }

        public override Expression VisitVariable([NotNull] SuggestionParser.VariableContext context)
        {
            return base.VisitVariable(context);
        }

        public override Expression VisitConstant([NotNull] SuggestionParser.ConstantContext context)
        {

            var txt = context.GetText();

            var result = this._context.Factory.ResolveConstant(txt);
            if (result == null)
                throw new MissingMemberException(txt);

            return result;

        }

        public override Expression VisitNumeric_binary_operator([NotNull] SuggestionParser.Numeric_binary_operatorContext context)
        {
            return base.VisitNumeric_binary_operator(context);
        }

        public override Expression VisitNumeric_double_literal([NotNull] SuggestionParser.Numeric_double_literalContext context)
        {
            double dbl;
            var txt = context.GetText();
            if (double.TryParse(txt, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out dbl))
                return Expression.Constant(dbl);
            throw new InvalidCastException($"the value '{txt}' can't be casted in (double or decimal)");
        }

        public override Expression VisitNumeric_integer_literal([NotNull] SuggestionParser.Numeric_integer_literalContext context)
        {
            long _long;
            var txt = context.GetText();
            if (long.TryParse(txt, NumberStyles.Integer, CultureInfo.InvariantCulture, out _long))
            {
                if (_long < int.MaxValue)
                    return Expression.Constant((int)_long);

                return Expression.Constant(_long);

            }
            throw new InvalidCastException($"the value '{txt}' can't be casted in (integer or long)");
        }

        public override Expression VisitArray_expr([NotNull] SuggestionParser.Array_exprContext context)
        {

            Type type = null;
            Expression[] items = new Expression[0];
            int length = 0;
            var expr = context.literal();
            if (expr != null)
            {
                length = expr.Length;
                items = new Expression[length];
                for (int i = 0; i < length; i++)
                {

                    var e = expr[i];
                    var _expr = this.Visit(e);
                    items[i] = _expr;
                    if (type != null)
                    {
                        if (type != _expr.Type)
                            throw new SyntaxErrorException("array items nust be same type.");
                    }
                    else
                        type = _expr.Type;
                }
            }

            var result = Expression.NewArrayInit(type, items);

            return result;

        }

        public override Expression VisitString_literal([NotNull] SuggestionParser.String_literalContext context)
        {
            var t = context.GetText();
            if (string.IsNullOrEmpty(t))
                return Expression.Constant(string.Empty);
            return Expression.Constant(t.Substring(1, t.Length - 2));

        }

        public override Expression VisitChar_literal([NotNull] SuggestionParser.Char_literalContext context)
        {
            var t = context.GetText();
            if (t.Length > 3)
            {

            }
            return Expression.Constant(t[1]);
        }

        public override Expression VisitFacet_stmt([NotNull] SuggestionParser.Facet_stmtContext context)
        {
            return base.VisitFacet_stmt(context);
        }

        public override Expression VisitIdentifier_stmt([NotNull] SuggestionParser.Identifier_stmtContext context)
        {
            return base.VisitIdentifier_stmt(context);
        }

        public override Expression VisitOrder_stmt([NotNull] SuggestionParser.Order_stmtContext context)
        {
            return base.VisitOrder_stmt(context);
        }



        public SuggestionQuery Result { get { return this._result; } }

        public QueryContext<TEntitie> _context { get; }

        private readonly SuggestionQuerySelect _result;
        private Dictionary<string, parameter> _dic;
        private ParameterExpression argumentModel;
        private HashSet<parameter> _rules;
    }

}
