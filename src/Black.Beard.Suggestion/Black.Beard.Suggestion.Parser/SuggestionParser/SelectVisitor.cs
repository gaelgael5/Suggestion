using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Linq.Expressions;
using Bb.Suggestion.Models;

namespace Bb.Suggestion.SuggestionParser
{

    public class SelectVisitor : Bb.Suggestion.SuggestionParser.SuggestionBaseVisitor<Expression>
    {
        
        public SelectVisitor()
        {
            this._result = new SuggestionQuerySelect();
        }

        public override Expression Visit(IParseTree tree)
        {
            return base.Visit(tree);
        }

        public override Expression VisitAny_name([NotNull] SuggestionParser.Any_nameContext context)
        {
            return base.VisitAny_name(context);
        }

        public override Expression VisitErrorNode(IErrorNode node)
        {
            return base.VisitErrorNode(node);
        }

        public override Expression VisitExpr([NotNull] SuggestionParser.ExprContext context)
        {
            return base.VisitExpr(context);
        }

        public override Expression VisitFunction_name([NotNull] SuggestionParser.Function_nameContext context)
        {
            var txt = context.any_name().IDENTIFIER().ToString();

            return base.VisitFunction_name(context);

        }

        public override Expression VisitLiteral_value([NotNull] SuggestionParser.Literal_valueContext context)
        {
            return base.VisitLiteral_value(context);
        }

        public override Expression VisitSelect_stmt([NotNull] SuggestionParser.Select_stmtContext context)
        {
            return base.VisitSelect_stmt(context);
        }

        public override Expression VisitSql_stmt([NotNull] SuggestionParser.Sql_stmtContext context)
        {
            return base.VisitSql_stmt(context);
        }

        public override Expression VisitSql_stmt_list([NotNull] SuggestionParser.Sql_stmt_listContext context)
        {
            return base.VisitSql_stmt_list(context);
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

        public override Expression VisitNumeric_literal([NotNull] SuggestionParser.Numeric_literalContext context)
        {
            return base.VisitNumeric_literal(context);
        }

        public override Expression VisitString_literal([NotNull] SuggestionParser.String_literalContext context)
        {
            return base.VisitString_literal(context);
        }

        public override Expression VisitUnary_operator([NotNull] SuggestionParser.Unary_operatorContext context)
        {
            return base.VisitUnary_operator(context);
        }




        public SuggestionQuery Result { get { return this._result; } }

        private readonly SuggestionQuerySelect _result;

    }

}
