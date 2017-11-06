// Generated from c:\github\Suggestion\src\Black.Beard.Suggestion\Black.Beard.Suggestion.Parser\grammar\Suggestion.g4 by ANTLR 4.7
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.misc.*;
import org.antlr.v4.runtime.tree.*;
import java.util.List;
import java.util.Iterator;
import java.util.ArrayList;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class SuggestionParser extends Parser {
	static { RuntimeMetaData.checkVersion("4.7", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, AND=22, ANDALSO=23, OR=24, XOR=25, 
		NOT=26, K_ALL=27, DIGIT=28, IDENTIFIER=29, COMMENT_INPUT=30, LINE_COMMENT=31, 
		Char_literal=32, String_literal=33, Datetime=34;
	public static final int
		RULE_stmt_list = 0, RULE_stmt_line = 1, RULE_stmt_show_methods = 2, RULE_stmt_Set_globalParameter = 3, 
		RULE_stmt_Get_globalParameter = 4, RULE_stmt_Del_globalParameter = 5, 
		RULE_select_stmt = 6, RULE_where_stmt = 7, RULE_order_stmt = 8, RULE_facet_stmt = 9, 
		RULE_function_stmt = 10, RULE_function_args_stmt = 11, RULE_identifier_stmt = 12, 
		RULE_bind_parameter = 13, RULE_constant = 14, RULE_variable = 15, RULE_numeric_literal = 16, 
		RULE_numeric_integer_literal = 17, RULE_numeric_double_literal = 18, RULE_binary_operator = 19, 
		RULE_unary_operator = 20, RULE_expr = 21, RULE_sub_expr = 22, RULE_unary_operator_expr = 23, 
		RULE_array_expr = 24, RULE_literal = 25, RULE_function_name = 26, RULE_any_name = 27, 
		RULE_string_literal_expr = 28, RULE_char_literal_expr = 29, RULE_datetime_expr = 30;
	public static final String[] ruleNames = {
		"stmt_list", "stmt_line", "stmt_show_methods", "stmt_Set_globalParameter", 
		"stmt_Get_globalParameter", "stmt_Del_globalParameter", "select_stmt", 
		"where_stmt", "order_stmt", "facet_stmt", "function_stmt", "function_args_stmt", 
		"identifier_stmt", "bind_parameter", "constant", "variable", "numeric_literal", 
		"numeric_integer_literal", "numeric_double_literal", "binary_operator", 
		"unary_operator", "expr", "sub_expr", "unary_operator_expr", "array_expr", 
		"literal", "function_name", "any_name", "string_literal_expr", "char_literal_expr", 
		"datetime_expr"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "';'", "'SHOW'", "'METHODS'", "'METHOD'", "'SET'", "'='", "'GET'", 
		"'DEL'", "'WHERE'", "'ORDER BY'", "'WITH FACETS'", "','", "'('", "')'", 
		"'.'", "':'", "'$'", "'@'", "'-'", "'['", "']'", "'&'", "'&&'", "'|'", 
		"'||'", "'!'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, "AND", "ANDALSO", 
		"OR", "XOR", "NOT", "K_ALL", "DIGIT", "IDENTIFIER", "COMMENT_INPUT", "LINE_COMMENT", 
		"Char_literal", "String_literal", "Datetime"
	};
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}

	@Override
	public String getGrammarFileName() { return "Suggestion.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public ATN getATN() { return _ATN; }

	public SuggestionParser(TokenStream input) {
		super(input);
		_interp = new ParserATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}
	public static class Stmt_listContext extends ParserRuleContext {
		public List<Stmt_lineContext> stmt_line() {
			return getRuleContexts(Stmt_lineContext.class);
		}
		public Stmt_lineContext stmt_line(int i) {
			return getRuleContext(Stmt_lineContext.class,i);
		}
		public Stmt_listContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stmt_list; }
	}

	public final Stmt_listContext stmt_list() throws RecognitionException {
		Stmt_listContext _localctx = new Stmt_listContext(_ctx, getState());
		enterRule(_localctx, 0, RULE_stmt_list);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(65);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__0) {
				{
				{
				setState(62);
				match(T__0);
				}
				}
				setState(67);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(68);
			stmt_line();
			setState(77);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(70); 
					_errHandler.sync(this);
					_la = _input.LA(1);
					do {
						{
						{
						setState(69);
						match(T__0);
						}
						}
						setState(72); 
						_errHandler.sync(this);
						_la = _input.LA(1);
					} while ( _la==T__0 );
					setState(74);
					stmt_line();
					}
					} 
				}
				setState(79);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			}
			setState(83);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__0) {
				{
				{
				setState(80);
				match(T__0);
				}
				}
				setState(85);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Stmt_lineContext extends ParserRuleContext {
		public Stmt_show_methodsContext stmt_show_methods() {
			return getRuleContext(Stmt_show_methodsContext.class,0);
		}
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Stmt_Set_globalParameterContext stmt_Set_globalParameter() {
			return getRuleContext(Stmt_Set_globalParameterContext.class,0);
		}
		public Stmt_Get_globalParameterContext stmt_Get_globalParameter() {
			return getRuleContext(Stmt_Get_globalParameterContext.class,0);
		}
		public Stmt_Del_globalParameterContext stmt_Del_globalParameter() {
			return getRuleContext(Stmt_Del_globalParameterContext.class,0);
		}
		public Stmt_lineContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stmt_line; }
	}

	public final Stmt_lineContext stmt_line() throws RecognitionException {
		Stmt_lineContext _localctx = new Stmt_lineContext(_ctx, getState());
		enterRule(_localctx, 2, RULE_stmt_line);
		try {
			setState(91);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__1:
				enterOuterAlt(_localctx, 1);
				{
				setState(86);
				stmt_show_methods();
				}
				break;
			case T__8:
				enterOuterAlt(_localctx, 2);
				{
				setState(87);
				select_stmt();
				}
				break;
			case T__4:
				enterOuterAlt(_localctx, 3);
				{
				setState(88);
				stmt_Set_globalParameter();
				}
				break;
			case T__6:
				enterOuterAlt(_localctx, 4);
				{
				setState(89);
				stmt_Get_globalParameter();
				}
				break;
			case T__7:
				enterOuterAlt(_localctx, 5);
				{
				setState(90);
				stmt_Del_globalParameter();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Stmt_show_methodsContext extends ParserRuleContext {
		public Function_nameContext function_name() {
			return getRuleContext(Function_nameContext.class,0);
		}
		public Stmt_show_methodsContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stmt_show_methods; }
	}

	public final Stmt_show_methodsContext stmt_show_methods() throws RecognitionException {
		Stmt_show_methodsContext _localctx = new Stmt_show_methodsContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_stmt_show_methods);
		try {
			setState(98);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,5,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(93);
				match(T__1);
				setState(94);
				match(T__2);
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(95);
				match(T__1);
				setState(96);
				match(T__3);
				setState(97);
				function_name();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Stmt_Set_globalParameterContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SuggestionParser.IDENTIFIER, 0); }
		public LiteralContext literal() {
			return getRuleContext(LiteralContext.class,0);
		}
		public Stmt_Set_globalParameterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stmt_Set_globalParameter; }
	}

	public final Stmt_Set_globalParameterContext stmt_Set_globalParameter() throws RecognitionException {
		Stmt_Set_globalParameterContext _localctx = new Stmt_Set_globalParameterContext(_ctx, getState());
		enterRule(_localctx, 6, RULE_stmt_Set_globalParameter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(100);
			match(T__4);
			setState(101);
			match(IDENTIFIER);
			setState(102);
			match(T__5);
			setState(103);
			literal();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Stmt_Get_globalParameterContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SuggestionParser.IDENTIFIER, 0); }
		public Stmt_Get_globalParameterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stmt_Get_globalParameter; }
	}

	public final Stmt_Get_globalParameterContext stmt_Get_globalParameter() throws RecognitionException {
		Stmt_Get_globalParameterContext _localctx = new Stmt_Get_globalParameterContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_stmt_Get_globalParameter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(105);
			match(T__6);
			setState(106);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Stmt_Del_globalParameterContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SuggestionParser.IDENTIFIER, 0); }
		public Stmt_Del_globalParameterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stmt_Del_globalParameter; }
	}

	public final Stmt_Del_globalParameterContext stmt_Del_globalParameter() throws RecognitionException {
		Stmt_Del_globalParameterContext _localctx = new Stmt_Del_globalParameterContext(_ctx, getState());
		enterRule(_localctx, 10, RULE_stmt_Del_globalParameter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(108);
			match(T__7);
			setState(109);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Select_stmtContext extends ParserRuleContext {
		public Where_stmtContext where_stmt() {
			return getRuleContext(Where_stmtContext.class,0);
		}
		public Order_stmtContext order_stmt() {
			return getRuleContext(Order_stmtContext.class,0);
		}
		public Facet_stmtContext facet_stmt() {
			return getRuleContext(Facet_stmtContext.class,0);
		}
		public Select_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_select_stmt; }
	}

	public final Select_stmtContext select_stmt() throws RecognitionException {
		Select_stmtContext _localctx = new Select_stmtContext(_ctx, getState());
		enterRule(_localctx, 12, RULE_select_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(111);
			where_stmt();
			setState(113);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__9) {
				{
				setState(112);
				order_stmt();
				}
			}

			setState(116);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__10) {
				{
				setState(115);
				facet_stmt();
				}
			}

			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Where_stmtContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public TerminalNode K_ALL() { return getToken(SuggestionParser.K_ALL, 0); }
		public Where_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_where_stmt; }
	}

	public final Where_stmtContext where_stmt() throws RecognitionException {
		Where_stmtContext _localctx = new Where_stmtContext(_ctx, getState());
		enterRule(_localctx, 14, RULE_where_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(118);
			match(T__8);
			setState(121);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__12:
			case T__15:
			case T__16:
			case T__17:
			case T__18:
			case T__19:
			case NOT:
			case DIGIT:
			case IDENTIFIER:
			case Char_literal:
			case String_literal:
			case Datetime:
				{
				setState(119);
				expr(0);
				}
				break;
			case K_ALL:
				{
				setState(120);
				match(K_ALL);
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Order_stmtContext extends ParserRuleContext {
		public Identifier_stmtContext identifier_stmt() {
			return getRuleContext(Identifier_stmtContext.class,0);
		}
		public Order_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_order_stmt; }
	}

	public final Order_stmtContext order_stmt() throws RecognitionException {
		Order_stmtContext _localctx = new Order_stmtContext(_ctx, getState());
		enterRule(_localctx, 16, RULE_order_stmt);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(123);
			match(T__9);
			setState(124);
			identifier_stmt();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Facet_stmtContext extends ParserRuleContext {
		public List<TerminalNode> IDENTIFIER() { return getTokens(SuggestionParser.IDENTIFIER); }
		public TerminalNode IDENTIFIER(int i) {
			return getToken(SuggestionParser.IDENTIFIER, i);
		}
		public Facet_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_facet_stmt; }
	}

	public final Facet_stmtContext facet_stmt() throws RecognitionException {
		Facet_stmtContext _localctx = new Facet_stmtContext(_ctx, getState());
		enterRule(_localctx, 18, RULE_facet_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(126);
			match(T__10);
			setState(127);
			match(IDENTIFIER);
			setState(132);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__11) {
				{
				{
				setState(128);
				match(T__11);
				setState(129);
				match(IDENTIFIER);
				}
				}
				setState(134);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Function_stmtContext extends ParserRuleContext {
		public Function_nameContext function_name() {
			return getRuleContext(Function_nameContext.class,0);
		}
		public Function_args_stmtContext function_args_stmt() {
			return getRuleContext(Function_args_stmtContext.class,0);
		}
		public Function_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_function_stmt; }
	}

	public final Function_stmtContext function_stmt() throws RecognitionException {
		Function_stmtContext _localctx = new Function_stmtContext(_ctx, getState());
		enterRule(_localctx, 20, RULE_function_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(135);
			function_name();
			setState(136);
			match(T__12);
			setState(138);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__12) | (1L << T__15) | (1L << T__16) | (1L << T__17) | (1L << T__18) | (1L << T__19) | (1L << NOT) | (1L << DIGIT) | (1L << IDENTIFIER) | (1L << Char_literal) | (1L << String_literal) | (1L << Datetime))) != 0)) {
				{
				setState(137);
				function_args_stmt();
				}
			}

			setState(140);
			match(T__13);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Function_args_stmtContext extends ParserRuleContext {
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Function_args_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_function_args_stmt; }
	}

	public final Function_args_stmtContext function_args_stmt() throws RecognitionException {
		Function_args_stmtContext _localctx = new Function_args_stmtContext(_ctx, getState());
		enterRule(_localctx, 22, RULE_function_args_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(142);
			expr(0);
			setState(147);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__11) {
				{
				{
				setState(143);
				match(T__11);
				setState(144);
				expr(0);
				}
				}
				setState(149);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Identifier_stmtContext extends ParserRuleContext {
		public List<TerminalNode> IDENTIFIER() { return getTokens(SuggestionParser.IDENTIFIER); }
		public TerminalNode IDENTIFIER(int i) {
			return getToken(SuggestionParser.IDENTIFIER, i);
		}
		public Identifier_stmtContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_identifier_stmt; }
	}

	public final Identifier_stmtContext identifier_stmt() throws RecognitionException {
		Identifier_stmtContext _localctx = new Identifier_stmtContext(_ctx, getState());
		enterRule(_localctx, 24, RULE_identifier_stmt);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(150);
			match(IDENTIFIER);
			setState(155);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__14) {
				{
				{
				setState(151);
				match(T__14);
				setState(152);
				match(IDENTIFIER);
				}
				}
				setState(157);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Bind_parameterContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SuggestionParser.IDENTIFIER, 0); }
		public Bind_parameterContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_bind_parameter; }
	}

	public final Bind_parameterContext bind_parameter() throws RecognitionException {
		Bind_parameterContext _localctx = new Bind_parameterContext(_ctx, getState());
		enterRule(_localctx, 26, RULE_bind_parameter);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(158);
			match(T__15);
			setState(159);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ConstantContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SuggestionParser.IDENTIFIER, 0); }
		public ConstantContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_constant; }
	}

	public final ConstantContext constant() throws RecognitionException {
		ConstantContext _localctx = new ConstantContext(_ctx, getState());
		enterRule(_localctx, 28, RULE_constant);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(161);
			match(T__16);
			setState(162);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class VariableContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SuggestionParser.IDENTIFIER, 0); }
		public VariableContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_variable; }
	}

	public final VariableContext variable() throws RecognitionException {
		VariableContext _localctx = new VariableContext(_ctx, getState());
		enterRule(_localctx, 30, RULE_variable);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(164);
			match(T__17);
			setState(165);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Numeric_literalContext extends ParserRuleContext {
		public Numeric_double_literalContext numeric_double_literal() {
			return getRuleContext(Numeric_double_literalContext.class,0);
		}
		public Numeric_integer_literalContext numeric_integer_literal() {
			return getRuleContext(Numeric_integer_literalContext.class,0);
		}
		public Numeric_literalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_numeric_literal; }
	}

	public final Numeric_literalContext numeric_literal() throws RecognitionException {
		Numeric_literalContext _localctx = new Numeric_literalContext(_ctx, getState());
		enterRule(_localctx, 32, RULE_numeric_literal);
		try {
			setState(169);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,13,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(167);
				numeric_double_literal();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(168);
				numeric_integer_literal();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Numeric_integer_literalContext extends ParserRuleContext {
		public List<TerminalNode> DIGIT() { return getTokens(SuggestionParser.DIGIT); }
		public TerminalNode DIGIT(int i) {
			return getToken(SuggestionParser.DIGIT, i);
		}
		public Numeric_integer_literalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_numeric_integer_literal; }
	}

	public final Numeric_integer_literalContext numeric_integer_literal() throws RecognitionException {
		Numeric_integer_literalContext _localctx = new Numeric_integer_literalContext(_ctx, getState());
		enterRule(_localctx, 34, RULE_numeric_integer_literal);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(172);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__18) {
				{
				setState(171);
				match(T__18);
				}
			}

			setState(175); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(174);
					match(DIGIT);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(177); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,15,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Numeric_double_literalContext extends ParserRuleContext {
		public List<TerminalNode> DIGIT() { return getTokens(SuggestionParser.DIGIT); }
		public TerminalNode DIGIT(int i) {
			return getToken(SuggestionParser.DIGIT, i);
		}
		public Numeric_double_literalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_numeric_double_literal; }
	}

	public final Numeric_double_literalContext numeric_double_literal() throws RecognitionException {
		Numeric_double_literalContext _localctx = new Numeric_double_literalContext(_ctx, getState());
		enterRule(_localctx, 36, RULE_numeric_double_literal);
		int _la;
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(180);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__18) {
				{
				setState(179);
				match(T__18);
				}
			}

			setState(183); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(182);
				match(DIGIT);
				}
				}
				setState(185); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==DIGIT );
			setState(187);
			match(T__14);
			setState(189); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(188);
					match(DIGIT);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(191); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,18,_ctx);
			} while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER );
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Binary_operatorContext extends ParserRuleContext {
		public TerminalNode AND() { return getToken(SuggestionParser.AND, 0); }
		public TerminalNode OR() { return getToken(SuggestionParser.OR, 0); }
		public TerminalNode ANDALSO() { return getToken(SuggestionParser.ANDALSO, 0); }
		public TerminalNode XOR() { return getToken(SuggestionParser.XOR, 0); }
		public Binary_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_binary_operator; }
	}

	public final Binary_operatorContext binary_operator() throws RecognitionException {
		Binary_operatorContext _localctx = new Binary_operatorContext(_ctx, getState());
		enterRule(_localctx, 38, RULE_binary_operator);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(193);
			_la = _input.LA(1);
			if ( !((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << AND) | (1L << ANDALSO) | (1L << OR) | (1L << XOR))) != 0)) ) {
			_errHandler.recoverInline(this);
			}
			else {
				if ( _input.LA(1)==Token.EOF ) matchedEOF = true;
				_errHandler.reportMatch(this);
				consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Unary_operatorContext extends ParserRuleContext {
		public TerminalNode NOT() { return getToken(SuggestionParser.NOT, 0); }
		public Unary_operatorContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary_operator; }
	}

	public final Unary_operatorContext unary_operator() throws RecognitionException {
		Unary_operatorContext _localctx = new Unary_operatorContext(_ctx, getState());
		enterRule(_localctx, 40, RULE_unary_operator);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(195);
			match(NOT);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class ExprContext extends ParserRuleContext {
		public LiteralContext literal() {
			return getRuleContext(LiteralContext.class,0);
		}
		public Array_exprContext array_expr() {
			return getRuleContext(Array_exprContext.class,0);
		}
		public Bind_parameterContext bind_parameter() {
			return getRuleContext(Bind_parameterContext.class,0);
		}
		public Sub_exprContext sub_expr() {
			return getRuleContext(Sub_exprContext.class,0);
		}
		public Unary_operator_exprContext unary_operator_expr() {
			return getRuleContext(Unary_operator_exprContext.class,0);
		}
		public Function_stmtContext function_stmt() {
			return getRuleContext(Function_stmtContext.class,0);
		}
		public List<ExprContext> expr() {
			return getRuleContexts(ExprContext.class);
		}
		public ExprContext expr(int i) {
			return getRuleContext(ExprContext.class,i);
		}
		public Binary_operatorContext binary_operator() {
			return getRuleContext(Binary_operatorContext.class,0);
		}
		public ExprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_expr; }
	}

	public final ExprContext expr() throws RecognitionException {
		return expr(0);
	}

	private ExprContext expr(int _p) throws RecognitionException {
		ParserRuleContext _parentctx = _ctx;
		int _parentState = getState();
		ExprContext _localctx = new ExprContext(_ctx, _parentState);
		ExprContext _prevctx = _localctx;
		int _startState = 42;
		enterRecursionRule(_localctx, 42, RULE_expr, _p);
		try {
			int _alt;
			enterOuterAlt(_localctx, 1);
			{
			setState(204);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__16:
			case T__17:
			case T__18:
			case DIGIT:
			case Char_literal:
			case String_literal:
			case Datetime:
				{
				setState(198);
				literal();
				}
				break;
			case T__19:
				{
				setState(199);
				array_expr();
				}
				break;
			case T__15:
				{
				setState(200);
				bind_parameter();
				}
				break;
			case T__12:
				{
				setState(201);
				sub_expr();
				}
				break;
			case NOT:
				{
				setState(202);
				unary_operator_expr();
				}
				break;
			case IDENTIFIER:
				{
				setState(203);
				function_stmt();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(212);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,20,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new ExprContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_expr);
					setState(206);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(207);
					binary_operator();
					setState(208);
					expr(3);
					}
					} 
				}
				setState(214);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,20,_ctx);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			unrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public static class Sub_exprContext extends ParserRuleContext {
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Sub_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_sub_expr; }
	}

	public final Sub_exprContext sub_expr() throws RecognitionException {
		Sub_exprContext _localctx = new Sub_exprContext(_ctx, getState());
		enterRule(_localctx, 44, RULE_sub_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(215);
			match(T__12);
			setState(216);
			expr(0);
			setState(217);
			match(T__13);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Unary_operator_exprContext extends ParserRuleContext {
		public Unary_operatorContext unary_operator() {
			return getRuleContext(Unary_operatorContext.class,0);
		}
		public ExprContext expr() {
			return getRuleContext(ExprContext.class,0);
		}
		public Unary_operator_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_unary_operator_expr; }
	}

	public final Unary_operator_exprContext unary_operator_expr() throws RecognitionException {
		Unary_operator_exprContext _localctx = new Unary_operator_exprContext(_ctx, getState());
		enterRule(_localctx, 46, RULE_unary_operator_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(219);
			unary_operator();
			setState(220);
			expr(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Array_exprContext extends ParserRuleContext {
		public List<LiteralContext> literal() {
			return getRuleContexts(LiteralContext.class);
		}
		public LiteralContext literal(int i) {
			return getRuleContext(LiteralContext.class,i);
		}
		public Array_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_array_expr; }
	}

	public final Array_exprContext array_expr() throws RecognitionException {
		Array_exprContext _localctx = new Array_exprContext(_ctx, getState());
		enterRule(_localctx, 48, RULE_array_expr);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(222);
			match(T__19);
			setState(224);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__16) | (1L << T__17) | (1L << T__18) | (1L << DIGIT) | (1L << Char_literal) | (1L << String_literal) | (1L << Datetime))) != 0)) {
				{
				setState(223);
				literal();
				}
			}

			setState(230);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__11) {
				{
				{
				setState(226);
				match(T__11);
				setState(227);
				literal();
				}
				}
				setState(232);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(233);
			match(T__20);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class LiteralContext extends ParserRuleContext {
		public Numeric_literalContext numeric_literal() {
			return getRuleContext(Numeric_literalContext.class,0);
		}
		public String_literal_exprContext string_literal_expr() {
			return getRuleContext(String_literal_exprContext.class,0);
		}
		public Char_literal_exprContext char_literal_expr() {
			return getRuleContext(Char_literal_exprContext.class,0);
		}
		public Datetime_exprContext datetime_expr() {
			return getRuleContext(Datetime_exprContext.class,0);
		}
		public ConstantContext constant() {
			return getRuleContext(ConstantContext.class,0);
		}
		public VariableContext variable() {
			return getRuleContext(VariableContext.class,0);
		}
		public LiteralContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_literal; }
	}

	public final LiteralContext literal() throws RecognitionException {
		LiteralContext _localctx = new LiteralContext(_ctx, getState());
		enterRule(_localctx, 50, RULE_literal);
		try {
			setState(241);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__18:
			case DIGIT:
				enterOuterAlt(_localctx, 1);
				{
				setState(235);
				numeric_literal();
				}
				break;
			case String_literal:
				enterOuterAlt(_localctx, 2);
				{
				setState(236);
				string_literal_expr();
				}
				break;
			case Char_literal:
				enterOuterAlt(_localctx, 3);
				{
				setState(237);
				char_literal_expr();
				}
				break;
			case Datetime:
				enterOuterAlt(_localctx, 4);
				{
				setState(238);
				datetime_expr();
				}
				break;
			case T__16:
				enterOuterAlt(_localctx, 5);
				{
				setState(239);
				constant();
				}
				break;
			case T__17:
				enterOuterAlt(_localctx, 6);
				{
				setState(240);
				variable();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Function_nameContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Function_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_function_name; }
	}

	public final Function_nameContext function_name() throws RecognitionException {
		Function_nameContext _localctx = new Function_nameContext(_ctx, getState());
		enterRule(_localctx, 52, RULE_function_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(243);
			any_name();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Any_nameContext extends ParserRuleContext {
		public TerminalNode IDENTIFIER() { return getToken(SuggestionParser.IDENTIFIER, 0); }
		public Any_nameContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_any_name; }
	}

	public final Any_nameContext any_name() throws RecognitionException {
		Any_nameContext _localctx = new Any_nameContext(_ctx, getState());
		enterRule(_localctx, 54, RULE_any_name);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(245);
			match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class String_literal_exprContext extends ParserRuleContext {
		public TerminalNode String_literal() { return getToken(SuggestionParser.String_literal, 0); }
		public String_literal_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_string_literal_expr; }
	}

	public final String_literal_exprContext string_literal_expr() throws RecognitionException {
		String_literal_exprContext _localctx = new String_literal_exprContext(_ctx, getState());
		enterRule(_localctx, 56, RULE_string_literal_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(247);
			match(String_literal);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Char_literal_exprContext extends ParserRuleContext {
		public TerminalNode Char_literal() { return getToken(SuggestionParser.Char_literal, 0); }
		public Char_literal_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_char_literal_expr; }
	}

	public final Char_literal_exprContext char_literal_expr() throws RecognitionException {
		Char_literal_exprContext _localctx = new Char_literal_exprContext(_ctx, getState());
		enterRule(_localctx, 58, RULE_char_literal_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(249);
			match(Char_literal);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public static class Datetime_exprContext extends ParserRuleContext {
		public TerminalNode Datetime() { return getToken(SuggestionParser.Datetime, 0); }
		public TerminalNode String_literal() { return getToken(SuggestionParser.String_literal, 0); }
		public Datetime_exprContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_datetime_expr; }
	}

	public final Datetime_exprContext datetime_expr() throws RecognitionException {
		Datetime_exprContext _localctx = new Datetime_exprContext(_ctx, getState());
		enterRule(_localctx, 60, RULE_datetime_expr);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(251);
			match(Datetime);
			setState(253);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,24,_ctx) ) {
			case 1:
				{
				setState(252);
				match(String_literal);
				}
				break;
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			_errHandler.reportError(this, re);
			_errHandler.recover(this, re);
		}
		finally {
			exitRule();
		}
		return _localctx;
	}

	public boolean sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 21:
			return expr_sempred((ExprContext)_localctx, predIndex);
		}
		return true;
	}
	private boolean expr_sempred(ExprContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0:
			return precpred(_ctx, 2);
		}
		return true;
	}

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3$\u0102\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \3\2"+
		"\7\2B\n\2\f\2\16\2E\13\2\3\2\3\2\6\2I\n\2\r\2\16\2J\3\2\7\2N\n\2\f\2\16"+
		"\2Q\13\2\3\2\7\2T\n\2\f\2\16\2W\13\2\3\3\3\3\3\3\3\3\3\3\5\3^\n\3\3\4"+
		"\3\4\3\4\3\4\3\4\5\4e\n\4\3\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\7\3\7\3\7"+
		"\3\b\3\b\5\bt\n\b\3\b\5\bw\n\b\3\t\3\t\3\t\5\t|\n\t\3\n\3\n\3\n\3\13\3"+
		"\13\3\13\3\13\7\13\u0085\n\13\f\13\16\13\u0088\13\13\3\f\3\f\3\f\5\f\u008d"+
		"\n\f\3\f\3\f\3\r\3\r\3\r\7\r\u0094\n\r\f\r\16\r\u0097\13\r\3\16\3\16\3"+
		"\16\7\16\u009c\n\16\f\16\16\16\u009f\13\16\3\17\3\17\3\17\3\20\3\20\3"+
		"\20\3\21\3\21\3\21\3\22\3\22\5\22\u00ac\n\22\3\23\5\23\u00af\n\23\3\23"+
		"\6\23\u00b2\n\23\r\23\16\23\u00b3\3\24\5\24\u00b7\n\24\3\24\6\24\u00ba"+
		"\n\24\r\24\16\24\u00bb\3\24\3\24\6\24\u00c0\n\24\r\24\16\24\u00c1\3\25"+
		"\3\25\3\26\3\26\3\27\3\27\3\27\3\27\3\27\3\27\3\27\5\27\u00cf\n\27\3\27"+
		"\3\27\3\27\3\27\7\27\u00d5\n\27\f\27\16\27\u00d8\13\27\3\30\3\30\3\30"+
		"\3\30\3\31\3\31\3\31\3\32\3\32\5\32\u00e3\n\32\3\32\3\32\7\32\u00e7\n"+
		"\32\f\32\16\32\u00ea\13\32\3\32\3\32\3\33\3\33\3\33\3\33\3\33\3\33\5\33"+
		"\u00f4\n\33\3\34\3\34\3\35\3\35\3\36\3\36\3\37\3\37\3 \3 \5 \u0100\n "+
		"\3 \2\3,!\2\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\66"+
		"8:<>\2\3\3\2\30\33\2\u0106\2C\3\2\2\2\4]\3\2\2\2\6d\3\2\2\2\bf\3\2\2\2"+
		"\nk\3\2\2\2\fn\3\2\2\2\16q\3\2\2\2\20x\3\2\2\2\22}\3\2\2\2\24\u0080\3"+
		"\2\2\2\26\u0089\3\2\2\2\30\u0090\3\2\2\2\32\u0098\3\2\2\2\34\u00a0\3\2"+
		"\2\2\36\u00a3\3\2\2\2 \u00a6\3\2\2\2\"\u00ab\3\2\2\2$\u00ae\3\2\2\2&\u00b6"+
		"\3\2\2\2(\u00c3\3\2\2\2*\u00c5\3\2\2\2,\u00ce\3\2\2\2.\u00d9\3\2\2\2\60"+
		"\u00dd\3\2\2\2\62\u00e0\3\2\2\2\64\u00f3\3\2\2\2\66\u00f5\3\2\2\28\u00f7"+
		"\3\2\2\2:\u00f9\3\2\2\2<\u00fb\3\2\2\2>\u00fd\3\2\2\2@B\7\3\2\2A@\3\2"+
		"\2\2BE\3\2\2\2CA\3\2\2\2CD\3\2\2\2DF\3\2\2\2EC\3\2\2\2FO\5\4\3\2GI\7\3"+
		"\2\2HG\3\2\2\2IJ\3\2\2\2JH\3\2\2\2JK\3\2\2\2KL\3\2\2\2LN\5\4\3\2MH\3\2"+
		"\2\2NQ\3\2\2\2OM\3\2\2\2OP\3\2\2\2PU\3\2\2\2QO\3\2\2\2RT\7\3\2\2SR\3\2"+
		"\2\2TW\3\2\2\2US\3\2\2\2UV\3\2\2\2V\3\3\2\2\2WU\3\2\2\2X^\5\6\4\2Y^\5"+
		"\16\b\2Z^\5\b\5\2[^\5\n\6\2\\^\5\f\7\2]X\3\2\2\2]Y\3\2\2\2]Z\3\2\2\2]"+
		"[\3\2\2\2]\\\3\2\2\2^\5\3\2\2\2_`\7\4\2\2`e\7\5\2\2ab\7\4\2\2bc\7\6\2"+
		"\2ce\5\66\34\2d_\3\2\2\2da\3\2\2\2e\7\3\2\2\2fg\7\7\2\2gh\7\37\2\2hi\7"+
		"\b\2\2ij\5\64\33\2j\t\3\2\2\2kl\7\t\2\2lm\7\37\2\2m\13\3\2\2\2no\7\n\2"+
		"\2op\7\37\2\2p\r\3\2\2\2qs\5\20\t\2rt\5\22\n\2sr\3\2\2\2st\3\2\2\2tv\3"+
		"\2\2\2uw\5\24\13\2vu\3\2\2\2vw\3\2\2\2w\17\3\2\2\2x{\7\13\2\2y|\5,\27"+
		"\2z|\7\35\2\2{y\3\2\2\2{z\3\2\2\2|\21\3\2\2\2}~\7\f\2\2~\177\5\32\16\2"+
		"\177\23\3\2\2\2\u0080\u0081\7\r\2\2\u0081\u0086\7\37\2\2\u0082\u0083\7"+
		"\16\2\2\u0083\u0085\7\37\2\2\u0084\u0082\3\2\2\2\u0085\u0088\3\2\2\2\u0086"+
		"\u0084\3\2\2\2\u0086\u0087\3\2\2\2\u0087\25\3\2\2\2\u0088\u0086\3\2\2"+
		"\2\u0089\u008a\5\66\34\2\u008a\u008c\7\17\2\2\u008b\u008d\5\30\r\2\u008c"+
		"\u008b\3\2\2\2\u008c\u008d\3\2\2\2\u008d\u008e\3\2\2\2\u008e\u008f\7\20"+
		"\2\2\u008f\27\3\2\2\2\u0090\u0095\5,\27\2\u0091\u0092\7\16\2\2\u0092\u0094"+
		"\5,\27\2\u0093\u0091\3\2\2\2\u0094\u0097\3\2\2\2\u0095\u0093\3\2\2\2\u0095"+
		"\u0096\3\2\2\2\u0096\31\3\2\2\2\u0097\u0095\3\2\2\2\u0098\u009d\7\37\2"+
		"\2\u0099\u009a\7\21\2\2\u009a\u009c\7\37\2\2\u009b\u0099\3\2\2\2\u009c"+
		"\u009f\3\2\2\2\u009d\u009b\3\2\2\2\u009d\u009e\3\2\2\2\u009e\33\3\2\2"+
		"\2\u009f\u009d\3\2\2\2\u00a0\u00a1\7\22\2\2\u00a1\u00a2\7\37\2\2\u00a2"+
		"\35\3\2\2\2\u00a3\u00a4\7\23\2\2\u00a4\u00a5\7\37\2\2\u00a5\37\3\2\2\2"+
		"\u00a6\u00a7\7\24\2\2\u00a7\u00a8\7\37\2\2\u00a8!\3\2\2\2\u00a9\u00ac"+
		"\5&\24\2\u00aa\u00ac\5$\23\2\u00ab\u00a9\3\2\2\2\u00ab\u00aa\3\2\2\2\u00ac"+
		"#\3\2\2\2\u00ad\u00af\7\25\2\2\u00ae\u00ad\3\2\2\2\u00ae\u00af\3\2\2\2"+
		"\u00af\u00b1\3\2\2\2\u00b0\u00b2\7\36\2\2\u00b1\u00b0\3\2\2\2\u00b2\u00b3"+
		"\3\2\2\2\u00b3\u00b1\3\2\2\2\u00b3\u00b4\3\2\2\2\u00b4%\3\2\2\2\u00b5"+
		"\u00b7\7\25\2\2\u00b6\u00b5\3\2\2\2\u00b6\u00b7\3\2\2\2\u00b7\u00b9\3"+
		"\2\2\2\u00b8\u00ba\7\36\2\2\u00b9\u00b8\3\2\2\2\u00ba\u00bb\3\2\2\2\u00bb"+
		"\u00b9\3\2\2\2\u00bb\u00bc\3\2\2\2\u00bc\u00bd\3\2\2\2\u00bd\u00bf\7\21"+
		"\2\2\u00be\u00c0\7\36\2\2\u00bf\u00be\3\2\2\2\u00c0\u00c1\3\2\2\2\u00c1"+
		"\u00bf\3\2\2\2\u00c1\u00c2\3\2\2\2\u00c2\'\3\2\2\2\u00c3\u00c4\t\2\2\2"+
		"\u00c4)\3\2\2\2\u00c5\u00c6\7\34\2\2\u00c6+\3\2\2\2\u00c7\u00c8\b\27\1"+
		"\2\u00c8\u00cf\5\64\33\2\u00c9\u00cf\5\62\32\2\u00ca\u00cf\5\34\17\2\u00cb"+
		"\u00cf\5.\30\2\u00cc\u00cf\5\60\31\2\u00cd\u00cf\5\26\f\2\u00ce\u00c7"+
		"\3\2\2\2\u00ce\u00c9\3\2\2\2\u00ce\u00ca\3\2\2\2\u00ce\u00cb\3\2\2\2\u00ce"+
		"\u00cc\3\2\2\2\u00ce\u00cd\3\2\2\2\u00cf\u00d6\3\2\2\2\u00d0\u00d1\f\4"+
		"\2\2\u00d1\u00d2\5(\25\2\u00d2\u00d3\5,\27\5\u00d3\u00d5\3\2\2\2\u00d4"+
		"\u00d0\3\2\2\2\u00d5\u00d8\3\2\2\2\u00d6\u00d4\3\2\2\2\u00d6\u00d7\3\2"+
		"\2\2\u00d7-\3\2\2\2\u00d8\u00d6\3\2\2\2\u00d9\u00da\7\17\2\2\u00da\u00db"+
		"\5,\27\2\u00db\u00dc\7\20\2\2\u00dc/\3\2\2\2\u00dd\u00de\5*\26\2\u00de"+
		"\u00df\5,\27\2\u00df\61\3\2\2\2\u00e0\u00e2\7\26\2\2\u00e1\u00e3\5\64"+
		"\33\2\u00e2\u00e1\3\2\2\2\u00e2\u00e3\3\2\2\2\u00e3\u00e8\3\2\2\2\u00e4"+
		"\u00e5\7\16\2\2\u00e5\u00e7\5\64\33\2\u00e6\u00e4\3\2\2\2\u00e7\u00ea"+
		"\3\2\2\2\u00e8\u00e6\3\2\2\2\u00e8\u00e9\3\2\2\2\u00e9\u00eb\3\2\2\2\u00ea"+
		"\u00e8\3\2\2\2\u00eb\u00ec\7\27\2\2\u00ec\63\3\2\2\2\u00ed\u00f4\5\"\22"+
		"\2\u00ee\u00f4\5:\36\2\u00ef\u00f4\5<\37\2\u00f0\u00f4\5> \2\u00f1\u00f4"+
		"\5\36\20\2\u00f2\u00f4\5 \21\2\u00f3\u00ed\3\2\2\2\u00f3\u00ee\3\2\2\2"+
		"\u00f3\u00ef\3\2\2\2\u00f3\u00f0\3\2\2\2\u00f3\u00f1\3\2\2\2\u00f3\u00f2"+
		"\3\2\2\2\u00f4\65\3\2\2\2\u00f5\u00f6\58\35\2\u00f6\67\3\2\2\2\u00f7\u00f8"+
		"\7\37\2\2\u00f89\3\2\2\2\u00f9\u00fa\7#\2\2\u00fa;\3\2\2\2\u00fb\u00fc"+
		"\7\"\2\2\u00fc=\3\2\2\2\u00fd\u00ff\7$\2\2\u00fe\u0100\7#\2\2\u00ff\u00fe"+
		"\3\2\2\2\u00ff\u0100\3\2\2\2\u0100?\3\2\2\2\33CJOU]dsv{\u0086\u008c\u0095"+
		"\u009d\u00ab\u00ae\u00b3\u00b6\u00bb\u00c1\u00ce\u00d6\u00e2\u00e8\u00f3"+
		"\u00ff";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}