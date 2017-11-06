﻿using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Bb.Specifications;
using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Suggestion.SuggestionParser
{

    public class QueryParser<TEntity>
        where TEntity : ISuggerableModel
    {

        public List<Exception> Exceptions { get; }

        public QueryParser(QueryContext<TEntity> context)
        {
            this._context = context;
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
                var context = parser.stmt_list();
                
                foreach (IParseTree ast in context.children)
                {
                    SelectVisitor<TEntity> visitor = new SelectVisitor<TEntity>(this._context);
                    visitor.Visit(ast);
                    result = visitor.Result;
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


        public  QueryContext<TEntity> Context { get { return this._context; } }

        private readonly QueryContext<TEntity> _context;


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
