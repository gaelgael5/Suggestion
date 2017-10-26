using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Suggestion.SuggestionParser
{

    public class QueryParser
    {

        public List<Exception> Exceptions { get; }

        public QueryParser()
        {

            //var grammar = new SuggestionGrammar();
            //this.parser = new Parser(grammar);
            this.Exceptions = new List<Exception>();

        }

        public SuggestionQuery Parse(string sourceText)
        {

            if (sourceText == null)
                throw new ArgumentNullException(nameof(sourceText));

            SuggestionQuery result = null;

            try
            {

                var stream = CharStreams.fromstring(sourceText);
                var lexer = new SuggestionLexer(stream);
                var token = new CommonTokenStream(lexer);
                var parser = new SuggestionParser(token) { BuildParseTree = true };
                var context = parser.sql_stmt();

                foreach (IParseTree ast in context.children)
                {

                    switch (ast)
                    {

                        case Bb.Suggestion.SuggestionParser.SuggestionParser.Select_stmtContext stmtContext:
                            SelectVisitor visitor = new SelectVisitor();
                            visitor.Visit(ast);
                            result = visitor.Result;
                            break;

                        default:
                            if (System.Diagnostics.Debugger.IsAttached)
                                System.Diagnostics.Debugger.Break();
                            break;
                    }

                }

            }
            catch (Exception e)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                    System.Diagnostics.Debugger.Break();
                throw;
            }

            if (result != null)
                result.Source = sourceText;

            return result;
   
        }

    }

}



//if (result.Status == ParseTreeStatus.Error)
//{

//    bool stop = false;
//    if (result.Status == ParseTreeStatus.Error)
//    {

//        foreach (var item in result.ParserMessages)
//        {

//            StringBuilder sb = new StringBuilder();

//            sb.Append("Error on query: '");
//            sb.Append(sourceText);
//            sb.AppendLine("'");
//            sb.Append(" ");
//            sb.Append(item.Message);
//            sb.Append(" ");
//            sb.AppendLine($"Position {item.Location.Position} at line {item.Location.Line} and column {item.Location.Column} ");

//            var e = GrammarErrorLevel.NoError;

//            switch (item.Level)
//            {
//                case Irony.ErrorLevel.Info:
//                    e = GrammarErrorLevel.Info;
//                    break;
//                case Irony.ErrorLevel.Warning:
//                    e = GrammarErrorLevel.Warning;
//                    break;
//                case Irony.ErrorLevel.Error:
//                    e = GrammarErrorLevel.Error;
//                    stop = true;
//                    break;
//            }

//            this.Exceptions.Add(new Irony.Parsing.GrammarErrorException(sb.ToString(), new GrammarError(e, item.ParserState, sb.ToString())));

//        }

//        if (stop)
//            throw this.Exceptions[0];

//    }

//}

//var r = result.Root;
//SuggestionParserVisitor visitor = new SuggestionParserVisitor();
//visitor.Visit(result.Root);
