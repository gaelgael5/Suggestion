using Bb.Sdk.Expressions;
using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Bb.Suggestion.Service
{

    public class SpecificationFactory<TEntities> : ISpecificationFactory<TEntities>
        where TEntities : ISuggerableModel
    {

        public SpecificationFactory(RuleRepository<TEntities> repositoryRule, ConstantRepository repositoryConstant)
        {
            this._ruleRepository = repositoryRule;
            this._constantRepository = repositoryConstant;
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

        public  Func<ISpecification<TEntities>> Get(RuleInfo ruleInfo, object[] args)
        {

            if (ruleInfo == null)
                throw new ArgumentNullException(nameof(ruleInfo));

            if (args == null)
                throw new ArgumentNullException(nameof(args));

            Func<ISpecification<TEntities>> _fnc = () =>
            {

                object[] _args = new object[args.Length];
                for (int i = 0; i < _args.Length; i++)
                {
                    var value = args[i];
                    if (value is Func<object> r)
                        value = r();

                    _args[i] = value;
                }

                ISpecification<TEntities> _result = (ruleInfo as RuleInfo<TEntities>).Factory(_args);
                _result.Initialize(this);

                return _result;

            };           

            return _fnc;

        }

        /// <summary>
        /// return rule for the specified rule name and types.
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public RuleInfo ResolveRule(string ruleName, Type[] types)
        {
            var ruleInfo = this._ruleRepository.Resolve(ruleName, types);
            return ruleInfo;
        }

        /// <summary>
        /// Return a new expression that resolve constant.
        /// </summary>
        /// <param name="constantName">Name of the constant.</param>
        /// <returns><see cref="Expression"/> </returns>
        public Expression ResolveConstant(string constantName)
        {
            return this._constantRepository.Resolve(constantName);
        }

        internal RuleRepository<TEntities> RuleRepository { get { return this._ruleRepository; } }

        internal ConstantRepository ConstantRepository { get { return this._constantRepository; } }

        private readonly RuleRepository<TEntities> _ruleRepository;
        private readonly ConstantRepository _constantRepository;

    }

}
