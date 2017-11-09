using Bb.Sdk.Expressions;
using Bb.Sdk.Factories;
using Bb.Specifications;
using Bb.Suggestion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Collections;
using Bb.Service;
using Bb.Sdk;

namespace Bb.Suggestion.Service
{

    public class SpecificationFactory<TEntity> : ISpecificationFactory<TEntity>
        where TEntity : ISuggerableModel
    {        

        public SpecificationFactory(RuleRepository<TEntity> repositoryRule, ConstantRepository repositoryConstant, IGlobalParameterService globalParameterService)
        {
            this._ruleRepository = repositoryRule;
            this._constantRepository = repositoryConstant;
            this._globalParameterService = globalParameterService;
        }

        #region Rules

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
        /// return registrered Rules
        /// </summary>
        /// <returns></returns>
        public IEnumerable<RuleInfo<TEntity>> Rules()
        {
            return this._ruleRepository.List();
        }

        #endregion Rules

        #region Constants

        /// <summary>
        /// Return a new expression that resolve constant.
        /// </summary>
        /// <param name="constantName">Name of the constant.</param>
        /// <returns><see cref="Expression"/> </returns>
        public Expression ResolveConstant(string constantName)
        {
            return this._constantRepository.Resolve(constantName);
        }

        /// <summary>
        /// Return a new expression that resolve constant.
        /// </summary>
        /// <param name="constantName">Name of the constant.</param>
        /// <returns><see cref="Expression"/> </returns>
        public IEnumerable<KeyValuePair<string, string>> Constants()
        {
            return this._constantRepository.List().ToList();
        }

        #endregion Constants

        #region Variables

        /// <summary>
        /// Sets the new value the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void SetVariable(string name, object value)
        {
            this._globalParameterService.Set(name, value);
        }

        /// <summary>
        /// Deletes the variable for specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        public bool DelVariable(string name)
        {
            return this._globalParameterService.Del(name);
        }

        /// <summary>
        /// Lists of variable.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GlobalParameter> Variables()
        {
            return this._globalParameterService.List();
        }

        /// <summary>
        /// Gets the an expression that resolve value of the variable.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Expression GetVariableExpression(string name)
        {
            return this._globalParameterService.GetVariableExpression(name);
        }

        public GlobalParameter ResolveVariable(string name)
        {
            return this._globalParameterService.Get(name);
        }

        #endregion Variables

        #region private

        internal RuleRepository<TEntity> RuleRepository { get { return this._ruleRepository; } }

        internal ConstantRepository ConstantRepository { get { return this._constantRepository; } }


        private readonly RuleRepository<TEntity> _ruleRepository;
        private readonly ConstantRepository _constantRepository;
        private readonly IGlobalParameterService _globalParameterService;

        #endregion private






        ///// <summary>
        ///// Gets the specified rule by specified name and arguments.
        ///// </summary>
        ///// <param name="ruleName">Name of the rule.</param>
        ///// <param name="args">The arguments.</param>
        ///// <returns></returns>
        //public ISpecification<TEntity> Get(string ruleName, object[] args)
        //{
        //    Type[] types = new Type[args.Length];

        //    for (int i = 0; i < args.Length; i++)
        //    {
        //        object value = args[i];
        //        Type type = value?.GetType();
        //        types[i] = type;
        //    }

        //    return this.Get(ruleName, types, new Expression[0], args);

        //}

        ///// <summary>
        ///// Gets the specified rule name.
        ///// </summary>
        ///// <param name="ruleName">Name of the rule.</param>
        ///// <param name="types">The type.</param>
        ///// <param name="args2">The arguments.</param>
        ///// <returns></returns>
        ///// <exception cref="ArgumentNullException">
        ///// ruleName
        ///// or
        ///// type
        ///// or
        ///// args
        ///// </exception>
        //public ISpecification<TEntity> Get(string ruleName, Type[] types, Expression[] args1, object[] args2)
        //{

        //    if (ruleName == null)
        //        throw new ArgumentNullException(nameof(ruleName));

        //    if (types == null)
        //        throw new ArgumentNullException(nameof(types));

        //    if (args2 == null)
        //        throw new ArgumentNullException(nameof(args2));

        //    var ruleInfo = this._ruleRepository.Resolve(ruleName, types);
        //    ISpecification<TEntity> result = ruleInfo.Factory(args1)(args2);
        //    result.Initialize(this);

        //    return result;

        //}

        //public ISpecification<TEntity> Get(RuleInfo ruleInfo, Expression[] args1, object[] args2)
        //{

        //    if (ruleInfo == null)
        //        throw new ArgumentNullException(nameof(ruleInfo));

        //    if (args1 == null)
        //        throw new ArgumentNullException(nameof(args1));

        //    if (args2 == null)
        //        throw new ArgumentNullException(nameof(args2));


        //    ISpecification<TEntity> _result = (ruleInfo as RuleInfo<TEntity>).Factory(args1)(args2);
        //    _result.Initialize(this);

        //    return _result;

        //}

        //public ObjectActivator<ISpecification<TEntity>> Get(RuleInfo ruleInfo, Expression[] args1)
        //{

        //    if (ruleInfo == null)
        //        throw new ArgumentNullException(nameof(ruleInfo));

        //    if (args1 == null)
        //        throw new ArgumentNullException(nameof(args1));

        //    ObjectActivator<ISpecification<TEntity>> _result = (ruleInfo as RuleInfo<TEntity>).Factory(args1);

        //    return _result;

        //}

    }

}
