using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using Bb.Sdk;
using System.Collections;

namespace Bb.Specifications
{
    public interface ISpecificationFactory<TEntity> where TEntity : ISuggerableModel
    {
        ///// <summary>
        ///// return an instance of specification for the specified rule name and types
        ///// </summary>
        ///// <param name="ruleName">Name of the rule.</param>
        ///// <param name="args">The arguments.</param>
        ///// <returns></returns>
        //ISpecification<TEntity> Get(string ruleName, object[] args);

        ///// <summary>
        ///// return an instance of specification for the specified rule name and types
        ///// </summary>
        ///// <param name="ruleName">Name of the rule.</param>
        ///// <param name="type">The type.</param>
        ///// <param name="args1">The args1.</param>
        ///// <param name="args2">The args2.</param>
        ///// <returns></returns>
        //ISpecification<TEntity> Get(string ruleName, Type[] type, Expression[] args1, object[] args2);

        /// <summary>
        /// return informations for fule for the specified rule name and types
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        RuleInfo ResolveRule(string ruleName, Type[] types);
        
        //ObjectActivator<ISpecification<TEntity>> Get(RuleInfo ruleInfo, Expression[] args1);

        /// <summary>
        /// Ruleses this instance.
        /// </summary>
        /// <returns></returns>
        IEnumerable<RuleInfo<TEntity>> Rules();

        /// <summary>
        /// Return a new expression that resolve constant.
        /// </summary>
        /// <param name="constantName">Name of the constant.</param>
        /// <returns><see cref="Expression"/> </returns>
        Expression ResolveConstant(string txt);

        IEnumerable<KeyValuePair<string, string>> Constants();


        void SetVariable(string name, object value);

        bool DelVariable(string name);

        IEnumerable<GlobalParameter> Variables();

        GlobalParameter ResolveVariable(string name);

        Expression GetVariableExpression(string name);

    }
}