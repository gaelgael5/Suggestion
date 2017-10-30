using Bb.Suggestion.Sdk.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Sdk.ComponentModel
{


    [System.Diagnostics.DebuggerDisplay("{RuleName}")]
    public class BusinessAction<TContext>
    {
        public Func<TContext, bool> Action { get; internal set; }
        public string RuleName { get; internal set; }
        public Type Type { get; internal set; }
    }

    public static class MethodDiscovery<TContext>
    {
                
        /// <summary>
        /// Permet de retourner la liste des methodes d'evaluation disponibles dans les types fournis.
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<BusinessAction<TContext>> GetActions(params Type[] types)
        {

            List<BusinessAction<TContext>> _result = new List<BusinessAction<TContext>>();

            foreach (var type in types)
            {

                var items = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public);

                foreach (ConstructorInfo method in items)
                {

                    RuleNameAttribute attribute = Attribute.GetCustomAttribute(method, typeof(RuleNameAttribute)) as RuleNameAttribute;
                    if (attribute != null)
                    {

                        var argumentCOntext = Expression.Parameter(typeof(TContext), "context");
                        
                        //Func<TContext, bool> @delegate = Expression.Lambda<Func<TContext, bool>>
                        //(
                        //    Expression.Call(method, new Expression[] 
                        //    {
                        //        argumentCOntext
                        //    }), new ParameterExpression[] {  argumentCOntext }
                        //).Compile();

                        //_result.Add(new BusinessAction()
                        //{
                        //    Action  = @delegate,
                        //    Type = type,
                        //    RuleName = attribute.DisplayName,
                        //    ExigenceCdc = attribute.ExigenceCdc,
                        //    RuleNameSfd = attribute.ExigenceSfd
                        //});                        

                    }

                }

            }

            return _result;

        }

        /// <summary>
        /// Return the list of method
        /// </summary>
        /// <param name="type"></param>
        /// <param name="returnType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static IEnumerable<MethodInfo> GetMethods(Type type, Type returnType, params Type[] parameters)
        {

            var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public).Where(c => c.ReturnType == returnType).ToList();

            foreach (MethodInfo item in methods)
            {
                var _parameters = item.GetParameters();
                if (_parameters.Length != parameters.Length)
                    continue;


                for (int i = 0; i < parameters.Length; i++)
                {
                    var _p1 = _parameters[i];
                    var _p2 = parameters[i];
                    if (_p1.ParameterType == parameters[i])
                        yield return item;
                }
            }

        }

    }

}
