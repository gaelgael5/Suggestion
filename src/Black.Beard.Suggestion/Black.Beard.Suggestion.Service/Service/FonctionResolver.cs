using Bb.Suggestion.Models;
using System;

namespace Bb.Suggestion.Service
{

    internal class FonctionResolver<TEntities> : IFunctionResolver<TEntities> where TEntities : ISuggerableModel
    {


        public FonctionResolver(RuleRepository<TEntities> ruleRepository)
        {
            this.ruleRepository = ruleRepository;
        }

        public Func<TEntities, bool> Filter { get; set; }

        public int MaxDistance { get; set; }

        public Origin Origin { get; set; }

        public void Initialize(ServiceRequest request)
        {
            
        }

        private RuleRepository<TEntities> ruleRepository;

    }

}