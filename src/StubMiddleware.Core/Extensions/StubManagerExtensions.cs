using System;
using System.Linq;
using System.Reflection;

namespace StubGenerator.Core
{
    public static class StubManagerExtensions
    {
        private static Type LoadType(string typeName)
        {
            if (string.IsNullOrWhiteSpace(typeName))
            {
                throw new ArgumentException("message", nameof(typeName));
            }
            var result = Type.GetType(typeName);
            if (result == null)
                throw new TypeLoadException($"The type '{typeName}' couldn't be loaded");
            return result;
        }

        public static object InvokeCreateNew(this IStubManager stubManager, string typeName)
        {
            return stubManager.InvokeCreateNew(typeName, Constants.DefaultListSize);
        }

        public static object InvokeCreateNew(this IStubManager stubManager, string typeName, int subItemSize)
        {
            if (stubManager == null)
            {
                throw new ArgumentNullException(nameof(stubManager));
            }

            if (string.IsNullOrWhiteSpace(typeName))
            {
                throw new ArgumentException("message", nameof(typeName));
            }

            if (subItemSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(subItemSize), "Subitem Size must be positive number!");
            }

            var type = LoadType(typeName);


            MethodInfo method = typeof(IStubManager).GetMethods().FirstOrDefault(w => w.Name == "CreateNew" && w.GetParameters().Count() == 2);
            MethodInfo genericMethod = method.MakeGenericMethod(type);
            return genericMethod.Invoke(stubManager, new object[] { subItemSize, null });
        }

        public static object InvokeCreateListOfSize(this IStubManager stubManager, string typeName, int size, int subItemSize)
        {
            if (stubManager == null)
            {
                throw new ArgumentNullException(nameof(stubManager));
            }

            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), "List Size must be positive number!");
            }

            if (subItemSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(subItemSize), "Subitem Size must be positive number!");
            }

            var type = LoadType(typeName);
            MethodInfo method = typeof(IStubManager).GetMethods().FirstOrDefault(w => w.Name == "CreateListOfSize" && w.GetParameters().Count() == 3);
            MethodInfo genericMethod = method.MakeGenericMethod(type);
            return genericMethod.Invoke(stubManager, parameters: new object[] { size, subItemSize, null });
        }
    }
}
