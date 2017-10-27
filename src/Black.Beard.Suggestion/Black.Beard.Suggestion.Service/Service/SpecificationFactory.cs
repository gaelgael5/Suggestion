using Bb.Sdk.Expressions;
using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Suggestion.Service
{

    public class SpecificationFactory<TEntities> : ISpecificationFactory<TEntities>
        where TEntities : ISuggerableModel
    {

        public SpecificationFactory(RuleRepository<TEntities> repository)
        {
            this._ruleRepository = repository;
        }

        /// <summary>
        /// Gets the specified rule by specified name and arguments.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public ISpecification<TEntities> Get(string ruleName, object[] args)
        {
            Type[] types = new Type[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                object value = args[i];
                Type type = value?.GetType();
                types[i] = type;
            }

            return this.Get(ruleName, types, args);

        }

        /// <summary>
        /// Gets the specified rule name.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="types">The type.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ruleName
        /// or
        /// type
        /// or
        /// args
        /// </exception>
        public ISpecification<TEntities> Get(string ruleName, Type[] types, object[] args)
        {

            if (ruleName == null)
                throw new ArgumentNullException(nameof(ruleName));

            if (types == null)
                throw new ArgumentNullException(nameof(types));

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var ruleInfo = this._ruleRepository.Resolve(ruleName, types);
            ISpecification<TEntities> result = ruleInfo.Factory(args);
            result.Initialize(this);

            return result;

        }

        public ISpecification<TEntities> Get(RuleInfo ruleInfo, object[] args)
        {
            if (ruleInfo == null)
                throw new ArgumentNullException(nameof(ruleInfo));

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ISpecification<TEntities> result = (ruleInfo as RuleInfo<TEntities>).Factory(args);
            result.Initialize(this);

            return result;

        }

        public RuleInfo Resolve(string ruleName, Type[] types)
        {
            var ruleInfo = this._ruleRepository.Resolve(ruleName, types);
            return ruleInfo;
        }

        internal RuleRepository<TEntities> Repository { get { return this._ruleRepository; } }

        private readonly RuleRepository<TEntities> _ruleRepository;

    }

}
