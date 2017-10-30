using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Sdk.Factories
{


    /// <summary>
    /// Factory provider for use with IOC. faster that Activator method
    /// </summary>
    /// <example lang="C#">Bb.Sdk.Factories.Factory&lt;object&gt; factory = new Bb.Sdk.Factories.Factory&lt;object&gt;(_type, new Type[] { });
    /// instance = factory.Create();
    /// </example>
    public class FactoryProvider : IFactoryProvider
    {

        /// <summary>
        /// Resolve types argument and Creates an optimized factory for the specified arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public IFactory<T> Create<T>(params dynamic[] args)
            where T : class
        {
            var types = GetTypes(args);
            Factory<T> fac = new Factory<T>(types);
            return fac;
        }

        /// <summary>
        /// Creates an optimized factory for the specified arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public IFactory<T> CreateWithTypes<T>(params Type[] types)
            where T : class
        {
            Factory<T> fac = new Factory<T>(types);
            return fac;
        }

        /// <summary>
        /// Resolve types argument and Creates an optimized factory for the specified arguments. The real type instance is the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The real type instance.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public IFactory<T> CreateFrom<T>(Type type, params dynamic[] args)
            where T : class
        {
            var types = GetTypes(args);
            Factory<T> fac = new Factory<T>(type, types);
            return fac;
        }

        /// <summary>
        /// Creates an optimized factory for the specified arguments. The real type instance is the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The real type instance.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public IFactory<T> CreateFromWithTypes<T>(Type type, params Type[] types)
            where T : class
        {
            Factory<T> fac = new Factory<T>(type, types);
            return fac;
        }

        internal static Type[] GetTypes(dynamic[] args)
        {
            var ty = args
                .Select(c => c.GetType())
                .Cast<Type>()
                .ToArray();
            return ty;
        }

    }
}
