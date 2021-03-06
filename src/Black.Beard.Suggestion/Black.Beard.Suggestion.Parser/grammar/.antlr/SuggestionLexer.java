// Generated from c:\github\Suggestion\src\Black.Beard.Suggestion\Black.Beard.Suggestion.Parser\grammar\Suggestion.g4 by ANTLR 4.7
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class SuggestionLexer extends Lexer {
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
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	public static final String[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "AND", "ANDALSO", "OR", "XOR", 
		"NOT", "K_ALL", "K_SHOW", "K_WHERE", "K_WITH", "K_FACETS", "K_ORDER", 
		"K_BY", "DIGIT", "IDENTIFIER", "COMMENT_INPUT", "LINE_COMMENT", "Char_literal", 
		"String_literal", "Datetime", "A", "B", "C", "D", "E", "F", "G", "H", 
		"I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", 
		"W", "X", "Y", "Z"
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


	public SuggestionLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "Suggestion.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2#\u0151\b\1\4\2\t"+
		"\2\4\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13"+
		"\t\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\4\20\t\20\4\21\t\21\4\22\t\22"+
		"\4\23\t\23\4\24\t\24\4\25\t\25\4\26\t\26\4\27\t\27\4\30\t\30\4\31\t\31"+
		"\4\32\t\32\4\33\t\33\4\34\t\34\4\35\t\35\4\36\t\36\4\37\t\37\4 \t \4!"+
		"\t!\4\"\t\"\4#\t#\4$\t$\4%\t%\4&\t&\4\'\t\'\4(\t(\4)\t)\4*\t*\4+\t+\4"+
		",\t,\4-\t-\4.\t.\4/\t/\4\60\t\60\4\61\t\61\4\62\t\62\4\63\t\63\4\64\t"+
		"\64\4\65\t\65\4\66\t\66\4\67\t\67\48\t8\49\t9\4:\t:\4;\t;\4<\t<\3\2\3"+
		"\2\3\3\3\3\3\3\3\3\3\4\3\4\3\5\3\5\3\5\3\5\3\6\3\6\3\7\3\7\3\b\3\b\3\t"+
		"\3\t\3\n\3\n\3\13\3\13\3\f\3\f\3\r\3\r\3\16\3\16\3\17\3\17\3\20\3\20\3"+
		"\21\3\21\3\21\3\22\3\22\3\23\3\23\3\23\3\24\3\24\3\25\3\25\3\25\3\25\3"+
		"\26\3\26\3\26\3\26\3\26\3\27\3\27\3\27\3\27\3\27\3\27\3\30\3\30\3\30\3"+
		"\30\3\30\3\31\3\31\3\31\3\31\3\31\3\31\3\31\3\32\3\32\3\32\3\32\3\32\3"+
		"\32\3\33\3\33\3\33\3\34\3\34\3\35\3\35\7\35\u00ce\n\35\f\35\16\35\u00d1"+
		"\13\35\3\36\3\36\3\36\3\36\7\36\u00d7\n\36\f\36\16\36\u00da\13\36\3\36"+
		"\3\36\3\36\3\36\3\36\3\37\3\37\3\37\3\37\5\37\u00e5\n\37\3\37\7\37\u00e8"+
		"\n\37\f\37\16\37\u00eb\13\37\3\37\5\37\u00ee\n\37\3\37\3\37\5\37\u00f2"+
		"\n\37\3\37\3\37\3\37\3\37\5\37\u00f8\n\37\3\37\3\37\5\37\u00fc\n\37\5"+
		"\37\u00fe\n\37\3\37\3\37\3 \3 \3 \3 \5 \u0106\n \3 \3 \3!\3!\3!\3!\7!"+
		"\u010e\n!\f!\16!\u0111\13!\3!\3!\3\"\3\"\7\"\u0117\n\"\f\"\16\"\u011a"+
		"\13\"\3\"\3\"\3#\3#\3$\3$\3%\3%\3&\3&\3\'\3\'\3(\3(\3)\3)\3*\3*\3+\3+"+
		"\3,\3,\3-\3-\3.\3.\3/\3/\3\60\3\60\3\61\3\61\3\62\3\62\3\63\3\63\3\64"+
		"\3\64\3\65\3\65\3\66\3\66\3\67\3\67\38\38\39\39\3:\3:\3;\3;\3<\3<\3\u00d8"+
		"\2=\3\3\5\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35"+
		"\20\37\21!\22#\23%\24\'\25)\26+\27-\30/\31\61\32\63\33\65\34\67\359\36"+
		";\37= ?!A\"C#E\2G\2I\2K\2M\2O\2Q\2S\2U\2W\2Y\2[\2]\2_\2a\2c\2e\2g\2i\2"+
		"k\2m\2o\2q\2s\2u\2w\2\3\2#\3\2\62;\5\2C\\aac|\6\2\62;C\\aac|\4\2\f\f\17"+
		"\17\3\2))\3\2$$\3\2\61\61\4\2CCcc\4\2DDdd\4\2EEee\4\2FFff\4\2GGgg\4\2"+
		"HHhh\4\2IIii\4\2JJjj\4\2KKkk\4\2LLll\4\2MMmm\4\2NNnn\4\2OOoo\4\2PPpp\4"+
		"\2QQqq\4\2RRrr\4\2SSss\4\2TTtt\4\2UUuu\4\2VVvv\4\2WWww\4\2XXxx\4\2YYy"+
		"y\4\2ZZzz\4\2[[{{\4\2\\\\||\2\u0143\2\3\3\2\2\2\2\5\3\2\2\2\2\7\3\2\2"+
		"\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2\2\2\21\3\2\2\2\2\23"+
		"\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2\33\3\2\2\2\2\35\3\2"+
		"\2\2\2\37\3\2\2\2\2!\3\2\2\2\2#\3\2\2\2\2%\3\2\2\2\2\'\3\2\2\2\2)\3\2"+
		"\2\2\2+\3\2\2\2\2-\3\2\2\2\2/\3\2\2\2\2\61\3\2\2\2\2\63\3\2\2\2\2\65\3"+
		"\2\2\2\2\67\3\2\2\2\29\3\2\2\2\2;\3\2\2\2\2=\3\2\2\2\2?\3\2\2\2\2A\3\2"+
		"\2\2\2C\3\2\2\2\3y\3\2\2\2\5{\3\2\2\2\7\177\3\2\2\2\t\u0081\3\2\2\2\13"+
		"\u0085\3\2\2\2\r\u0087\3\2\2\2\17\u0089\3\2\2\2\21\u008b\3\2\2\2\23\u008d"+
		"\3\2\2\2\25\u008f\3\2\2\2\27\u0091\3\2\2\2\31\u0093\3\2\2\2\33\u0095\3"+
		"\2\2\2\35\u0097\3\2\2\2\37\u0099\3\2\2\2!\u009b\3\2\2\2#\u009e\3\2\2\2"+
		"%\u00a0\3\2\2\2\'\u00a3\3\2\2\2)\u00a5\3\2\2\2+\u00a9\3\2\2\2-\u00ae\3"+
		"\2\2\2/\u00b4\3\2\2\2\61\u00b9\3\2\2\2\63\u00c0\3\2\2\2\65\u00c6\3\2\2"+
		"\2\67\u00c9\3\2\2\29\u00cb\3\2\2\2;\u00d2\3\2\2\2=\u00fd\3\2\2\2?\u0101"+
		"\3\2\2\2A\u0109\3\2\2\2C\u0114\3\2\2\2E\u011d\3\2\2\2G\u011f\3\2\2\2I"+
		"\u0121\3\2\2\2K\u0123\3\2\2\2M\u0125\3\2\2\2O\u0127\3\2\2\2Q\u0129\3\2"+
		"\2\2S\u012b\3\2\2\2U\u012d\3\2\2\2W\u012f\3\2\2\2Y\u0131\3\2\2\2[\u0133"+
		"\3\2\2\2]\u0135\3\2\2\2_\u0137\3\2\2\2a\u0139\3\2\2\2c\u013b\3\2\2\2e"+
		"\u013d\3\2\2\2g\u013f\3\2\2\2i\u0141\3\2\2\2k\u0143\3\2\2\2m\u0145\3\2"+
		"\2\2o\u0147\3\2\2\2q\u0149\3\2\2\2s\u014b\3\2\2\2u\u014d\3\2\2\2w\u014f"+
		"\3\2\2\2yz\7=\2\2z\4\3\2\2\2{|\7U\2\2|}\7G\2\2}~\7V\2\2~\6\3\2\2\2\177"+
		"\u0080\7?\2\2\u0080\b\3\2\2\2\u0081\u0082\7F\2\2\u0082\u0083\7G\2\2\u0083"+
		"\u0084\7N\2\2\u0084\n\3\2\2\2\u0085\u0086\7.\2\2\u0086\f\3\2\2\2\u0087"+
		"\u0088\7*\2\2\u0088\16\3\2\2\2\u0089\u008a\7+\2\2\u008a\20\3\2\2\2\u008b"+
		"\u008c\7\60\2\2\u008c\22\3\2\2\2\u008d\u008e\7<\2\2\u008e\24\3\2\2\2\u008f"+
		"\u0090\7&\2\2\u0090\26\3\2\2\2\u0091\u0092\7B\2\2\u0092\30\3\2\2\2\u0093"+
		"\u0094\7/\2\2\u0094\32\3\2\2\2\u0095\u0096\7]\2\2\u0096\34\3\2\2\2\u0097"+
		"\u0098\7_\2\2\u0098\36\3\2\2\2\u0099\u009a\7(\2\2\u009a \3\2\2\2\u009b"+
		"\u009c\7(\2\2\u009c\u009d\7(\2\2\u009d\"\3\2\2\2\u009e\u009f\7~\2\2\u009f"+
		"$\3\2\2\2\u00a0\u00a1\7~\2\2\u00a1\u00a2\7~\2\2\u00a2&\3\2\2\2\u00a3\u00a4"+
		"\7#\2\2\u00a4(\3\2\2\2\u00a5\u00a6\5E#\2\u00a6\u00a7\5[.\2\u00a7\u00a8"+
		"\5[.\2\u00a8*\3\2\2\2\u00a9\u00aa\5i\65\2\u00aa\u00ab\5S*\2\u00ab\u00ac"+
		"\5a\61\2\u00ac\u00ad\5q9\2\u00ad,\3\2\2\2\u00ae\u00af\5q9\2\u00af\u00b0"+
		"\5S*\2\u00b0\u00b1\5M\'\2\u00b1\u00b2\5g\64\2\u00b2\u00b3\5M\'\2\u00b3"+
		".\3\2\2\2\u00b4\u00b5\5q9\2\u00b5\u00b6\5U+\2\u00b6\u00b7\5k\66\2\u00b7"+
		"\u00b8\5S*\2\u00b8\60\3\2\2\2\u00b9\u00ba\5O(\2\u00ba\u00bb\5E#\2\u00bb"+
		"\u00bc\5I%\2\u00bc\u00bd\5M\'\2\u00bd\u00be\5k\66\2\u00be\u00bf\5i\65"+
		"\2\u00bf\62\3\2\2\2\u00c0\u00c1\5a\61\2\u00c1\u00c2\5g\64\2\u00c2\u00c3"+
		"\5K&\2\u00c3\u00c4\5M\'\2\u00c4\u00c5\5g\64\2\u00c5\64\3\2\2\2\u00c6\u00c7"+
		"\5G$\2\u00c7\u00c8\5u;\2\u00c8\66\3\2\2\2\u00c9\u00ca\t\2\2\2\u00ca8\3"+
		"\2\2\2\u00cb\u00cf\t\3\2\2\u00cc\u00ce\t\4\2\2\u00cd\u00cc\3\2\2\2\u00ce"+
		"\u00d1\3\2\2\2\u00cf\u00cd\3\2\2\2\u00cf\u00d0\3\2\2\2\u00d0:\3\2\2\2"+
		"\u00d1\u00cf\3\2\2\2\u00d2\u00d3\7\61\2\2\u00d3\u00d4\7,\2\2\u00d4\u00d8"+
		"\3\2\2\2\u00d5\u00d7\13\2\2\2\u00d6\u00d5\3\2\2\2\u00d7\u00da\3\2\2\2"+
		"\u00d8\u00d9\3\2\2\2\u00d8\u00d6\3\2\2\2\u00d9\u00db\3\2\2\2\u00da\u00d8"+
		"\3\2\2\2\u00db\u00dc\7,\2\2\u00dc\u00dd\7\61\2\2\u00dd\u00de\3\2\2\2\u00de"+
		"\u00df\b\36\2\2\u00df<\3\2\2\2\u00e0\u00e1\7/\2\2\u00e1\u00e2\7/\2\2\u00e2"+
		"\u00e5\7\"\2\2\u00e3\u00e5\7%\2\2\u00e4\u00e0\3\2\2\2\u00e4\u00e3\3\2"+
		"\2\2\u00e5\u00e9\3\2\2\2\u00e6\u00e8\n\5\2\2\u00e7\u00e6\3\2\2\2\u00e8"+
		"\u00eb\3\2\2\2\u00e9\u00e7\3\2\2\2\u00e9\u00ea\3\2\2\2\u00ea\u00f1\3\2"+
		"\2\2\u00eb\u00e9\3\2\2\2\u00ec\u00ee\7\17\2\2\u00ed\u00ec\3\2\2\2\u00ed"+
		"\u00ee\3\2\2\2\u00ee\u00ef\3\2\2\2\u00ef\u00f2\7\f\2\2\u00f0\u00f2\7\2"+
		"\2\3\u00f1\u00ed\3\2\2\2\u00f1\u00f0\3\2\2\2\u00f2\u00fe\3\2\2\2\u00f3"+
		"\u00f4\7/\2\2\u00f4\u00f5\7/\2\2\u00f5\u00fb\3\2\2\2\u00f6\u00f8\7\17"+
		"\2\2\u00f7\u00f6\3\2\2\2\u00f7\u00f8\3\2\2\2\u00f8\u00f9\3\2\2\2\u00f9"+
		"\u00fc\7\f\2\2\u00fa\u00fc\7\2\2\3\u00fb\u00f7\3\2\2\2\u00fb\u00fa\3\2"+
		"\2\2\u00fc\u00fe\3\2\2\2\u00fd\u00e4\3\2\2\2\u00fd\u00f3\3\2\2\2\u00fe"+
		"\u00ff\3\2\2\2\u00ff\u0100\b\37\2\2\u0100>\3\2\2\2\u0101\u0105\7)\2\2"+
		"\u0102\u0106\n\6\2\2\u0103\u0104\7)\2\2\u0104\u0106\7)\2\2\u0105\u0102"+
		"\3\2\2\2\u0105\u0103\3\2\2\2\u0106\u0107\3\2\2\2\u0107\u0108\7)\2\2\u0108"+
		"@\3\2\2\2\u0109\u010f\7$\2\2\u010a\u010e\n\7\2\2\u010b\u010c\7$\2\2\u010c"+
		"\u010e\7$\2\2\u010d\u010a\3\2\2\2\u010d\u010b\3\2\2\2\u010e\u0111\3\2"+
		"\2\2\u010f\u010d\3\2\2\2\u010f\u0110\3\2\2\2\u0110\u0112\3\2\2\2\u0111"+
		"\u010f\3\2\2\2\u0112\u0113\7$\2\2\u0113B\3\2\2\2\u0114\u0118\7\61\2\2"+
		"\u0115\u0117\n\b\2\2\u0116\u0115\3\2\2\2\u0117\u011a\3\2\2\2\u0118\u0116"+
		"\3\2\2\2\u0118\u0119\3\2\2\2\u0119\u011b\3\2\2\2\u011a\u0118\3\2\2\2\u011b"+
		"\u011c\7\61\2\2\u011cD\3\2\2\2\u011d\u011e\t\t\2\2\u011eF\3\2\2\2\u011f"+
		"\u0120\t\n\2\2\u0120H\3\2\2\2\u0121\u0122\t\13\2\2\u0122J\3\2\2\2\u0123"+
		"\u0124\t\f\2\2\u0124L\3\2\2\2\u0125\u0126\t\r\2\2\u0126N\3\2\2\2\u0127"+
		"\u0128\t\16\2\2\u0128P\3\2\2\2\u0129\u012a\t\17\2\2\u012aR\3\2\2\2\u012b"+
		"\u012c\t\20\2\2\u012cT\3\2\2\2\u012d\u012e\t\21\2\2\u012eV\3\2\2\2\u012f"+
		"\u0130\t\22\2\2\u0130X\3\2\2\2\u0131\u0132\t\23\2\2\u0132Z\3\2\2\2\u0133"+
		"\u0134\t\24\2\2\u0134\\\3\2\2\2\u0135\u0136\t\25\2\2\u0136^\3\2\2\2\u0137"+
		"\u0138\t\26\2\2\u0138`\3\2\2\2\u0139\u013a\t\27\2\2\u013ab\3\2\2\2\u013b"+
		"\u013c\t\30\2\2\u013cd\3\2\2\2\u013d\u013e\t\31\2\2\u013ef\3\2\2\2\u013f"+
		"\u0140\t\32\2\2\u0140h\3\2\2\2\u0141\u0142\t\33\2\2\u0142j\3\2\2\2\u0143"+
		"\u0144\t\34\2\2\u0144l\3\2\2\2\u0145\u0146\t\35\2\2\u0146n\3\2\2\2\u0147"+
		"\u0148\t\36\2\2\u0148p\3\2\2\2\u0149\u014a\t\37\2\2\u014ar\3\2\2\2\u014b"+
		"\u014c\t \2\2\u014ct\3\2\2\2\u014d\u014e\t!\2\2\u014ev\3\2\2\2\u014f\u0150"+
		"\t\"\2\2\u0150x\3\2\2\2\20\2\u00cf\u00d8\u00e4\u00e9\u00ed\u00f1\u00f7"+
		"\u00fb\u00fd\u0105\u010d\u010f\u0118\3\2\3\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}