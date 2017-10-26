using Bb.Sdk.Expressions;
using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bb.Suggestion.Service
{

    public class SpecificationFactory<TEntities>
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
        /// <param name="type">The type.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// ruleName
        /// or
        /// type
        /// or
        /// args
        /// </exception>
        public ISpecification<TEntities> Get(string ruleName, Type[] type, object[] args)
        {

            if (ruleName == null)
                throw new ArgumentNullException(nameof(ruleName));

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            var activator = this._ruleRepository.Resolve(ruleName, type);
            ISpecification<TEntities> result = activator(args);
            result.Initialize(this);
            return result;
        }

        public RuleRepository<TEntities> Repository { get { return this._ruleRepository; } }

        private readonly RuleRepository<TEntities> _ruleRepository;

    }

}
