using Bb.Sdk;
using Black.Beard.Caching.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace Bb.Service
{

    public class GlobalParameterService : IGlobalParameterService
    {

        /// <summary>
        /// Initializes the <see cref="GlobalParameterService"/> class.
        /// </summary>
        static GlobalParameterService()
        {
            GlobalParameterService._methodGet = typeof(GlobalParameterService).GetMethod("GetValue");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalParameterService"/> class.
        /// </summary>
        /// <param name="storageService">The storage service.</param>
        /// <param name="cache">The cache.</param>
        /// <exception cref="ArgumentNullException">
        /// storageService
        /// or
        /// cache
        /// </exception>
        public GlobalParameterService(GlobalParameterStorageService storageService, ILocalCache cache)
        {
            this._storageService = storageService ?? throw new ArgumentNullException(nameof(storageService));
            this._cache = cache ?? throw new ArgumentNullException(nameof(cache));
            this._constant = Expression.Constant(this);
        }

        /// <summary>
        /// Sets the new value for the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void Set(string name, object value)
        {

            if (name[0] != '@')
                name = "@" + name;

            var date = DateTime.UtcNow;
            var parameter = new GlobalParameter() { Name = name, LastUpdate = date, Value = value, Type = value?.GetType() ?? typeof(object) };
            this._cache.Set(name, parameter);
            this._storageService.Set(parameter);
        }

        /// <summary>
        /// Gets the value of the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public GlobalParameter Get(string name)
        {
            if (name[0] != '@')
                name = "@" + name;

            return (GlobalParameter)this._cache.GetOrResolve(name, () => this._storageService.Get(name));
        }


        /// <summary>
        /// Gets the value of the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public object GetValue(string name)
        {
            var result = this.Get(name);
            if (result == null)
                throw new MissingMemberException($"global parameter {name} not found");
            return result.Value;
        }

        /// <summary>
        /// Deletes the variable for specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        public bool Del(string name)
        {

            if (name[0] != '@')
                name = "@" + name;

            this._cache.Del(name);
            return this._storageService.Del(name);
        }

        /// <summary>
        /// Lists of variable.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<GlobalParameter> List()
        {
            return _storageService.List().ToList();
        }

        /// <summary>
        /// Gets the an expression that resolve value of the variable.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public Expression GetVariableExpression(string name)
        {
            return Get(name).GetVariableExpression(_methodGet, this._constant);
        }

        private readonly GlobalParameterStorageService _storageService;
        private readonly ILocalCache _cache;
        private static MethodInfo _methodGet;
        private readonly Expression _constant;
    }

}
