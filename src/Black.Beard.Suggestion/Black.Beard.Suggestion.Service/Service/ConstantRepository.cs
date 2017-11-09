using Bb.Attributes;
using Bb.Sdk.ComponentModel;
using Bb.Sdk.Expressions;
using Bb.Sdk.Factories;
using Bb.Suggestion.Models;
using Bb.Suggestion.Sdk.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Bb.Suggestion.Service
{

    public class ConstantRepository
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantRepository" /> class.
        /// </summary>
        /// <param name="pluginsPaths">The plugins paths that contains types.</param>
        public ConstantRepository(params string[] pluginsPaths)
        {
            this._constants = new Dictionary<string, box>();
            this.typeRepository = new TypeDiscovery(pluginsPaths);
            ResolveRuleType(typeof(ConstantRepository).Assembly);
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
                types = this.typeRepository.ResolveWithAttribute(typeof(ConstantRepositoryAttribute));
            else
                types = this.typeRepository.ResolveWithAttribute(typeof(ConstantRepositoryAttribute), assemblies);

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
            var items = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var instance = Activator.CreateInstance(type);

            foreach (MethodInfo method in items)
            {

                ConstantNameAttribute attribute = Attribute.GetCustomAttribute(method, typeof(ConstantNameAttribute)) as ConstantNameAttribute;
                if (attribute != null)
                {

                    string name = attribute.Name;
                    DescriptionAttribute _descritpionAttribute = Attribute.GetCustomAttribute(method, typeof(DescriptionAttribute)) as DescriptionAttribute;

                    var b = new box(name, method, instance , _descritpionAttribute?.Description ?? string.Empty);
                    if (!this._constants.ContainsKey(name))
                    {
                        this._constants.Add(name, b);
                        count++;
                    }
                }
            }

            return count;

        }

        public Expression Resolve(string name)
        {

            box b;

            var _name = name.ToLower();

            if (this._constants.TryGetValue(_name, out b))
                return b.GetExpression();

            else // 4 unit test
            {
                if (!_name.StartsWith("$"))
                {
                    _name = "$" + _name;
                    if (this._constants.TryGetValue(_name, out b))
                        return b.GetExpression();
                }

            }

            return null;

        }

        private readonly Dictionary<string, box> _constants;
        private TypeDiscovery typeRepository;

        private class box
        {

            private string name;
            private readonly MethodInfo method;
            private object instance;
            private readonly Func<Expression> _call;
            public readonly string description;

            public box(string name, MethodInfo method, object instance, string description)
            {

                this.name = name;
                this.method = method;
                this.instance = instance;
                this.description = description;

                var lbd = Expression.Lambda<Func<Expression>>(Expression.Call(Expression.Constant(instance), method));

                this._call = lbd.Compile();

            }

            internal Expression GetExpression()
            {
                return this._call();
            }

        }

        internal IEnumerable<KeyValuePair<string, string>> List()
        {
            foreach (var item in this._constants)
                yield return new KeyValuePair<string, string>(item.Key, item.Value.description);
        }

    }

}
