using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PrismUnity
{
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Parses the version number.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns>Version.</returns>
        public static Version ParseVersionNumber(Assembly assembly)
        {
            var assemblyName = new AssemblyName(assembly.FullName);
            return assemblyName.Version;
        }
    }
}
