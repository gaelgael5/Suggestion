using Bb.Sdk;
using System;
using System.Collections.Generic;

namespace Bb.Service
{
    public interface IGlobalParameterStorageService
    {

        /// <summary>
        /// Deletes the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        bool Del(string name);

        /// <summary>
        /// Return the list of variable
        /// </summary>
        /// <returns></returns>
        IEnumerable<GlobalParameter> List();

        /// <summary>
        /// Gets the value for the specified name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        GlobalParameter Get(string name);

        /// <summary>
        /// Sets the new value for specified name.
        /// </summary>
        /// <param name="parameter">The parameter to save.</param>
        void Set(GlobalParameter parameter);

    }
}