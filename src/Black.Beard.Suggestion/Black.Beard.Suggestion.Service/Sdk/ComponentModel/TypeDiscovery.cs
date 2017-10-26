using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bb.Sdk.ComponentModel
{

    /// <summary>
    /// Global context cross libraries
    /// </summary>
    public class TypeDiscovery
    {

        public TypeDiscovery(params string[] pluginsPaths)
        {

            ExcludedAssemblies = new List<string>();
            FilterAssembly = c => true;
            FilterFilename = c => true;
            Assemblies = () => AppDomain.CurrentDomain.GetAssemblies().Where(c => !ExcludedAssemblies.Contains(c.GetName().Name)).ToList();
            //OnRegisterException = e => Logger.Error(e);
            TypeDiscovery.HideAssemblyLoadException = true;

            var _h = new HashSet<string>();
            List<DirectoryInfo> _dir = new List<DirectoryInfo>();

            if (FolderBinResolver.IsWebApplication())
                _dir = FolderBinResolver.GetWebBinPath().ToList();
            else
                _dir = FolderBinResolver.GetConsoleBinPath().ToList();

            foreach (var _path in pluginsPaths)
                if (!string.IsNullOrEmpty(_path))
                    if (_h.Add(_path))
                        _dir.Add(new DirectoryInfo(_path));

            paths = _dir.Where(c => c.Exists).ToArray();

        }

        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {

            var n = new AssemblyName(args.Name);

            foreach (var baseDirectory in paths)
            {
                var fileInfo = baseDirectory.GetFiles(n.Name + ".dll").FirstOrDefault();
                if (fileInfo != null)
                {
                    var assembly = Assembly.LoadFile(fileInfo.FullName);
                    return assembly;
                }
                fileInfo = baseDirectory.GetFiles(n.Name + ".exe").FirstOrDefault();
                if (fileInfo != null)
                {
                    var assembly = Assembly.LoadFile(fileInfo.FullName);
                    return assembly;
                }
            }

            string str = string.Format("the assembly '{0}' can't be resolved in the folder '{1}'", args.Name, AppDomain.CurrentDomain.BaseDirectory);
            Console.Write(str);

            return null;

        }

        /// <summary>
        /// Return a list of type that match with the specified filter, that contained in specified assemblies
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="typeFilter">The type filter.</param>
        /// <returns></returns>
        public List<Type> Resolve(Func<Type, bool> typeFilter, params Assembly[] assemblies)
        {
            List<Type> result = new List<Type>();
            result.AddRange(Collect(typeFilter, assemblies));
            return result;
        }


        /// <summary>
        /// Return a list of type that match with the specified filter
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public List<Type> Resolve(Func<Type, bool> typeFilter)
        {
            LoadAssemblies();
            List<Type> result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(typeFilter, assemblies));
            return result;
        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public List<Type> ResolveWithAttribute(Type typeFilter)
        {
            LoadAssemblies();
            List<Type> result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(type => Attribute.GetCustomAttributes(type, typeFilter).Any(), assemblies));
            return result;
        }

        /// <summary>
        /// return a list of type that is assignable from the specified type in the assembly's list
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public List<Type> ResolveWithAttribute(Type typeFilter, params Assembly[] assemblies)
        {
            List<Type> result = new List<Type>();
            result.AddRange(Collect(type => Attribute.GetCustomAttributes(type, typeFilter).Any(), assemblies));

            return result;
        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public List<Type> Resolve(Type typeFilter)
        {
            LoadAssemblies();
            List<Type> result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(type => typeFilter.IsAssignableFrom(type) && type != typeFilter, assemblies));

            return result;
        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public List<Type> Resolve(Type typeFilter, params Assembly[] assemblies)
        {
            LoadAssemblies();
            List<Type> result = new List<Type>();
            result.AddRange(Collect(type => typeFilter.IsAssignableFrom(type) && type != typeFilter, assemblies));

            return result;
        }

        /// <summary>
        /// Load in memory all the assemblies from the directory bin.
        /// </summary>
        private void LoadAssemblies()
        {
            foreach (DirectoryInfo path in paths)
                LoadAssembliesFrom(path);
        }

        /// <summary>
        /// Load in memory all the assemblies from the specified with directory.
        /// </summary>
        /// <returns></returns>
        private void LoadAssembliesFrom(DirectoryInfo dir)
        {

            HashSet<string> _h = new HashSet<string>();

            foreach (Assembly item in Assemblies())
                _h.Add(item.GetName().Name);

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            try
            {
                var files = dir.GetFiles("*.dll").Where(c => FilterFilename(c));
                foreach (FileInfo file in files)
                {
                    var n = Path.GetFileNameWithoutExtension(file.Name);
                    if (_h.Add(n))
                    {
                        Assembly ass = null;
                        try
                        {
                            Debug.WriteLine("Loading " + file.FullName);
                            ass = Assembly.LoadFile(file.FullName);
                        }
                        catch (Exception e)
                        {
                            OnRegisterException(e);
                            Debug.WriteLine(e.ToString());
                        }
                    }
                }
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }

        }

        /// <summary>
        /// function  return the list of loaded assemblies
        /// </summary>
        private Func<IEnumerable<Assembly>> Assemblies;

        /// <summary>
        /// define a filter for filter the assemblies to use in the register
        /// </summary>
        public Func<Assembly, bool> FilterAssembly;

        /// <summary>
        /// The filter fileinfo
        /// </summary>
        public Func<FileInfo, bool> FilterFilename;

        /// <summary>
        /// The on register exception
        /// </summary>
        public static Action<Exception> OnRegisterException = e => { };

        /// <summary>
        /// The on registration event
        /// </summary>
        public static Action<string> OnRegistrationEvent = e => System.Diagnostics.Debug.WriteLine(e);

        private readonly DirectoryInfo[] paths;

        /// <summary>
        /// The exclude assemblies
        /// </summary>
        public static List<string> ExcludedAssemblies { get; private set; }

        /// <summary>
        /// Registers the specified assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        private List<Type> Collect(Func<Type, bool> typeFilter, params Assembly[] assemblies)
        {
            List<Type> result = new List<Type>();

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            try
            {
                foreach (var item in assemblies)
                    result.AddRange(Resolve(item, typeFilter));
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }

            return result;
        }

        /// <summary>
        /// Register all exported type in the specified assembly
        /// </summary>
        /// <param name="ass"></param>
        private List<Type> Resolve(Assembly ass, Func<Type, bool> typeFilter)
        {
            List<Type> result = new List<Type>();

            if (ass != null && (FilterAssembly == null || FilterAssembly(ass)))
            {
                var n = ass.GetName();
                try
                {
                    result.AddRange(RegisterIoc(ass, typeFilter));
                    Debug.WriteLine(string.Format("assembly {0} analyzed", ass.GetName().Name));
                }
                catch (Exception e)
                {
                    OnRegisterException(e);
                    Debug.WriteLine(e.ToString());
                }
            }

            return result;

        }

        private static List<Type> RegisterIoc(Assembly assembly, Func<Type, bool> typeFilter)
        {

            List<Type> typeResults = new List<Type>();

            Type[] types = new Type[0];

            try
            {
                types = assembly.GetTypes();
            }
            catch (System.Reflection.ReflectionTypeLoadException e)  // TypeLoadException e1
            {
                OnRegisterException(e);
                types = e.Types;
            }

            foreach (Type type in types)
                if (((!type.IsAbstract && !type.IsSealed) || (type.IsAbstract && type.IsSealed)) && !type.IsInterface && !type.IsGenericTypeDefinition)
                    if (typeFilter(type))
                        typeResults.Add(type);

            return typeResults;

        }

        /// <summary>
        /// Gets or sets a value indicating whether [hide assembly load exception].
        /// </summary>
        /// <value>
        /// <c>true</c> if [hide assembly load exception]; otherwise, <c>false</c>.
        /// </value>
        public static bool HideAssemblyLoadException { get; set; }

    }

}
