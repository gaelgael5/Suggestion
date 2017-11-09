using Bb.Sdk;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Service
{

    /// <summary>
    /// manage variables
    /// </summary>
    public interface IGlobalParameterService
    {

        /// <summary>
        /// Deletes the variable for specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        bool Del(string name);

        /// <summary>
        /// Gets the value of the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        GlobalParameter Get(string name);

        /// <summary>
        /// Lists of variable.
        /// </summary>
        /// <returns></returns>
        IEnumerable<GlobalParameter> List();

        /// <summary>
        /// Sets the new value for specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        void Set(string name, object value);

        /// <summary>
        /// Gets the an expression that resolve value of the variable.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Expression GetVariableExpression(string name);
    }

}