using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Sdk.Factories
{


    /// <summary>
    /// IFactory base
    /// </summary>
    public interface IFactory
    {

    }

    /// <summary>
    /// I factory generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFactory<T> : IFactory
        where T : class
    {

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        T Create(params dynamic[] args);

    }

}
