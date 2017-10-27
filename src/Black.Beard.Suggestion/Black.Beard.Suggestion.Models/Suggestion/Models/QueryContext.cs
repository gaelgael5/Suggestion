using Bb.Suggestion.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Suggestion.Models
{

    public class QueryContext<TEntities>
        where TEntities : ISuggerableModel
    {

        public QueryContext(ISpecificationFactory<TEntities> factory)
        {

            this._factory = factory;

        }

        public ISpecificationFactory<TEntities> Factory { get { return this._factory; } }

        private readonly ISpecificationFactory<TEntities> _factory;

    }

}
