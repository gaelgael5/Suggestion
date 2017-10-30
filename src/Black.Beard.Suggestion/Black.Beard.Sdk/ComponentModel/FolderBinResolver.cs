using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Sdk.ComponentModel
{

    /// <summary>
    /// Folder bin resolver
    /// </summary>
    public static class FolderBinResolver
    {


        private static bool? _isSystemWebAssemblyLoaded;

        /// <summary>
        /// return value indicate if the current <see cref="global::System.AppDomain.GetAssemblies()" contains items from Microsoft technology stack Web libraries/>
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is system web assembly loaded; otherwise, <c>false</c>.
        /// </value>
        public static bool HasSystemWebAssemblyLoaded
        {
            get
            {
                if (!_isSystemWebAssemblyLoaded.HasValue)
                    _isSystemWebAssemblyLoaded = _hasSystemWebAssemblyLoaded_Impl();
                return _isSystemWebAssemblyLoaded.Value;
            }
        }

        private static bool _hasSystemWebAssemblyLoaded_Impl()
        {
            foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                if (assembly.FullName.StartsWith("System.Web,", StringComparison.OrdinalIgnoreCase))
                    return true;
            return false;
        }

        /// <summary>
        /// Gets bin path for the case the running application is a console application.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DirectoryInfo> GetConsoleBinPath()
        {
            HashSet<string> _h = new HashSet<string>();

            var appDomain = System.AppDomain.CurrentDomain;

            if (!string.IsNullOrEmpty(appDomain.RelativeSearchPath))
                if (_h.Add(appDomain.RelativeSearchPath))
                    yield return new DirectoryInfo(appDomain.RelativeSearchPath);

            if (_h.Add(appDomain.BaseDirectory))
                yield return new DirectoryInfo(appDomain.BaseDirectory);

        }

        /// <summary>
        /// Gets bin path for the case the running application is a web application
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<DirectoryInfo> GetWebBinPath()
        {

            System.Reflection.Assembly ass = System.Reflection.Assembly.LoadWithPartialName("System.Web");
            if (ass != null)
            {
                string _type = "System.Web.Compilation.BuildManager";
                Type type = ass.GetType(_type);

                if (type != null)
                {
                    var method = type.GetMethod("GetReferencedAssemblies", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                    if (method != null)
                    {
                        var list = method.Invoke(null, new object[] { }) as IEnumerable;
                        if (list != null)
                        {

                            HashSet<string> _h = new HashSet<string>();
                            var items = list.Cast<System.Reflection.Assembly>()
                                .Where(c => !c.CodeBase.ToLower().Contains(@"microsoft.net"))
                                .Where(c => !c.CodeBase.ToLower().Contains(@"/temp/"))
                                .ToList();

                            foreach (var item in items)
                            {
                                Uri uri = new Uri(item.CodeBase);
                                var file = new FileInfo(uri.AbsolutePath);
                                if (file.Exists && _h.Add(file.Directory.FullName) && file.Directory.Exists)
                                    yield return file.Directory;
                            }
                        }

                    }
                }
            }

        }

        /// <summary>
        /// Gets bin path for the case the running application is a web application
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<System.Reflection.Assembly> GetWebReferencedAssemblies()
        {
            List<System.Reflection.Assembly> items = new List<System.Reflection.Assembly>();
            System.Reflection.Assembly ass = System.Reflection.Assembly.LoadWithPartialName("System.Web");
            if (ass != null)
            {
                string _type = "System.Web.Compilation.BuildManager";
                Type type = ass.GetType(_type);

                if (type != null)
                {
                    var method = type.GetMethod("GetReferencedAssemblies", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public);
                    if (method != null)
                    {
                        var list = method.Invoke(null, new object[] { }) as IEnumerable;
                        if (list != null)
                            items.AddRange(list.OfType<System.Reflection.Assembly>());
                    }
                }
            }
            return items;

        }

        /// <summary>
        /// Gets loaded assemblies.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<System.Reflection.Assembly> GetLoadedAssemblies()
        {
            List<System.Reflection.Assembly> items = System.AppDomain.CurrentDomain.GetAssemblies().ToList();
            return items;
        }

        /// <summary>
        /// Determines whether [is web application]. Test in the configuration file is named "web.config"
        /// </summary>
        /// <returns></returns>
        public static bool IsWebApplication()
        {

            return _hasSystemWebAssemblyLoaded_Impl();

            //var appDomain = System.AppDomain.CurrentDomain;

            //var file = new FileInfo(appDomain.SetupInformation.ConfigurationFile);
            //var fileName = file.Name;

            //string path = appDomain.BaseDirectory;

            //return (fileName.ToLower() == "web.config");

        }

    }


}
