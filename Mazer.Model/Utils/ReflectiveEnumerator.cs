using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mazer.Core.Utils
{
    internal static class ReflectiveEnumerator
    {
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class
        {
            return Assembly.GetAssembly(typeof(T)).GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T)))
                .Select(x => (T)Activator.CreateInstance(x, constructorArgs));
        }
    }
}