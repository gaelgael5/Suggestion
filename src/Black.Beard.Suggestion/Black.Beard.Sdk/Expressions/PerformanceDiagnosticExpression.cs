﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Sdk.Expressions
{

    public class PerformanceDiagnosticExpression
    {

        //static DiagnosticExpression()
        //{
        //    DiagnosticExpression._instance = new Lazy<DiagnosticExpression>();
        //}

        public PerformanceDiagnosticExpression()
        {
            this._dic = new Dictionary<int, Diagnostic>();
        }

        //public static DiagnosticExpression Instance { get { return _instance.Value; } }

        public bool DiagnosticMode { get; set; }

        public void Append(int crc, long elapsedTicks)
        {

            Diagnostic diagnostic;

            if (!this._dic.TryGetValue(crc, out diagnostic))
                lock (_lock)
                    if (!this._dic.TryGetValue(crc, out diagnostic))
                        this._dic.Add(crc, diagnostic = new Diagnostic(crc));

            diagnostic.Append(elapsedTicks);


        }

        //private static readonly Lazy<DiagnosticExpression> _instance;
        private readonly Dictionary<int, Diagnostic> _dic;
        private volatile object _lock = new object();

        public Diagnostic Get(Type type)
        {
            int crc = type.GetHashCode();
            Diagnostic diagnostic;
            this._dic.TryGetValue(crc, out diagnostic);

            return diagnostic;

        }

    }

}
