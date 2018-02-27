using System;
using System.Linq;
using System.Reflection;

namespace StubGenerator.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsSimple(this Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                return IsSimple((type.GetGenericArguments()[0]).GetTypeInfo());
            }
            return type.IsPrimitive
              || type.IsEnum
              || type.Equals(typeof(string))
              || type.Equals(typeof(decimal))
              || type.Equals(typeof(DateTime))
              || type.Equals(typeof(Enum))
              || type.Equals(typeof(Guid));
        }

        public static bool IsCollectionType(this Type type)
        {
            return type.GetInterfaces().Any(s => s.Name == "IEnumerable") && type != typeof(string);
        }

        public static bool IsCollectionType(PropertyInfo propertyInfo)
        {
            return propertyInfo.PropertyType.GetInterfaces().Any(t => t.Name == "IEnumerable");
        }
    }
}
