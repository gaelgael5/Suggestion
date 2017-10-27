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

namespace Bb.Suggestion.SuggestionParser
{

    public class SelectVisitor<TEntitie> : Bb.Suggestion.SuggestionParser.SuggestionBaseVisitor<Expression>
         where TEntitie : ISuggerableModel
    {

        public SelectVisitor(QueryContext<TEntitie> context)
        {
            this._context = context;
            this._result = new SuggestionQuerySelect();
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

            string ruleName = context.function_name().any_name().IDENTIFIER().GetText();
            Type[] _types = new Type[0];
            object[] _values = new object[0];

            var args = context.function_args_stmt();
            if (args != null)
            {

                var __args = args.expr();
                int length = __args.Length;
                _types = new Type[length];
                Expression[] _args = new Expression[length];
                for (int index = 0; index < length; index++)
                {
                    var expr = __args[index];
                    var _e = this.Visit(expr);
                    _args[index] = _e;
                    _types[index] = _e.Type;
                }

                RuleInfo rule = this._context.Factory.Resolve(ruleName, _types);

                var e = Expression.Call(rule.Method, _args);

                ISpecification<TEntitie> specification = this._context.Factory.Get(rule, _values);

            }
            else
            {

                RuleInfo rule = this._context.Factory.Resolve(ruleName, new Type[] { });

                var e = Expression.Call(rule.Method);

                ISpecification<TEntitie> specification = this._context.Factory.Get(rule, _values);

            }

            return base.VisitFunction_stmt(context);

        }

        public override Expression VisitSelect_stmt([NotNull] SuggestionParser.Select_stmtContext context)
        {
            return base.VisitSelect_stmt(context);
        }

        public override Expression VisitStmt_list([NotNull] SuggestionParser.Stmt_listContext context)
        {
            return base.VisitStmt_list(context);
        }

        public override Expression VisitStmt_line([NotNull] SuggestionParser.Stmt_lineContext context)
        {
            return base.VisitStmt_line(context);
        }

        public override Expression VisitWhere_stmt([NotNull] SuggestionParser.Where_stmtContext context)
        {
            this._result.Filter = new SuggestionQueryFilter();
            return base.VisitWhere_stmt(context);
        }

        public override Expression VisitBinary_operator([NotNull] SuggestionParser.Binary_operatorContext context)
        {
            return base.VisitBinary_operator(context);
        }

        public override Expression VisitBind_parameter([NotNull] SuggestionParser.Bind_parameterContext context)
        {
            return base.VisitBind_parameter(context);
        }
     
        public override Expression VisitBoolean_binary_operator([NotNull] SuggestionParser.Boolean_binary_operatorContext context)
        {
            return base.VisitBoolean_binary_operator(context);
        }

        public override Expression VisitConstant_literal_value([NotNull] SuggestionParser.Constant_literal_valueContext context)
        {
            return base.VisitConstant_literal_value(context);
        }

        public override Expression VisitNumeric_binary_operator([NotNull] SuggestionParser.Numeric_binary_operatorContext context)
        {
            return base.VisitNumeric_binary_operator(context);
        }

        public override Expression VisitNumeric_double_literal([NotNull] SuggestionParser.Numeric_double_literalContext context)
        {
            double dbl;
            var txt = context.GetText();
            if (double.TryParse(txt , NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out dbl))
                return Expression.Constant(dbl);
            throw new InvalidCastException($"the value '{txt}' can't be casted in (double or decimal)");
        }

        public override Expression VisitNumeric_integer_literal([NotNull] SuggestionParser.Numeric_integer_literalContext context)
        {
            long _long;
            var txt = context.GetText();
            if (long.TryParse(txt, NumberStyles.Integer, CultureInfo.InvariantCulture, out _long))
                return Expression.Constant(_long);
            throw new InvalidCastException($"the value '{txt}' can't be casted in (integer or long)");
        }

        public override Expression VisitString_literal([NotNull] SuggestionParser.String_literalContext context)
        {
            var t = context.GetText();
            return Expression.Constant(t);
        }

        public override Expression VisitNumeric_literal_expr([NotNull] SuggestionParser.Numeric_literal_exprContext context)
        {
            return base.VisitNumeric_literal_expr(context);
        }

        public override Expression VisitUnary_operator([NotNull] SuggestionParser.Unary_operatorContext context)
        {
            return base.VisitUnary_operator(context);
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

    }

}
