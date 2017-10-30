using Bb.Sdk.ComponentModel;
using Bb.Sdk.Expressions;
using Bb.Sdk.Factories;
using Bb.Suggestion.Models;
using Bb.Suggestion.Sdk.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Bb.Suggestion.Service
{

    public class RuleRepository<TEntities> : IRuleRepository
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
        public RuleRepository(PerformanceDiagnosticExpression diagnostics, params string[] pluginsPaths)
        {
            this.comparer = new RuleInfoEqualityComparer();
            this._rules = new HashSet<RuleInfo<TEntities>>(1000, this.comparer);
            this.typeRepository = new TypeDiscovery(pluginsPaths);
            this.diagnostics = diagnostics ?? new PerformanceDiagnosticExpression();
        }

        /// <summary>
        /// append all types found in assemblies where type is assignable <see cref="ISpecification<TEntities>.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        public int ResolveRuleType(params Assembly[] assemblies)
        {

            int count = 0;

            List<Type> types = null;

            if (assemblies.Length == 0)
            {
                types = this.typeRepository.Resolve(typeof(ISpecification<TEntities>));
            }
            else
            {
                types = this.typeRepository.Resolve(typeof(ISpecification<TEntities>), assemblies);
            }

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

        public RuleInfo<TEntities> Resolve(string name, Type[] types)
        {

            if (this._lookup == null)
                this._lookup = _rules.ToLookup(c => c.Name.ToLower());

            var items = this._lookup[name.ToLower()] // rules indexed by name
                .Where(c => c.Parameters.Length == types.Length)
                .ToList();

            if (items.Count == 0)
            {

                StringBuilder sb = new StringBuilder();
                sb.Append($"missing method {name}({ string.Join(',', types.Select(c => c.Name)) }).");

                items = this._lookup[name.ToLower()].ToList();
                if (items.Count > 0)
                {
                    sb.AppendLine($" Please considere other method '{name}' exists.");
                    foreach (var item in items)
                    {
                        var t = $"{name}({string.Join(',', item.Parameters.Select(c => c.ParameterType.Name))})";
                        sb.AppendLine(t);
                    }
                }

                sb.Append($" You can show all methods with the command 'SHOW METHODS' or 'SHOW METHOD \"{name}\"'.");

                throw new SyntaxErrorException(sb.ToString());

            }

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

            return result;

        }

        public PerformanceDiagnosticExpression Diagnostic { get { return this.diagnostics; } }

        private readonly RuleInfoEqualityComparer comparer;
        private readonly HashSet<RuleInfo<TEntities>> _rules;
        private TypeDiscovery typeRepository;
        private readonly PerformanceDiagnosticExpression diagnostics;
        private ILookup<string, RuleInfo<TEntities>> _lookup;
    }

}
