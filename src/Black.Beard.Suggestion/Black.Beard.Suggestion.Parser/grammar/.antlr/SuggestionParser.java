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
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, AND=15, ANDALSO=16, OR=17, 
		XOR=18, NOT=19, K_ALL=20, K_SHOW=21, K_WHERE=22, K_WITH=23, K_FACETS=24, 
		K_ORDER=25, K_BY=26, DIGIT=27, IDENTIFIER=28, COMMENT_INPUT=29, LINE_COMMENT=30, 
		Char_literal=31, String_literal=32, Datetime=33;
	public static final int
		RULE_stmt_list = 0, RULE_stmt_line = 1, RULE_stmt_show = 2, RULE_stmt_Set_globalParameter = 3, 
		RULE_stmt_Set_globalParameter_literal = 4, RULE_stmt_Del_globalParameter = 5, 
		RULE_select_stmt = 6, RULE_where_stmt = 7, RULE_order_stmt = 8, RULE_facet_stmt = 9, 
		RULE_function_stmt = 10, RULE_function_args_stmt = 11, RULE_identifier_stmt = 12, 
		RULE_bind_parameter = 13, RULE_constant = 14, RULE_variable = 15, RULE_numeric_literal = 16, 
		RULE_numeric_integer_literal = 17, RULE_numeric_double_literal = 18, RULE_binary_operator = 19, 
		RULE_unary_operator = 20, RULE_expr = 21, RULE_sub_expr = 22, RULE_unary_operator_expr = 23, 
		RULE_array_expr = 24, RULE_literal = 25, RULE_function_name = 26, RULE_any_name = 27, 
		RULE_string_literal_expr = 28, RULE_char_literal_expr = 29, RULE_datetime_expr = 30, 
		RULE_datetime_mask = 31, RULE_datetime_culture = 32;
	public static final String[] ruleNames = {
		"stmt_list", "stmt_line", "stmt_show", "stmt_Set_globalParameter", "stmt_Set_globalParameter_literal", 
		"stmt_Del_globalParameter", "select_stmt", "where_stmt", "order_stmt", 
		"facet_stmt", "function_stmt", "function_args_stmt", "identifier_stmt", 
		"bind_parameter", "constant", "variable", "numeric_literal", "numeric_integer_literal", 
		"numeric_double_literal", "binary_operator", "unary_operator", "expr", 
		"sub_expr", "unary_operator_expr", "array_expr", "literal", "function_name", 
		"any_name", "string_literal_expr", "char_literal_expr", "datetime_expr", 
		"datetime_mask", "datetime_culture"
	};

	private static final String[] _LITERAL_NAMES = {
		null, "';'", "'SET'", "'='", "'DEL'", "','", "'('", "')'", "'.'", "':'", 
		"'$'", "'@'", "'-'", "'['", "']'", "'&'", "'&&'", "'|'", "'||'", "'!'"
	};
	private static final String[] _SYMBOLIC_NAMES = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, "AND", "ANDALSO", "OR", "XOR", "NOT", "K_ALL", "K_SHOW", 
		"K_WHERE", "K_WITH", "K_FACETS", "K_ORDER", "K_BY", "DIGIT", "IDENTIFIER", 
		"COMMENT_INPUT", "LINE_COMMENT", "Char_literal", "String_literal", "Datetime"
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
			setState(69);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__0) {
				{
				{
				setState(66);
				match(T__0);
				}
				}
				setState(71);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(72);
			stmt_line();
			setState(81);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					{
					{
					setState(74); 
					_errHandler.sync(this);
					_la = _input.LA(1);
					do {
						{
						{
						setState(73);
						match(T__0);
						}
						}
						setState(76); 
						_errHandler.sync(this);
						_la = _input.LA(1);
					} while ( _la==T__0 );
					setState(78);
					stmt_line();
					}
					} 
				}
				setState(83);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,2,_ctx);
			}
			setState(87);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__0) {
				{
				{
				setState(84);
				match(T__0);
				}
				}
				setState(89);
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
		public Stmt_showContext stmt_show() {
			return getRuleContext(Stmt_showContext.class,0);
		}
		public Select_stmtContext select_stmt() {
			return getRuleContext(Select_stmtContext.class,0);
		}
		public Stmt_Set_globalParameterContext stmt_Set_globalParameter() {
			return getRuleContext(Stmt_Set_globalParameterContext.class,0);
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
			setState(94);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case K_SHOW:
				enterOuterAlt(_localctx, 1);
				{
				setState(90);
				stmt_show();
				}
				break;
			case K_WHERE:
				enterOuterAlt(_localctx, 2);
				{
				setState(91);
				select_stmt();
				}
				break;
			case T__1:
				enterOuterAlt(_localctx, 3);
				{
				setState(92);
				stmt_Set_globalParameter();
				}
				break;
			case T__3:
				enterOuterAlt(_localctx, 4);
				{
				setState(93);
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

	public static class Stmt_showContext extends ParserRuleContext {
		public TerminalNode K_SHOW() { return getToken(SuggestionParser.K_SHOW, 0); }
		public List<Any_nameContext> any_name() {
			return getRuleContexts(Any_nameContext.class);
		}
		public Any_nameContext any_name(int i) {
			return getRuleContext(Any_nameContext.class,i);
		}
		public Stmt_showContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stmt_show; }
	}

	public final Stmt_showContext stmt_show() throws RecognitionException {
		Stmt_showContext _localctx = new Stmt_showContext(_ctx, getState());
		enterRule(_localctx, 4, RULE_stmt_show);
		int _la;
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(96);
			match(K_SHOW);
			setState(97);
			any_name();
			setState(99);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==IDENTIFIER) {
				{
				setState(98);
				any_name();
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

	public static class Stmt_Set_globalParameterContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
		public Stmt_Set_globalParameter_literalContext stmt_Set_globalParameter_literal() {
			return getRuleContext(Stmt_Set_globalParameter_literalContext.class,0);
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
			setState(101);
			match(T__1);
			setState(102);
			any_name();
			setState(103);
			match(T__2);
			setState(104);
			stmt_Set_globalParameter_literal();
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

	public static class Stmt_Set_globalParameter_literalContext extends ParserRuleContext {
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
		public Stmt_Set_globalParameter_literalContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_stmt_Set_globalParameter_literal; }
	}

	public final Stmt_Set_globalParameter_literalContext stmt_Set_globalParameter_literal() throws RecognitionException {
		Stmt_Set_globalParameter_literalContext _localctx = new Stmt_Set_globalParameter_literalContext(_ctx, getState());
		enterRule(_localctx, 8, RULE_stmt_Set_globalParameter_literal);
		try {
			setState(110);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__11:
			case DIGIT:
				enterOuterAlt(_localctx, 1);
				{
				setState(106);
				numeric_literal();
				}
				break;
			case String_literal:
				enterOuterAlt(_localctx, 2);
				{
				setState(107);
				string_literal_expr();
				}
				break;
			case Char_literal:
				enterOuterAlt(_localctx, 3);
				{
				setState(108);
				char_literal_expr();
				}
				break;
			case Datetime:
				enterOuterAlt(_localctx, 4);
				{
				setState(109);
				datetime_expr();
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

	public static class Stmt_Del_globalParameterContext extends ParserRuleContext {
		public Any_nameContext any_name() {
			return getRuleContext(Any_nameContext.class,0);
		}
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
			setState(112);
			match(T__3);
			setState(113);
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
			setState(115);
			where_stmt();
			setState(117);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==K_ORDER) {
				{
				setState(116);
				order_stmt();
				}
			}

			setState(120);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==K_WITH) {
				{
				setState(119);
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
		public TerminalNode K_WHERE() { return getToken(SuggestionParser.K_WHERE, 0); }
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
			setState(122);
			match(K_WHERE);
			setState(125);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__5:
			case T__8:
			case T__9:
			case T__10:
			case T__11:
			case T__12:
			case NOT:
			case DIGIT:
			case IDENTIFIER:
			case Char_literal:
			case String_literal:
			case Datetime:
				{
				setState(123);
				expr(0);
				}
				break;
			case K_ALL:
				{
				setState(124);
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
		public TerminalNode K_ORDER() { return getToken(SuggestionParser.K_ORDER, 0); }
		public TerminalNode K_BY() { return getToken(SuggestionParser.K_BY, 0); }
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
			setState(127);
			match(K_ORDER);
			setState(128);
			match(K_BY);
			setState(129);
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
		public TerminalNode K_WITH() { return getToken(SuggestionParser.K_WITH, 0); }
		public TerminalNode K_FACETS() { return getToken(SuggestionParser.K_FACETS, 0); }
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
			setState(131);
			match(K_WITH);
			setState(132);
			match(K_FACETS);
			setState(133);
			match(IDENTIFIER);
			setState(138);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__4) {
				{
				{
				setState(134);
				match(T__4);
				setState(135);
				match(IDENTIFIER);
				}
				}
				setState(140);
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
			setState(141);
			function_name();
			setState(142);
			match(T__5);
			setState(144);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__5) | (1L << T__8) | (1L << T__9) | (1L << T__10) | (1L << T__11) | (1L << T__12) | (1L << NOT) | (1L << DIGIT) | (1L << IDENTIFIER) | (1L << Char_literal) | (1L << String_literal) | (1L << Datetime))) != 0)) {
				{
				setState(143);
				function_args_stmt();
				}
			}

			setState(146);
			match(T__6);
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
			setState(148);
			expr(0);
			setState(153);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__4) {
				{
				{
				setState(149);
				match(T__4);
				setState(150);
				expr(0);
				}
				}
				setState(155);
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
			setState(156);
			match(IDENTIFIER);
			setState(161);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__7) {
				{
				{
				setState(157);
				match(T__7);
				setState(158);
				match(IDENTIFIER);
				}
				}
				setState(163);
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
			setState(164);
			match(T__8);
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
			setState(167);
			match(T__9);
			setState(168);
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
			setState(170);
			match(T__10);
			setState(171);
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
			setState(175);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,14,_ctx) ) {
			case 1:
				enterOuterAlt(_localctx, 1);
				{
				setState(173);
				numeric_double_literal();
				}
				break;
			case 2:
				enterOuterAlt(_localctx, 2);
				{
				setState(174);
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
			setState(178);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__11) {
				{
				setState(177);
				match(T__11);
				}
			}

			setState(181); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(180);
					match(DIGIT);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(183); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,16,_ctx);
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
			setState(186);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if (_la==T__11) {
				{
				setState(185);
				match(T__11);
				}
			}

			setState(189); 
			_errHandler.sync(this);
			_la = _input.LA(1);
			do {
				{
				{
				setState(188);
				match(DIGIT);
				}
				}
				setState(191); 
				_errHandler.sync(this);
				_la = _input.LA(1);
			} while ( _la==DIGIT );
			setState(193);
			match(T__7);
			setState(195); 
			_errHandler.sync(this);
			_alt = 1;
			do {
				switch (_alt) {
				case 1:
					{
					{
					setState(194);
					match(DIGIT);
					}
					}
					break;
				default:
					throw new NoViableAltException(this);
				}
				setState(197); 
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,19,_ctx);
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
			setState(199);
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
			setState(201);
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
			setState(210);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__9:
			case T__10:
			case T__11:
			case DIGIT:
			case Char_literal:
			case String_literal:
			case Datetime:
				{
				setState(204);
				literal();
				}
				break;
			case T__12:
				{
				setState(205);
				array_expr();
				}
				break;
			case T__8:
				{
				setState(206);
				bind_parameter();
				}
				break;
			case T__5:
				{
				setState(207);
				sub_expr();
				}
				break;
			case NOT:
				{
				setState(208);
				unary_operator_expr();
				}
				break;
			case IDENTIFIER:
				{
				setState(209);
				function_stmt();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			_ctx.stop = _input.LT(-1);
			setState(218);
			_errHandler.sync(this);
			_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
			while ( _alt!=2 && _alt!=org.antlr.v4.runtime.atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( _parseListeners!=null ) triggerExitRuleEvent();
					_prevctx = _localctx;
					{
					{
					_localctx = new ExprContext(_parentctx, _parentState);
					pushNewRecursionContext(_localctx, _startState, RULE_expr);
					setState(212);
					if (!(precpred(_ctx, 2))) throw new FailedPredicateException(this, "precpred(_ctx, 2)");
					setState(213);
					binary_operator();
					setState(214);
					expr(3);
					}
					} 
				}
				setState(220);
				_errHandler.sync(this);
				_alt = getInterpreter().adaptivePredict(_input,21,_ctx);
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
			setState(221);
			match(T__5);
			setState(222);
			expr(0);
			setState(223);
			match(T__6);
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
			setState(225);
			unary_operator();
			setState(226);
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
			setState(228);
			match(T__12);
			setState(230);
			_errHandler.sync(this);
			_la = _input.LA(1);
			if ((((_la) & ~0x3f) == 0 && ((1L << _la) & ((1L << T__9) | (1L << T__10) | (1L << T__11) | (1L << DIGIT) | (1L << Char_literal) | (1L << String_literal) | (1L << Datetime))) != 0)) {
				{
				setState(229);
				literal();
				}
			}

			setState(236);
			_errHandler.sync(this);
			_la = _input.LA(1);
			while (_la==T__4) {
				{
				{
				setState(232);
				match(T__4);
				setState(233);
				literal();
				}
				}
				setState(238);
				_errHandler.sync(this);
				_la = _input.LA(1);
			}
			setState(239);
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
			setState(247);
			_errHandler.sync(this);
			switch (_input.LA(1)) {
			case T__11:
			case DIGIT:
				enterOuterAlt(_localctx, 1);
				{
				setState(241);
				numeric_literal();
				}
				break;
			case String_literal:
				enterOuterAlt(_localctx, 2);
				{
				setState(242);
				string_literal_expr();
				}
				break;
			case Char_literal:
				enterOuterAlt(_localctx, 3);
				{
				setState(243);
				char_literal_expr();
				}
				break;
			case Datetime:
				enterOuterAlt(_localctx, 4);
				{
				setState(244);
				datetime_expr();
				}
				break;
			case T__9:
				enterOuterAlt(_localctx, 5);
				{
				setState(245);
				constant();
				}
				break;
			case T__10:
				enterOuterAlt(_localctx, 6);
				{
				setState(246);
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
			setState(249);
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
			setState(251);
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
			setState(253);
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
			setState(255);
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
		public Datetime_maskContext datetime_mask() {
			return getRuleContext(Datetime_maskContext.class,0);
		}
		public Datetime_cultureContext datetime_culture() {
			return getRuleContext(Datetime_cultureContext.class,0);
		}
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
			setState(257);
			match(Datetime);
			setState(262);
			_errHandler.sync(this);
			switch ( getInterpreter().adaptivePredict(_input,26,_ctx) ) {
			case 1:
				{
				setState(258);
				datetime_mask();
				setState(260);
				_errHandler.sync(this);
				switch ( getInterpreter().adaptivePredict(_input,25,_ctx) ) {
				case 1:
					{
					setState(259);
					datetime_culture();
					}
					break;
				}
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

	public static class Datetime_maskContext extends ParserRuleContext {
		public TerminalNode String_literal() { return getToken(SuggestionParser.String_literal, 0); }
		public Datetime_maskContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_datetime_mask; }
	}

	public final Datetime_maskContext datetime_mask() throws RecognitionException {
		Datetime_maskContext _localctx = new Datetime_maskContext(_ctx, getState());
		enterRule(_localctx, 62, RULE_datetime_mask);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(264);
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

	public static class Datetime_cultureContext extends ParserRuleContext {
		public TerminalNode String_literal() { return getToken(SuggestionParser.String_literal, 0); }
		public Datetime_cultureContext(ParserRuleContext parent, int invokingState) {
			super(parent, invokingState);
		}
		@Override public int getRuleIndex() { return RULE_datetime_culture; }
	}

	public final Datetime_cultureContext datetime_culture() throws RecognitionException {
		Datetime_cultureContext _localctx = new Datetime_cultureContext(_ctx, getState());
		enterRule(_localctx, 64, RULE_datetime_culture);
		try {
			enterOuterAlt(_localctx, 1);
			{
			setState(266);
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
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\3#\u010f\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\3\2\7\2F\n\2\f\2\16\2I\13\2\3\2\3\2\6\2M\n\2\r\2\16\2N\3\2"+
		"\7\2R\n\2\f\2\16\2U\13\2\3\2\7\2X\n\2\f\2\16\2[\13\2\3\3\3\3\3\3\3\3\5"+
		"\3a\n\3\3\4\3\4\3\4\5\4f\n\4\3\5\3\5\3\5\3\5\3\5\3\6\3\6\3\6\3\6\5\6q"+
		"\n\6\3\7\3\7\3\7\3\b\3\b\5\bx\n\b\3\b\5\b{\n\b\3\t\3\t\3\t\5\t\u0080\n"+
		"\t\3\n\3\n\3\n\3\n\3\13\3\13\3\13\3\13\3\13\7\13\u008b\n\13\f\13\16\13"+
		"\u008e\13\13\3\f\3\f\3\f\5\f\u0093\n\f\3\f\3\f\3\r\3\r\3\r\7\r\u009a\n"+
		"\r\f\r\16\r\u009d\13\r\3\16\3\16\3\16\7\16\u00a2\n\16\f\16\16\16\u00a5"+
		"\13\16\3\17\3\17\3\17\3\20\3\20\3\20\3\21\3\21\3\21\3\22\3\22\5\22\u00b2"+
		"\n\22\3\23\5\23\u00b5\n\23\3\23\6\23\u00b8\n\23\r\23\16\23\u00b9\3\24"+
		"\5\24\u00bd\n\24\3\24\6\24\u00c0\n\24\r\24\16\24\u00c1\3\24\3\24\6\24"+
		"\u00c6\n\24\r\24\16\24\u00c7\3\25\3\25\3\26\3\26\3\27\3\27\3\27\3\27\3"+
		"\27\3\27\3\27\5\27\u00d5\n\27\3\27\3\27\3\27\3\27\7\27\u00db\n\27\f\27"+
		"\16\27\u00de\13\27\3\30\3\30\3\30\3\30\3\31\3\31\3\31\3\32\3\32\5\32\u00e9"+
		"\n\32\3\32\3\32\7\32\u00ed\n\32\f\32\16\32\u00f0\13\32\3\32\3\32\3\33"+
		"\3\33\3\33\3\33\3\33\3\33\5\33\u00fa\n\33\3\34\3\34\3\35\3\35\3\36\3\36"+
		"\3\37\3\37\3 \3 \3 \5 \u0107\n \5 \u0109\n \3!\3!\3\"\3\"\3\"\2\3,#\2"+
		"\4\6\b\n\f\16\20\22\24\26\30\32\34\36 \"$&(*,.\60\62\64\668:<>@B\2\3\3"+
		"\2\21\24\2\u0114\2G\3\2\2\2\4`\3\2\2\2\6b\3\2\2\2\bg\3\2\2\2\np\3\2\2"+
		"\2\fr\3\2\2\2\16u\3\2\2\2\20|\3\2\2\2\22\u0081\3\2\2\2\24\u0085\3\2\2"+
		"\2\26\u008f\3\2\2\2\30\u0096\3\2\2\2\32\u009e\3\2\2\2\34\u00a6\3\2\2\2"+
		"\36\u00a9\3\2\2\2 \u00ac\3\2\2\2\"\u00b1\3\2\2\2$\u00b4\3\2\2\2&\u00bc"+
		"\3\2\2\2(\u00c9\3\2\2\2*\u00cb\3\2\2\2,\u00d4\3\2\2\2.\u00df\3\2\2\2\60"+
		"\u00e3\3\2\2\2\62\u00e6\3\2\2\2\64\u00f9\3\2\2\2\66\u00fb\3\2\2\28\u00fd"+
		"\3\2\2\2:\u00ff\3\2\2\2<\u0101\3\2\2\2>\u0103\3\2\2\2@\u010a\3\2\2\2B"+
		"\u010c\3\2\2\2DF\7\3\2\2ED\3\2\2\2FI\3\2\2\2GE\3\2\2\2GH\3\2\2\2HJ\3\2"+
		"\2\2IG\3\2\2\2JS\5\4\3\2KM\7\3\2\2LK\3\2\2\2MN\3\2\2\2NL\3\2\2\2NO\3\2"+
		"\2\2OP\3\2\2\2PR\5\4\3\2QL\3\2\2\2RU\3\2\2\2SQ\3\2\2\2ST\3\2\2\2TY\3\2"+
		"\2\2US\3\2\2\2VX\7\3\2\2WV\3\2\2\2X[\3\2\2\2YW\3\2\2\2YZ\3\2\2\2Z\3\3"+
		"\2\2\2[Y\3\2\2\2\\a\5\6\4\2]a\5\16\b\2^a\5\b\5\2_a\5\f\7\2`\\\3\2\2\2"+
		"`]\3\2\2\2`^\3\2\2\2`_\3\2\2\2a\5\3\2\2\2bc\7\27\2\2ce\58\35\2df\58\35"+
		"\2ed\3\2\2\2ef\3\2\2\2f\7\3\2\2\2gh\7\4\2\2hi\58\35\2ij\7\5\2\2jk\5\n"+
		"\6\2k\t\3\2\2\2lq\5\"\22\2mq\5:\36\2nq\5<\37\2oq\5> \2pl\3\2\2\2pm\3\2"+
		"\2\2pn\3\2\2\2po\3\2\2\2q\13\3\2\2\2rs\7\6\2\2st\58\35\2t\r\3\2\2\2uw"+
		"\5\20\t\2vx\5\22\n\2wv\3\2\2\2wx\3\2\2\2xz\3\2\2\2y{\5\24\13\2zy\3\2\2"+
		"\2z{\3\2\2\2{\17\3\2\2\2|\177\7\30\2\2}\u0080\5,\27\2~\u0080\7\26\2\2"+
		"\177}\3\2\2\2\177~\3\2\2\2\u0080\21\3\2\2\2\u0081\u0082\7\33\2\2\u0082"+
		"\u0083\7\34\2\2\u0083\u0084\5\32\16\2\u0084\23\3\2\2\2\u0085\u0086\7\31"+
		"\2\2\u0086\u0087\7\32\2\2\u0087\u008c\7\36\2\2\u0088\u0089\7\7\2\2\u0089"+
		"\u008b\7\36\2\2\u008a\u0088\3\2\2\2\u008b\u008e\3\2\2\2\u008c\u008a\3"+
		"\2\2\2\u008c\u008d\3\2\2\2\u008d\25\3\2\2\2\u008e\u008c\3\2\2\2\u008f"+
		"\u0090\5\66\34\2\u0090\u0092\7\b\2\2\u0091\u0093\5\30\r\2\u0092\u0091"+
		"\3\2\2\2\u0092\u0093\3\2\2\2\u0093\u0094\3\2\2\2\u0094\u0095\7\t\2\2\u0095"+
		"\27\3\2\2\2\u0096\u009b\5,\27\2\u0097\u0098\7\7\2\2\u0098\u009a\5,\27"+
		"\2\u0099\u0097\3\2\2\2\u009a\u009d\3\2\2\2\u009b\u0099\3\2\2\2\u009b\u009c"+
		"\3\2\2\2\u009c\31\3\2\2\2\u009d\u009b\3\2\2\2\u009e\u00a3\7\36\2\2\u009f"+
		"\u00a0\7\n\2\2\u00a0\u00a2\7\36\2\2\u00a1\u009f\3\2\2\2\u00a2\u00a5\3"+
		"\2\2\2\u00a3\u00a1\3\2\2\2\u00a3\u00a4\3\2\2\2\u00a4\33\3\2\2\2\u00a5"+
		"\u00a3\3\2\2\2\u00a6\u00a7\7\13\2\2\u00a7\u00a8\7\36\2\2\u00a8\35\3\2"+
		"\2\2\u00a9\u00aa\7\f\2\2\u00aa\u00ab\7\36\2\2\u00ab\37\3\2\2\2\u00ac\u00ad"+
		"\7\r\2\2\u00ad\u00ae\7\36\2\2\u00ae!\3\2\2\2\u00af\u00b2\5&\24\2\u00b0"+
		"\u00b2\5$\23\2\u00b1\u00af\3\2\2\2\u00b1\u00b0\3\2\2\2\u00b2#\3\2\2\2"+
		"\u00b3\u00b5\7\16\2\2\u00b4\u00b3\3\2\2\2\u00b4\u00b5\3\2\2\2\u00b5\u00b7"+
		"\3\2\2\2\u00b6\u00b8\7\35\2\2\u00b7\u00b6\3\2\2\2\u00b8\u00b9\3\2\2\2"+
		"\u00b9\u00b7\3\2\2\2\u00b9\u00ba\3\2\2\2\u00ba%\3\2\2\2\u00bb\u00bd\7"+
		"\16\2\2\u00bc\u00bb\3\2\2\2\u00bc\u00bd\3\2\2\2\u00bd\u00bf\3\2\2\2\u00be"+
		"\u00c0\7\35\2\2\u00bf\u00be\3\2\2\2\u00c0\u00c1\3\2\2\2\u00c1\u00bf\3"+
		"\2\2\2\u00c1\u00c2\3\2\2\2\u00c2\u00c3\3\2\2\2\u00c3\u00c5\7\n\2\2\u00c4"+
		"\u00c6\7\35\2\2\u00c5\u00c4\3\2\2\2\u00c6\u00c7\3\2\2\2\u00c7\u00c5\3"+
		"\2\2\2\u00c7\u00c8\3\2\2\2\u00c8\'\3\2\2\2\u00c9\u00ca\t\2\2\2\u00ca)"+
		"\3\2\2\2\u00cb\u00cc\7\25\2\2\u00cc+\3\2\2\2\u00cd\u00ce\b\27\1\2\u00ce"+
		"\u00d5\5\64\33\2\u00cf\u00d5\5\62\32\2\u00d0\u00d5\5\34\17\2\u00d1\u00d5"+
		"\5.\30\2\u00d2\u00d5\5\60\31\2\u00d3\u00d5\5\26\f\2\u00d4\u00cd\3\2\2"+
		"\2\u00d4\u00cf\3\2\2\2\u00d4\u00d0\3\2\2\2\u00d4\u00d1\3\2\2\2\u00d4\u00d2"+
		"\3\2\2\2\u00d4\u00d3\3\2\2\2\u00d5\u00dc\3\2\2\2\u00d6\u00d7\f\4\2\2\u00d7"+
		"\u00d8\5(\25\2\u00d8\u00d9\5,\27\5\u00d9\u00db\3\2\2\2\u00da\u00d6\3\2"+
		"\2\2\u00db\u00de\3\2\2\2\u00dc\u00da\3\2\2\2\u00dc\u00dd\3\2\2\2\u00dd"+
		"-\3\2\2\2\u00de\u00dc\3\2\2\2\u00df\u00e0\7\b\2\2\u00e0\u00e1\5,\27\2"+
		"\u00e1\u00e2\7\t\2\2\u00e2/\3\2\2\2\u00e3\u00e4\5*\26\2\u00e4\u00e5\5"+
		",\27\2\u00e5\61\3\2\2\2\u00e6\u00e8\7\17\2\2\u00e7\u00e9\5\64\33\2\u00e8"+
		"\u00e7\3\2\2\2\u00e8\u00e9\3\2\2\2\u00e9\u00ee\3\2\2\2\u00ea\u00eb\7\7"+
		"\2\2\u00eb\u00ed\5\64\33\2\u00ec\u00ea\3\2\2\2\u00ed\u00f0\3\2\2\2\u00ee"+
		"\u00ec\3\2\2\2\u00ee\u00ef\3\2\2\2\u00ef\u00f1\3\2\2\2\u00f0\u00ee\3\2"+
		"\2\2\u00f1\u00f2\7\20\2\2\u00f2\63\3\2\2\2\u00f3\u00fa\5\"\22\2\u00f4"+
		"\u00fa\5:\36\2\u00f5\u00fa\5<\37\2\u00f6\u00fa\5> \2\u00f7\u00fa\5\36"+
		"\20\2\u00f8\u00fa\5 \21\2\u00f9\u00f3\3\2\2\2\u00f9\u00f4\3\2\2\2\u00f9"+
		"\u00f5\3\2\2\2\u00f9\u00f6\3\2\2\2\u00f9\u00f7\3\2\2\2\u00f9\u00f8\3\2"+
		"\2\2\u00fa\65\3\2\2\2\u00fb\u00fc\58\35\2\u00fc\67\3\2\2\2\u00fd\u00fe"+
		"\7\36\2\2\u00fe9\3\2\2\2\u00ff\u0100\7\"\2\2\u0100;\3\2\2\2\u0101\u0102"+
		"\7!\2\2\u0102=\3\2\2\2\u0103\u0108\7#\2\2\u0104\u0106\5@!\2\u0105\u0107"+
		"\5B\"\2\u0106\u0105\3\2\2\2\u0106\u0107\3\2\2\2\u0107\u0109\3\2\2\2\u0108"+
		"\u0104\3\2\2\2\u0108\u0109\3\2\2\2\u0109?\3\2\2\2\u010a\u010b\7\"\2\2"+
		"\u010bA\3\2\2\2\u010c\u010d\7\"\2\2\u010dC\3\2\2\2\35GNSY`epwz\177\u008c"+
		"\u0092\u009b\u00a3\u00b1\u00b4\u00b9\u00bc\u00c1\u00c7\u00d4\u00dc\u00e8"+
		"\u00ee\u00f9\u0106\u0108";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}