using Bb.Sdk.ComponentModel;
using Bb.Sdk.Expressions;
using Bb.Sdk.Factories;
using Bb.Suggestion.Models;
using Bb.Suggestion.Sdk.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.Suggestion.Service
{

    public class RuleRepository<TEntities>
        where TEntities : ISuggerableModel
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleRepository{TEntities}"/> class.
        /// </summary>
        /// <param name="pluginsPaths">The plugins paths.</param>
        public RuleRepository(params string[] pluginsPaths) : this(null, pluginsPaths)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleRepository{TEntities}" /> class.
        /// </summary>
        /// <param name="diagnostics">The diagnostics.</param>
        /// <param name="pluginsPaths">The plugins paths that contains types.</param>
        public RuleRepository(DiagnosticExpression diagnostics, params string[] pluginsPaths)
        {
            this.comparer = new RuleInfoEqualityComparer();
            this._rules = new HashSet<RuleInfo<TEntities>>(1000, this.comparer);
            this.typeRepository = new TypeDiscovery(pluginsPaths);
            this.diagnostics = diagnostics ?? new DiagnosticExpression();
        }

        /// <summary>
        /// append all types found in assemblies where type is assignable <see cref="ISpecification<TEntities>.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        public int ResolveType(params Assembly[] assemblies)
        {

            int count = 0;

            List<Type> types = null;

            if (assemblies.Length == 0)
                types = this.typeRepository.Resolve(typeof(ISpecification<TEntities>));
            else
                types = this.typeRepository.Resolve(typeof(ISpecification<TEntities>), assemblies);

            foreach (var type in types)
                count += Add(type);

            return count;
        }

        /// <summary>
        /// Adds the specified type in repository.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// <exception cref="Exception">if type is not assignable <see cref="ISpecification<TEntities>"/></exception>
        public int Add(Type type)
        {

            int count = 0;

            if (!typeof(ISpecification<TEntities>).IsAssignableFrom(type))
                throw new Exception();

            var items = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);

            foreach (ConstructorInfo method in items)
            {
                RuleNameAttribute attribute = Attribute.GetCustomAttribute(method, typeof(RuleNameAttribute)) as RuleNameAttribute;
                if (this._rules.Add(new RuleInfo<TEntities>(attribute.Name, type, method)))
                {
                    count++;
                    this._lookup = null;
                }
            }

            return count;

        }

        internal ObjectActivator<ISpecification<TEntities>> Resolve(string name, Type[] types)
        {

            if (this._lookup == null)
                this._lookup = _rules.ToLookup(c => c.Name.ToLower());


            var items = this._lookup[name.ToLower()] // rules indexed by name
                .Where(c => c.Parameters.Length == types.Length)
                .ToList();

            var crcTypes = RuleInfo.Comparer.GetHashCode(types);
            var items2 = items.Where(c => c.HashParameters == crcTypes).ToList();   // find rules where parameters match

            int count = items2.Count;
            if (count == 0)                     // if not rule match, search rules where types can assignable from input types
            {
                int length = types.Length;
                foreach (var item in items)
                {
                    bool include = true;
                    for (int i = 0; i < length; i++)
                        if (!types[i].IsAssignableFrom(item.Parameters[i].ParameterType))
                        {
                            include = false;
                            break;
                        }
                    if (include)
                        items2.Add(item);
                }

                count = items2.Count;

                if (count == 0)
                    throw new MissingMemberException(name);
            }

            else if (count > 1)
                throw new AmbiguousMatchException(name);

            var result = items2[0];

            return result.Factory;

        }

        public DiagnosticExpression Diagnostic { get { return this.diagnostics; } }

        private readonly RuleInfoEqualityComparer comparer;
        private readonly HashSet<RuleInfo<TEntities>> _rules;
        private TypeDiscovery typeRepository;
        private readonly DiagnosticExpression diagnostics;
        private ILookup<string, RuleInfo<TEntities>> _lookup;
    }

}
