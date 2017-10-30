using System;
using Bb.Sdk.Expressions;
using Bb.Suggestion.Models;
using System.Linq.Expressions;

namespace Bb.Suggestion.Service
{
    public interface ISpecificationFactory<TEntities> where TEntities : ISuggerableModel
    {
        /// <summary>
        /// return an instance of specification for the specified rule name and types
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        ISpecification<TEntities> Get(string ruleName, object[] args);

        /// <summary>
        /// return an instance of specification for the specified rule name and types
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="type">The type.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        ISpecification<TEntities> Get(string ruleName, Type[] type, object[] args);

        /// <summary>
        /// return informations for fule for the specified rule name and types
        /// </summary>
        /// <param name="ruleName">Name of the rule.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        RuleInfo ResolveRule(string ruleName, Type[] types);

        /// <summary>
        /// return an instance of specification for the specified rule name and types
        /// </summary>
        /// <param name="rule">The rule.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        Func<ISpecification<TEntities>> Get(RuleInfo rule, object[] args);

        /// <summary>
        /// Return a new expression that resolve constant.
        /// </summary>
        /// <param name="constantName">Name of the constant.</param>
        /// <returns><see cref="Expression"/> </returns>
        Expression ResolveConstant(string txt);

    }
}