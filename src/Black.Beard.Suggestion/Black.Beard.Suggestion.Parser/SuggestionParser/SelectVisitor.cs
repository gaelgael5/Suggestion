using Bb.Specifications;
using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Antlr4.Runtime.Misc;
using System.Linq.Expressions;
using System.Globalization;
using Bb.Specifications.Leafs;
using System.Reflection;
using Bb.Exceptions;
using Bb.Sdk;
using Bb.Sdk.Expressions;

namespace Bb.Suggestion.SuggestionParser
{

    public class SelectVisitor<TEntity> : SuggestionBaseVisitor<Expression>
         where TEntity : ISuggerableModel
    {


        #region ctor

        static SelectVisitor()
        {

            SelectVisitor<TEntity>.SpecificationLeafAnd = typeof(SpecificationLeafAnd<TEntity>).GetConstructor(new Type[] { typeof(ISpecification<TEntity>), typeof(ISpecification<TEntity>) });
            SelectVisitor<TEntity>.SpecificationLeafOr = typeof(SpecificationLeafOr<TEntity>).GetConstructor(new Type[] { typeof(ISpecification<TEntity>), typeof(ISpecification<TEntity>) });
            SelectVisitor<TEntity>.SpecificationLeafNot = typeof(SpecificationLeafNot<TEntity>).GetConstructor(new Type[] { typeof(ISpecification<TEntity>) });
            SelectVisitor<TEntity>._comparer = StringComparer.InvariantCultureIgnoreCase;

        }


        /// <summary>
        /// Initializes a new instance of the <see cref="SelectVisitor{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="DuplicateNameException"></exception>
        public SelectVisitor(QueryContext<TEntity> context)
        {

            this._context = context;
            this._dic = new Dictionary<string, _Expression_parameter>();
            this._parameters = new Dictionary<string, QueryParameter>(this._context.Parameters.Count());
            this._usedParameters = new HashSet<QueryParameter>();

            foreach (SuggestionQueryParameter parameter in this._context.Parameters)
            {

                parameter.Name = parameter.Name.ToLower();

                if (this._parameters.ContainsKey(parameter.Name))
                    throw new DuplicateNameException($"binded paramameter {parameter.Name}");

                this._parameters.Add(parameter.Name, new QueryParameter(parameter));

            }

        }

        #endregion ctor

        public override Expression VisitStmt_Set_globalParameter([NotNull] SuggestionParser.Stmt_Set_globalParameterContext context)
        {

            var name = context.any_name();
            if (name == null)
                throw new InternalServerException("variable name can't be evaluated can't be evaluated");

            string _name = name.GetText();

            var value = context.stmt_Set_globalParameter_literal();
            var e = this.Visit(value);

            if (e == null)
                throw new InternalServerException("value can't be evaluated");

            var c = e as ConstantExpression;

            if (c == null)
                throw new InternalServerException("value is not a constant");

            this._context.Factory.SetVariable(_name, c.Value);

            ExecutedQuery query = new ExecutedQuery($"global parameter '{_name}' has been setted");
            this._result = query;

            return null;

        }

        public override Expression VisitStmt_Del_globalParameter([NotNull] SuggestionParser.Stmt_Del_globalParameterContext context)
        {

            var name = context.any_name();
            if (name == null)
                throw new InternalServerException("variable name can't be evaluated can't be evaluated");

            string _name = name.GetText();

            var result = this._context.Factory.DelVariable(_name);

            ExecutedQuery query = new ExecutedQuery(
                result 
                    ? $"global parameter '{_name}' has been deleted" 
                    : $"global parameter '{_name}' was not found"
            );
            this._result = query;

            return null;

        }

        public override Expression VisitStmt_show([NotNull] SuggestionParser.Stmt_showContext context)
        {

            var _name = context.any_name().Select(c => c.GetText()).ToArray();
            string name = string.Empty;


            var result = new ShowSuggestionQuery(_name[0].ToUpper())
            {

            };

            switch (result.ObjectName)
            {

                case "METHODS":
                    result.Datas = this._context.Factory.Rules();
                    break;

                case "METHOD":
                    if (_name.Length == 1)
                        throw new SyntaxErrorException($"SHOW METHOD must to have a method name. for get a complet list of constants, please concidere 'SHOW METHODS'");
                    name = _name[1];
                    result.Datas = this._context.Factory.Rules().Where(c => SelectVisitor<TEntity>._comparer.Compare(c.Name, name) == 0).ToList();
                    break;

                case "CONSTANTS":
                    result.Datas = this._context.Factory.Constants();
                    break;

                case "CONSTANT":
                    if (_name.Length == 1)
                        throw new SyntaxErrorException($"SHOW CONSTANT must to have a constant name. for get a complet list of constants, please concidere 'SHOW CONSTANTS'");
                    name = _name[1];
                    if (!name.StartsWith("$"))
                        name = "$" + name;
                    result.Datas = this._context.Factory.Constants().Where(c => SelectVisitor<TEntity>._comparer.Compare(c.Key, name) == 0).ToList();
                    break;

                case "PARAMETERS":
                    result.Datas = this._context.Factory.Variables();
                    break;

                case "PARAMETER":
                    if (_name.Length == 1)
                        throw new SyntaxErrorException($"SHOW PARAMETER must to have a global parameter name. for get a complet list of constants, please concidere 'SHOW PARAMETERS'");
                    name = _name[1];
                    var data = this._context.Factory.ResolveVariable(name);
                    if (data != null)
                        result.Datas = new List<GlobalParameter>() { data };
                    else
                        result.Datas = new List<GlobalParameter>() {  };
                    break;

                default:
                    throw new SyntaxErrorException($"'{result.ObjectName}' is not recognized type object in 'SHOW' statment.");
            }

            this._result = result;

            return null;

        }

        public override Expression VisitWhere_stmt([NotNull] SuggestionParser.Where_stmtContext context)
        {

            var result = base.VisitWhere_stmt(context);

            List<Expression> lst = new List<Expression>();
            ParameterExpression arg = Expression.Parameter(typeof(object[]), "arg");

            int _index = 0;
            ParameterExpression[] _pTarget = new ParameterExpression[this._usedParameters.Count];
            foreach (QueryParameter parameter in this._usedParameters)
            {

                Expression index = Expression.Constant(_index);
                _pTarget[_index] = parameter.Expression;

                Expression paramAccessorExp = Expression.ArrayIndex(arg, index);
                Expression paramCastExp = Expression.Convert(paramAccessorExp, parameter.Expression.Type);

                var u = Expression.Assign(parameter.Expression, paramCastExp);

                lst.Add(u);

                _index++;

            }

            lst.Add(result);

            var blk = Expression.Block(_pTarget, lst.ToArray());

            var lbd = Expression.Lambda<Func<object[], ISpecification<TEntity>>>(blk, arg);

            this._result = new SuggestionQuerySelect<TEntity>()
            {
                Where = new SuggestionWhere<TEntity>(lbd.Compile(), this._usedParameters.Select(c => new WhereQueryParameter() { Name = c.Name, Type = c.Expression.Type })),
            };

            return null;

        }


        #region Subs
        
        public override Expression VisitFunction_stmt([NotNull] SuggestionParser.Function_stmtContext context)
        {

            RuleInfo rule;
            string ruleName = context.function_name().GetText();
            Type[] _types = new Type[0];
            Expression[] _expression_values = new Expression[0];
            _Expression_parameter p;

            var args = context.function_args_stmt();
            if (args != null)
            {

                var __args = args.expr();
                int length = __args.Length;
                _types = new Type[length];

                StringBuilder sb = new StringBuilder();
                _expression_values = new Expression[length];
                for (int index = 0; index < length; index++)
                {
                    var expr = __args[index];
                    var _e = this.Visit(expr);
                    _expression_values[index] = _e;
                    _types[index] = _e.Type;
                    sb.Append(GetKeyText(_e));
                }

                rule = this._context.Factory.ResolveRule(ruleName, _types);
                string _n = $"arg_{ruleName}_{sb.ToString().GetHashCode()}";
                p = GetParameter(_n, _expression_values, rule);

                return p.Expression;

            }

            rule = this._context.Factory.ResolveRule(ruleName, new Type[] { });
            p = GetParameter("arg_" + ruleName, _expression_values, rule);

            return p.Expression;

        }

        public override Expression VisitDatetime_expr([NotNull] SuggestionParser.Datetime_exprContext context)
        {

            string mask = string.Empty;
            CultureInfo culture = CultureInfo.InvariantCulture;
            string date = context.Datetime().GetText();
            DateTime dte;

            try
            {

                date = date.Substring(1, date.Length - 2);
                var _mask = context.datetime_mask();

                if (_mask != null)
                {
                    mask = _mask.GetText();
                    mask = mask.Substring(1, mask.Length - 2);
                }

                var _culture = context.datetime_culture();
                if (_culture != null)
                {
                    string __culture = _culture.GetText();
                    __culture = __culture.Substring(1, __culture.Length - 2);

                    culture = CultureInfo.GetCultureInfo(__culture);
                }

                if (string.IsNullOrEmpty(mask))
                    dte = DateTime.Parse(date, culture);

                else
                    dte = DateTime.ParseExact(date, mask, culture);

                return Expression.Constant(dte);

            }
            catch (FormatException e)
            {
                if (string.IsNullOrEmpty(mask))
                    throw new FormatException($"{date} at position {context.Start.StartIndex} ({context.Start.Line}:{context.Start.Column})");
                else
                    throw new FormatException($"{date} -> '{mask}' '{culture.Name}' at position {context.Start.StartIndex} ({context.Start.Line}:{context.Start.Column})");
            }

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
                    case "&&":
                        return Expression.New(SelectVisitor<TEntity>.SpecificationLeafAnd, left, right);

                    case "|":
                    case "||":
                        return Expression.New(SelectVisitor<TEntity>.SpecificationLeafOr, left, right);

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
                    return Expression.New(SelectVisitor<TEntity>.SpecificationLeafNot, expression);

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
            QueryParameter parameter;
            var binded_parameter_name = context.GetText().ToLower();
            if (!this._parameters.TryGetValue(binded_parameter_name, out parameter))
                throw new KeyNotFoundException($"{binded_parameter_name} at position {context.Start.StartIndex} ({context.Start.Line}:{context.Start.Column}). ");


            this._usedParameters.Add(parameter);
            return parameter.Expression;

        }

        public override Expression VisitConstant([NotNull] SuggestionParser.ConstantContext context)
        {

            var txt = context.GetText();

            var result = this._context.Factory.ResolveConstant(txt);
            if (result == null)
                throw new MissingMemberException(txt);

            return result;

        }

        public override Expression VisitVariable([NotNull] SuggestionParser.VariableContext context)
        {
            var varName = context.GetText();
            var e = this._context.Factory.GetVariableExpression(varName);
            return e;
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

        public override Expression VisitString_literal_expr([NotNull] SuggestionParser.String_literal_exprContext context)
        {
            var t = context.GetText();
            if (string.IsNullOrEmpty(t))
                return Expression.Constant(string.Empty);
            return Expression.Constant(t.Substring(1, t.Length - 2));

        }

        public override Expression VisitChar_literal_expr([NotNull] SuggestionParser.Char_literal_exprContext context)
        {
            var t = context.GetText();
            if (t.Length > 3)
                throw new SyntaxErrorException($"invalid char expression '{t}'");
            return Expression.Constant(t[1]);
        }

        #endregion Subs




        public SuggestionQuery Result { get { return this._result; } }


        #region private

        private readonly QueryContext<TEntity> _context;
        private SuggestionQuery _result;
        private readonly Dictionary<string, _Expression_parameter> _dic;
        private readonly Dictionary<string, QueryParameter> _parameters;
        private readonly static ConstructorInfo SpecificationLeafAnd;
        private readonly static ConstructorInfo SpecificationLeafOr;
        private readonly static ConstructorInfo SpecificationLeafNot;
        private static readonly StringComparer _comparer;
        private HashSet<QueryParameter> _usedParameters;

        private _Expression_parameter GetParameter(string argName, Expression[] _expression_values, RuleInfo rule)
        {

            _Expression_parameter p;

            if (!this._dic.TryGetValue(argName, out p))
            {
                p = _Expression_parameter.Create<TEntity>(argName, rule, _expression_values);
                this._dic.Add(argName, p);
            }

            return p;

        }

        private static string GetKeyText(Expression e)
        {

            switch (e)
            {

                case ParameterExpression c:
                    return c.Name;

                case MemberExpression c:
                    return c.Member.Name;

                case ConstantExpression c:
                    return c.Value.ToString();

                case NewArrayExpression c:
                    return GetKeyText(c);

                case MethodCallExpression m:
                    var i = ConstantFinder.Get(m);
                    if (i != null)
                        return i;
                    return m.Method.ToString();

                case UnaryExpression u:
                    return GetKeyText(u.Operand);

                default:
                    if (System.Diagnostics.Debugger.IsAttached)
                        System.Diagnostics.Debugger.Break();
                    break;
            }

            return null;

        }


        private static string GetKeyText(NewArrayExpression c)
        {
            int length = c.Expressions.Count;
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            for (int index = 0; index < length; index++)
            {
                var item = c.Expressions[index];
                var value = GetKeyText(item);
                sb.Append(value);
                sb.Append(", ");
            }
            sb.Append("}");
            return sb.ToString();
        }

        #endregion private


    }
}
