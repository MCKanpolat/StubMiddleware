using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace StubGenerator.Core
{
    public static class StubManagerExtensions
    {
        private static readonly Regex genericTypeRegex = new Regex("<(.+?)>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static Type LoadType(string typeName)
        {
            if (string.IsNullOrWhiteSpace(typeName))
            {
                throw new ArgumentException("message", nameof(typeName));
            }
            Type result = null;
            var match = genericTypeRegex.Match(typeName);
            if (match.Success)
            {
                var matchValue = match.Value;
                var outerClassName = typeName.Replace(matchValue, "");
                var innerClassNames = matchValue.Trim('<', '>').Split(';');
                var genericArgumentTypes = new HashSet<Type>();

                foreach (var innerClassName in innerClassNames)
                {
                    var innerType = Type.GetType(innerClassName, false);
                    if (innerType == null)
                        throw new TypeLoadException($"The type '{innerClassName}' couldn't be loaded");

                    genericArgumentTypes.Add(innerType);
                }

                if (!outerClassName.Contains("`"))
                {
                    //If generic argument count doesn't specified
                    //Rewrite generic class name with generic argument count
                    var splittedClassName = outerClassName.Split(',');
                    if (splittedClassName.Count()!=2)
                        throw new TypeLoadException($"The type '{outerClassName}' couldn't be loaded");
                    outerClassName = $"{splittedClassName[0]}`{genericArgumentTypes.Count}, {splittedClassName[1]}";
                }

                var outerType = Type.GetType(outerClassName, false);
                if (outerType == null)
                    throw new TypeLoadException($"The type '{outerClassName}' couldn't be loaded");

                if (!outerType.IsGenericType)
                    throw new TypeAccessException($"The type '{outerClassName}' must be a generic class");

                if (outerType.GetGenericArguments().Count() != genericArgumentTypes.Count)
                    throw new TypeAccessException($"The type '{outerClassName}' generic arguments mismatch");

                result = outerType.MakeGenericType(genericArgumentTypes.ToArray());
            }
            else
            {
                result = Type.GetType(typeName, false);
            }

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
