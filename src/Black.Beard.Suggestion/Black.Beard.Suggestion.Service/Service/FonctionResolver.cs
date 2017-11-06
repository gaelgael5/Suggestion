using Bb.Specifications;
using Bb.Suggestion.Models;
using System;

namespace Bb.Suggestion.Service
{

    internal class FonctionResolver<TEntity> : IFunctionResolver<TEntity> where TEntity : ISuggerableModel
    {


        public FonctionResolver(RuleRepository<TEntity> ruleRepository)
        {
            this.ruleRepository = ruleRepository;
        }

        public Func<TEntity, bool> Filter { get; set; }

        public int MaxDistance { get; set; }

        public Origin Origin { get; set; }

        public void Initialize(ServiceRequest request)
        {
            
        }

        private RuleRepository<TEntity> ruleRepository;

    }

}