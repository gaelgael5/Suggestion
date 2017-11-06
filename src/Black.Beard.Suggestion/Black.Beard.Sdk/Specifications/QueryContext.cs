using Bb.Suggestion.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.Specifications
{

    public class QueryContext<TEntity>
        where TEntity : ISuggerableModel
    {

        public QueryContext(ISpecificationFactory<TEntity> factory, SuggestionQueryParameter[] parameters)
        {
            this._parameter = parameters;
            this._factory = factory;            
        }


        public ISpecificationFactory<TEntity> Factory { get { return this._factory; } }

        public SuggestionQueryParameter[] Parameters { get { return this._parameter; } }


        private readonly ISpecificationFactory<TEntity> _factory;
        private readonly SuggestionQueryParameter[] _parameter;


    }

}
