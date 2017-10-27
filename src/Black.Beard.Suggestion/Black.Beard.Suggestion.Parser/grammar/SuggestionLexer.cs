//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.7
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Suggestion.g4 by ANTLR 4.7

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

namespace Bb.Suggestion.SuggestionParser {
using System;
using System.IO;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.7")]
[System.CLSCompliant(false)]
public partial class SuggestionLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, T__10=11, T__11=12, T__12=13, T__13=14, T__14=15, T__15=16, T__16=17, 
		T__17=18, T__18=19, T__19=20, T__20=21, T__21=22, T__22=23, T__23=24, 
		AND=25, ANDALSO=26, OR=27, XOR=28, NOT=29, K_ALL=30, K_NULL=31, K_TRUE=32, 
		K_FALSE=33, K_CURRENT_TIME=34, K_CURRENT_DATE=35, K_CURRENT_TIMESTAMP=36, 
		DIGIT=37, IDENTIFIER=38;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
		"T__9", "T__10", "T__11", "T__12", "T__13", "T__14", "T__15", "T__16", 
		"T__17", "T__18", "T__19", "T__20", "T__21", "T__22", "T__23", "AND", 
		"ANDALSO", "OR", "XOR", "NOT", "K_ALL", "K_NULL", "K_TRUE", "K_FALSE", 
		"K_CURRENT_TIME", "K_CURRENT_DATE", "K_CURRENT_TIMESTAMP", "DIGIT", "IDENTIFIER"
	};


	public SuggestionLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public SuggestionLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "';'", "'WHERE'", "'ORDER BY'", "'WITH FACETS'", "','", "'('", "')'", 
		"'.'", "':'", "'''", "''''", "'-'", "'+'", "'/'", "'*'", "'^'", "'%'", 
		"'<'", "'>'", "'='", "'<='", "'>='", "'<<'", "'>>'", "'&'", "'&&'", "'|'", 
		"'||'", "'!'", "'ALL'", "'NULL'", "'TRUE'", "'FALSE'", "'CURRENT_TIME'", 
		"'CURRENT_DATE'", "'CURRENT_TIMESTAMP'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, null, null, null, null, null, null, null, null, null, null, null, 
		null, "AND", "ANDALSO", "OR", "XOR", "NOT", "K_ALL", "K_NULL", "K_TRUE", 
		"K_FALSE", "K_CURRENT_TIME", "K_CURRENT_DATE", "K_CURRENT_TIMESTAMP", 
		"DIGIT", "IDENTIFIER"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Suggestion.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override string SerializedAtn { get { return new string(_serializedATN); } }

	static SuggestionLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static char[] _serializedATN = {
		'\x3', '\x608B', '\xA72A', '\x8133', '\xB9ED', '\x417C', '\x3BE7', '\x7786', 
		'\x5964', '\x2', '(', '\x10C', '\b', '\x1', '\x4', '\x2', '\t', '\x2', 
		'\x4', '\x3', '\t', '\x3', '\x4', '\x4', '\t', '\x4', '\x4', '\x5', '\t', 
		'\x5', '\x4', '\x6', '\t', '\x6', '\x4', '\a', '\t', '\a', '\x4', '\b', 
		'\t', '\b', '\x4', '\t', '\t', '\t', '\x4', '\n', '\t', '\n', '\x4', '\v', 
		'\t', '\v', '\x4', '\f', '\t', '\f', '\x4', '\r', '\t', '\r', '\x4', '\xE', 
		'\t', '\xE', '\x4', '\xF', '\t', '\xF', '\x4', '\x10', '\t', '\x10', '\x4', 
		'\x11', '\t', '\x11', '\x4', '\x12', '\t', '\x12', '\x4', '\x13', '\t', 
		'\x13', '\x4', '\x14', '\t', '\x14', '\x4', '\x15', '\t', '\x15', '\x4', 
		'\x16', '\t', '\x16', '\x4', '\x17', '\t', '\x17', '\x4', '\x18', '\t', 
		'\x18', '\x4', '\x19', '\t', '\x19', '\x4', '\x1A', '\t', '\x1A', '\x4', 
		'\x1B', '\t', '\x1B', '\x4', '\x1C', '\t', '\x1C', '\x4', '\x1D', '\t', 
		'\x1D', '\x4', '\x1E', '\t', '\x1E', '\x4', '\x1F', '\t', '\x1F', '\x4', 
		' ', '\t', ' ', '\x4', '!', '\t', '!', '\x4', '\"', '\t', '\"', '\x4', 
		'#', '\t', '#', '\x4', '$', '\t', '$', '\x4', '%', '\t', '%', '\x4', '&', 
		'\t', '&', '\x4', '\'', '\t', '\'', '\x3', '\x2', '\x3', '\x2', '\x3', 
		'\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', '\x3', 
		'\x3', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', '\x4', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', '\x5', '\x3', 
		'\x5', '\x3', '\x5', '\x3', '\x6', '\x3', '\x6', '\x3', '\a', '\x3', '\a', 
		'\x3', '\b', '\x3', '\b', '\x3', '\t', '\x3', '\t', '\x3', '\n', '\x3', 
		'\n', '\x3', '\v', '\x3', '\v', '\x3', '\f', '\x3', '\f', '\x3', '\f', 
		'\x3', '\r', '\x3', '\r', '\x3', '\xE', '\x3', '\xE', '\x3', '\xF', '\x3', 
		'\xF', '\x3', '\x10', '\x3', '\x10', '\x3', '\x11', '\x3', '\x11', '\x3', 
		'\x12', '\x3', '\x12', '\x3', '\x13', '\x3', '\x13', '\x3', '\x14', '\x3', 
		'\x14', '\x3', '\x15', '\x3', '\x15', '\x3', '\x16', '\x3', '\x16', '\x3', 
		'\x16', '\x3', '\x17', '\x3', '\x17', '\x3', '\x17', '\x3', '\x18', '\x3', 
		'\x18', '\x3', '\x18', '\x3', '\x19', '\x3', '\x19', '\x3', '\x19', '\x3', 
		'\x1A', '\x3', '\x1A', '\x3', '\x1B', '\x3', '\x1B', '\x3', '\x1B', '\x3', 
		'\x1C', '\x3', '\x1C', '\x3', '\x1D', '\x3', '\x1D', '\x3', '\x1D', '\x3', 
		'\x1E', '\x3', '\x1E', '\x3', '\x1F', '\x3', '\x1F', '\x3', '\x1F', '\x3', 
		'\x1F', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', ' ', '\x3', 
		'!', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '!', '\x3', '\"', '\x3', 
		'\"', '\x3', '\"', '\x3', '\"', '\x3', '\"', '\x3', '\"', '\x3', '#', 
		'\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', 
		'\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', '\x3', '#', 
		'\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', 
		'\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', '\x3', '$', 
		'\x3', '$', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', 
		'\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', 
		'\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', '\x3', '%', 
		'\x3', '%', '\x3', '&', '\x3', '&', '\x3', '\'', '\x3', '\'', '\x3', '\'', 
		'\x3', '\'', '\a', '\'', '\xEC', '\n', '\'', '\f', '\'', '\xE', '\'', 
		'\xEF', '\v', '\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', 
		'\x3', '\'', '\a', '\'', '\xF6', '\n', '\'', '\f', '\'', '\xE', '\'', 
		'\xF9', '\v', '\'', '\x3', '\'', '\x3', '\'', '\x3', '\'', '\a', '\'', 
		'\xFE', '\n', '\'', '\f', '\'', '\xE', '\'', '\x101', '\v', '\'', '\x3', 
		'\'', '\x3', '\'', '\x3', '\'', '\a', '\'', '\x106', '\n', '\'', '\f', 
		'\'', '\xE', '\'', '\x109', '\v', '\'', '\x5', '\'', '\x10B', '\n', '\'', 
		'\x2', '\x2', '(', '\x3', '\x3', '\x5', '\x4', '\a', '\x5', '\t', '\x6', 
		'\v', '\a', '\r', '\b', '\xF', '\t', '\x11', '\n', '\x13', '\v', '\x15', 
		'\f', '\x17', '\r', '\x19', '\xE', '\x1B', '\xF', '\x1D', '\x10', '\x1F', 
		'\x11', '!', '\x12', '#', '\x13', '%', '\x14', '\'', '\x15', ')', '\x16', 
		'+', '\x17', '-', '\x18', '/', '\x19', '\x31', '\x1A', '\x33', '\x1B', 
		'\x35', '\x1C', '\x37', '\x1D', '\x39', '\x1E', ';', '\x1F', '=', ' ', 
		'?', '!', '\x41', '\"', '\x43', '#', '\x45', '$', 'G', '%', 'I', '&', 
		'K', '\'', 'M', '(', '\x3', '\x2', '\b', '\x3', '\x2', '\x32', ';', '\x3', 
		'\x2', '$', '$', '\x3', '\x2', '\x62', '\x62', '\x3', '\x2', '_', '_', 
		'\x5', '\x2', '\x43', '\\', '\x61', '\x61', '\x63', '|', '\x6', '\x2', 
		'\x32', ';', '\x43', '\\', '\x61', '\x61', '\x63', '|', '\x2', '\x114', 
		'\x2', '\x3', '\x3', '\x2', '\x2', '\x2', '\x2', '\x5', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\a', '\x3', '\x2', '\x2', '\x2', '\x2', '\t', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\v', '\x3', '\x2', '\x2', '\x2', '\x2', '\r', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\xF', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x11', '\x3', '\x2', '\x2', '\x2', '\x2', '\x13', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x15', '\x3', '\x2', '\x2', '\x2', '\x2', '\x17', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\x19', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '\x1B', '\x3', '\x2', '\x2', '\x2', '\x2', '\x1D', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '\x1F', '\x3', '\x2', '\x2', '\x2', '\x2', '!', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '#', '\x3', '\x2', '\x2', '\x2', '\x2', '%', 
		'\x3', '\x2', '\x2', '\x2', '\x2', '\'', '\x3', '\x2', '\x2', '\x2', '\x2', 
		')', '\x3', '\x2', '\x2', '\x2', '\x2', '+', '\x3', '\x2', '\x2', '\x2', 
		'\x2', '-', '\x3', '\x2', '\x2', '\x2', '\x2', '/', '\x3', '\x2', '\x2', 
		'\x2', '\x2', '\x31', '\x3', '\x2', '\x2', '\x2', '\x2', '\x33', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x35', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x37', '\x3', '\x2', '\x2', '\x2', '\x2', '\x39', '\x3', '\x2', '\x2', 
		'\x2', '\x2', ';', '\x3', '\x2', '\x2', '\x2', '\x2', '=', '\x3', '\x2', 
		'\x2', '\x2', '\x2', '?', '\x3', '\x2', '\x2', '\x2', '\x2', '\x41', '\x3', 
		'\x2', '\x2', '\x2', '\x2', '\x43', '\x3', '\x2', '\x2', '\x2', '\x2', 
		'\x45', '\x3', '\x2', '\x2', '\x2', '\x2', 'G', '\x3', '\x2', '\x2', '\x2', 
		'\x2', 'I', '\x3', '\x2', '\x2', '\x2', '\x2', 'K', '\x3', '\x2', '\x2', 
		'\x2', '\x2', 'M', '\x3', '\x2', '\x2', '\x2', '\x3', 'O', '\x3', '\x2', 
		'\x2', '\x2', '\x5', 'Q', '\x3', '\x2', '\x2', '\x2', '\a', 'W', '\x3', 
		'\x2', '\x2', '\x2', '\t', '`', '\x3', '\x2', '\x2', '\x2', '\v', 'l', 
		'\x3', '\x2', '\x2', '\x2', '\r', 'n', '\x3', '\x2', '\x2', '\x2', '\xF', 
		'p', '\x3', '\x2', '\x2', '\x2', '\x11', 'r', '\x3', '\x2', '\x2', '\x2', 
		'\x13', 't', '\x3', '\x2', '\x2', '\x2', '\x15', 'v', '\x3', '\x2', '\x2', 
		'\x2', '\x17', 'x', '\x3', '\x2', '\x2', '\x2', '\x19', '{', '\x3', '\x2', 
		'\x2', '\x2', '\x1B', '}', '\x3', '\x2', '\x2', '\x2', '\x1D', '\x7F', 
		'\x3', '\x2', '\x2', '\x2', '\x1F', '\x81', '\x3', '\x2', '\x2', '\x2', 
		'!', '\x83', '\x3', '\x2', '\x2', '\x2', '#', '\x85', '\x3', '\x2', '\x2', 
		'\x2', '%', '\x87', '\x3', '\x2', '\x2', '\x2', '\'', '\x89', '\x3', '\x2', 
		'\x2', '\x2', ')', '\x8B', '\x3', '\x2', '\x2', '\x2', '+', '\x8D', '\x3', 
		'\x2', '\x2', '\x2', '-', '\x90', '\x3', '\x2', '\x2', '\x2', '/', '\x93', 
		'\x3', '\x2', '\x2', '\x2', '\x31', '\x96', '\x3', '\x2', '\x2', '\x2', 
		'\x33', '\x99', '\x3', '\x2', '\x2', '\x2', '\x35', '\x9B', '\x3', '\x2', 
		'\x2', '\x2', '\x37', '\x9E', '\x3', '\x2', '\x2', '\x2', '\x39', '\xA0', 
		'\x3', '\x2', '\x2', '\x2', ';', '\xA3', '\x3', '\x2', '\x2', '\x2', '=', 
		'\xA5', '\x3', '\x2', '\x2', '\x2', '?', '\xA9', '\x3', '\x2', '\x2', 
		'\x2', '\x41', '\xAE', '\x3', '\x2', '\x2', '\x2', '\x43', '\xB3', '\x3', 
		'\x2', '\x2', '\x2', '\x45', '\xB9', '\x3', '\x2', '\x2', '\x2', 'G', 
		'\xC6', '\x3', '\x2', '\x2', '\x2', 'I', '\xD3', '\x3', '\x2', '\x2', 
		'\x2', 'K', '\xE5', '\x3', '\x2', '\x2', '\x2', 'M', '\x10A', '\x3', '\x2', 
		'\x2', '\x2', 'O', 'P', '\a', '=', '\x2', '\x2', 'P', '\x4', '\x3', '\x2', 
		'\x2', '\x2', 'Q', 'R', '\a', 'Y', '\x2', '\x2', 'R', 'S', '\a', 'J', 
		'\x2', '\x2', 'S', 'T', '\a', 'G', '\x2', '\x2', 'T', 'U', '\a', 'T', 
		'\x2', '\x2', 'U', 'V', '\a', 'G', '\x2', '\x2', 'V', '\x6', '\x3', '\x2', 
		'\x2', '\x2', 'W', 'X', '\a', 'Q', '\x2', '\x2', 'X', 'Y', '\a', 'T', 
		'\x2', '\x2', 'Y', 'Z', '\a', '\x46', '\x2', '\x2', 'Z', '[', '\a', 'G', 
		'\x2', '\x2', '[', '\\', '\a', 'T', '\x2', '\x2', '\\', ']', '\a', '\"', 
		'\x2', '\x2', ']', '^', '\a', '\x44', '\x2', '\x2', '^', '_', '\a', '[', 
		'\x2', '\x2', '_', '\b', '\x3', '\x2', '\x2', '\x2', '`', '\x61', '\a', 
		'Y', '\x2', '\x2', '\x61', '\x62', '\a', 'K', '\x2', '\x2', '\x62', '\x63', 
		'\a', 'V', '\x2', '\x2', '\x63', '\x64', '\a', 'J', '\x2', '\x2', '\x64', 
		'\x65', '\a', '\"', '\x2', '\x2', '\x65', '\x66', '\a', 'H', '\x2', '\x2', 
		'\x66', 'g', '\a', '\x43', '\x2', '\x2', 'g', 'h', '\a', '\x45', '\x2', 
		'\x2', 'h', 'i', '\a', 'G', '\x2', '\x2', 'i', 'j', '\a', 'V', '\x2', 
		'\x2', 'j', 'k', '\a', 'U', '\x2', '\x2', 'k', '\n', '\x3', '\x2', '\x2', 
		'\x2', 'l', 'm', '\a', '.', '\x2', '\x2', 'm', '\f', '\x3', '\x2', '\x2', 
		'\x2', 'n', 'o', '\a', '*', '\x2', '\x2', 'o', '\xE', '\x3', '\x2', '\x2', 
		'\x2', 'p', 'q', '\a', '+', '\x2', '\x2', 'q', '\x10', '\x3', '\x2', '\x2', 
		'\x2', 'r', 's', '\a', '\x30', '\x2', '\x2', 's', '\x12', '\x3', '\x2', 
		'\x2', '\x2', 't', 'u', '\a', '<', '\x2', '\x2', 'u', '\x14', '\x3', '\x2', 
		'\x2', '\x2', 'v', 'w', '\a', ')', '\x2', '\x2', 'w', '\x16', '\x3', '\x2', 
		'\x2', '\x2', 'x', 'y', '\a', ')', '\x2', '\x2', 'y', 'z', '\a', ')', 
		'\x2', '\x2', 'z', '\x18', '\x3', '\x2', '\x2', '\x2', '{', '|', '\a', 
		'/', '\x2', '\x2', '|', '\x1A', '\x3', '\x2', '\x2', '\x2', '}', '~', 
		'\a', '-', '\x2', '\x2', '~', '\x1C', '\x3', '\x2', '\x2', '\x2', '\x7F', 
		'\x80', '\a', '\x31', '\x2', '\x2', '\x80', '\x1E', '\x3', '\x2', '\x2', 
		'\x2', '\x81', '\x82', '\a', ',', '\x2', '\x2', '\x82', ' ', '\x3', '\x2', 
		'\x2', '\x2', '\x83', '\x84', '\a', '`', '\x2', '\x2', '\x84', '\"', '\x3', 
		'\x2', '\x2', '\x2', '\x85', '\x86', '\a', '\'', '\x2', '\x2', '\x86', 
		'$', '\x3', '\x2', '\x2', '\x2', '\x87', '\x88', '\a', '>', '\x2', '\x2', 
		'\x88', '&', '\x3', '\x2', '\x2', '\x2', '\x89', '\x8A', '\a', '@', '\x2', 
		'\x2', '\x8A', '(', '\x3', '\x2', '\x2', '\x2', '\x8B', '\x8C', '\a', 
		'?', '\x2', '\x2', '\x8C', '*', '\x3', '\x2', '\x2', '\x2', '\x8D', '\x8E', 
		'\a', '>', '\x2', '\x2', '\x8E', '\x8F', '\a', '?', '\x2', '\x2', '\x8F', 
		',', '\x3', '\x2', '\x2', '\x2', '\x90', '\x91', '\a', '@', '\x2', '\x2', 
		'\x91', '\x92', '\a', '?', '\x2', '\x2', '\x92', '.', '\x3', '\x2', '\x2', 
		'\x2', '\x93', '\x94', '\a', '>', '\x2', '\x2', '\x94', '\x95', '\a', 
		'>', '\x2', '\x2', '\x95', '\x30', '\x3', '\x2', '\x2', '\x2', '\x96', 
		'\x97', '\a', '@', '\x2', '\x2', '\x97', '\x98', '\a', '@', '\x2', '\x2', 
		'\x98', '\x32', '\x3', '\x2', '\x2', '\x2', '\x99', '\x9A', '\a', '(', 
		'\x2', '\x2', '\x9A', '\x34', '\x3', '\x2', '\x2', '\x2', '\x9B', '\x9C', 
		'\a', '(', '\x2', '\x2', '\x9C', '\x9D', '\a', '(', '\x2', '\x2', '\x9D', 
		'\x36', '\x3', '\x2', '\x2', '\x2', '\x9E', '\x9F', '\a', '~', '\x2', 
		'\x2', '\x9F', '\x38', '\x3', '\x2', '\x2', '\x2', '\xA0', '\xA1', '\a', 
		'~', '\x2', '\x2', '\xA1', '\xA2', '\a', '~', '\x2', '\x2', '\xA2', ':', 
		'\x3', '\x2', '\x2', '\x2', '\xA3', '\xA4', '\a', '#', '\x2', '\x2', '\xA4', 
		'<', '\x3', '\x2', '\x2', '\x2', '\xA5', '\xA6', '\a', '\x43', '\x2', 
		'\x2', '\xA6', '\xA7', '\a', 'N', '\x2', '\x2', '\xA7', '\xA8', '\a', 
		'N', '\x2', '\x2', '\xA8', '>', '\x3', '\x2', '\x2', '\x2', '\xA9', '\xAA', 
		'\a', 'P', '\x2', '\x2', '\xAA', '\xAB', '\a', 'W', '\x2', '\x2', '\xAB', 
		'\xAC', '\a', 'N', '\x2', '\x2', '\xAC', '\xAD', '\a', 'N', '\x2', '\x2', 
		'\xAD', '@', '\x3', '\x2', '\x2', '\x2', '\xAE', '\xAF', '\a', 'V', '\x2', 
		'\x2', '\xAF', '\xB0', '\a', 'T', '\x2', '\x2', '\xB0', '\xB1', '\a', 
		'W', '\x2', '\x2', '\xB1', '\xB2', '\a', 'G', '\x2', '\x2', '\xB2', '\x42', 
		'\x3', '\x2', '\x2', '\x2', '\xB3', '\xB4', '\a', 'H', '\x2', '\x2', '\xB4', 
		'\xB5', '\a', '\x43', '\x2', '\x2', '\xB5', '\xB6', '\a', 'N', '\x2', 
		'\x2', '\xB6', '\xB7', '\a', 'U', '\x2', '\x2', '\xB7', '\xB8', '\a', 
		'G', '\x2', '\x2', '\xB8', '\x44', '\x3', '\x2', '\x2', '\x2', '\xB9', 
		'\xBA', '\a', '\x45', '\x2', '\x2', '\xBA', '\xBB', '\a', 'W', '\x2', 
		'\x2', '\xBB', '\xBC', '\a', 'T', '\x2', '\x2', '\xBC', '\xBD', '\a', 
		'T', '\x2', '\x2', '\xBD', '\xBE', '\a', 'G', '\x2', '\x2', '\xBE', '\xBF', 
		'\a', 'P', '\x2', '\x2', '\xBF', '\xC0', '\a', 'V', '\x2', '\x2', '\xC0', 
		'\xC1', '\a', '\x61', '\x2', '\x2', '\xC1', '\xC2', '\a', 'V', '\x2', 
		'\x2', '\xC2', '\xC3', '\a', 'K', '\x2', '\x2', '\xC3', '\xC4', '\a', 
		'O', '\x2', '\x2', '\xC4', '\xC5', '\a', 'G', '\x2', '\x2', '\xC5', '\x46', 
		'\x3', '\x2', '\x2', '\x2', '\xC6', '\xC7', '\a', '\x45', '\x2', '\x2', 
		'\xC7', '\xC8', '\a', 'W', '\x2', '\x2', '\xC8', '\xC9', '\a', 'T', '\x2', 
		'\x2', '\xC9', '\xCA', '\a', 'T', '\x2', '\x2', '\xCA', '\xCB', '\a', 
		'G', '\x2', '\x2', '\xCB', '\xCC', '\a', 'P', '\x2', '\x2', '\xCC', '\xCD', 
		'\a', 'V', '\x2', '\x2', '\xCD', '\xCE', '\a', '\x61', '\x2', '\x2', '\xCE', 
		'\xCF', '\a', '\x46', '\x2', '\x2', '\xCF', '\xD0', '\a', '\x43', '\x2', 
		'\x2', '\xD0', '\xD1', '\a', 'V', '\x2', '\x2', '\xD1', '\xD2', '\a', 
		'G', '\x2', '\x2', '\xD2', 'H', '\x3', '\x2', '\x2', '\x2', '\xD3', '\xD4', 
		'\a', '\x45', '\x2', '\x2', '\xD4', '\xD5', '\a', 'W', '\x2', '\x2', '\xD5', 
		'\xD6', '\a', 'T', '\x2', '\x2', '\xD6', '\xD7', '\a', 'T', '\x2', '\x2', 
		'\xD7', '\xD8', '\a', 'G', '\x2', '\x2', '\xD8', '\xD9', '\a', 'P', '\x2', 
		'\x2', '\xD9', '\xDA', '\a', 'V', '\x2', '\x2', '\xDA', '\xDB', '\a', 
		'\x61', '\x2', '\x2', '\xDB', '\xDC', '\a', 'V', '\x2', '\x2', '\xDC', 
		'\xDD', '\a', 'K', '\x2', '\x2', '\xDD', '\xDE', '\a', 'O', '\x2', '\x2', 
		'\xDE', '\xDF', '\a', 'G', '\x2', '\x2', '\xDF', '\xE0', '\a', 'U', '\x2', 
		'\x2', '\xE0', '\xE1', '\a', 'V', '\x2', '\x2', '\xE1', '\xE2', '\a', 
		'\x43', '\x2', '\x2', '\xE2', '\xE3', '\a', 'O', '\x2', '\x2', '\xE3', 
		'\xE4', '\a', 'R', '\x2', '\x2', '\xE4', 'J', '\x3', '\x2', '\x2', '\x2', 
		'\xE5', '\xE6', '\t', '\x2', '\x2', '\x2', '\xE6', 'L', '\x3', '\x2', 
		'\x2', '\x2', '\xE7', '\xED', '\a', '$', '\x2', '\x2', '\xE8', '\xEC', 
		'\n', '\x3', '\x2', '\x2', '\xE9', '\xEA', '\a', '$', '\x2', '\x2', '\xEA', 
		'\xEC', '\a', '$', '\x2', '\x2', '\xEB', '\xE8', '\x3', '\x2', '\x2', 
		'\x2', '\xEB', '\xE9', '\x3', '\x2', '\x2', '\x2', '\xEC', '\xEF', '\x3', 
		'\x2', '\x2', '\x2', '\xED', '\xEB', '\x3', '\x2', '\x2', '\x2', '\xED', 
		'\xEE', '\x3', '\x2', '\x2', '\x2', '\xEE', '\xF0', '\x3', '\x2', '\x2', 
		'\x2', '\xEF', '\xED', '\x3', '\x2', '\x2', '\x2', '\xF0', '\x10B', '\a', 
		'$', '\x2', '\x2', '\xF1', '\xF7', '\a', '\x62', '\x2', '\x2', '\xF2', 
		'\xF6', '\n', '\x4', '\x2', '\x2', '\xF3', '\xF4', '\a', '\x62', '\x2', 
		'\x2', '\xF4', '\xF6', '\a', '\x62', '\x2', '\x2', '\xF5', '\xF2', '\x3', 
		'\x2', '\x2', '\x2', '\xF5', '\xF3', '\x3', '\x2', '\x2', '\x2', '\xF6', 
		'\xF9', '\x3', '\x2', '\x2', '\x2', '\xF7', '\xF5', '\x3', '\x2', '\x2', 
		'\x2', '\xF7', '\xF8', '\x3', '\x2', '\x2', '\x2', '\xF8', '\xFA', '\x3', 
		'\x2', '\x2', '\x2', '\xF9', '\xF7', '\x3', '\x2', '\x2', '\x2', '\xFA', 
		'\x10B', '\a', '\x62', '\x2', '\x2', '\xFB', '\xFF', '\a', ']', '\x2', 
		'\x2', '\xFC', '\xFE', '\n', '\x5', '\x2', '\x2', '\xFD', '\xFC', '\x3', 
		'\x2', '\x2', '\x2', '\xFE', '\x101', '\x3', '\x2', '\x2', '\x2', '\xFF', 
		'\xFD', '\x3', '\x2', '\x2', '\x2', '\xFF', '\x100', '\x3', '\x2', '\x2', 
		'\x2', '\x100', '\x102', '\x3', '\x2', '\x2', '\x2', '\x101', '\xFF', 
		'\x3', '\x2', '\x2', '\x2', '\x102', '\x10B', '\a', '_', '\x2', '\x2', 
		'\x103', '\x107', '\t', '\x6', '\x2', '\x2', '\x104', '\x106', '\t', '\a', 
		'\x2', '\x2', '\x105', '\x104', '\x3', '\x2', '\x2', '\x2', '\x106', '\x109', 
		'\x3', '\x2', '\x2', '\x2', '\x107', '\x105', '\x3', '\x2', '\x2', '\x2', 
		'\x107', '\x108', '\x3', '\x2', '\x2', '\x2', '\x108', '\x10B', '\x3', 
		'\x2', '\x2', '\x2', '\x109', '\x107', '\x3', '\x2', '\x2', '\x2', '\x10A', 
		'\xE7', '\x3', '\x2', '\x2', '\x2', '\x10A', '\xF1', '\x3', '\x2', '\x2', 
		'\x2', '\x10A', '\xFB', '\x3', '\x2', '\x2', '\x2', '\x10A', '\x103', 
		'\x3', '\x2', '\x2', '\x2', '\x10B', 'N', '\x3', '\x2', '\x2', '\x2', 
		'\n', '\x2', '\xEB', '\xED', '\xF5', '\xF7', '\xFF', '\x107', '\x10A', 
		'\x2',
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
} // namespace Bb.Suggestion.SuggestionParser
