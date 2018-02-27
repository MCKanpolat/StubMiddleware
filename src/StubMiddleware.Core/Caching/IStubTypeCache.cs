using StubGenerator.Core;
using System.Reflection;

namespace StubGenerator.Caching
{
    public interface IStubTypeCache
    {
        void Clear();
        PropertyInfo[] Get<T>(T instance) where T : class;
        PropertyInfo[] GetOrAdd<T>(T instance, PropertyInfo[] propertyInfos) where T : class;
        bool Set<T>(T instance, PropertyInfo[] stubTypeItem) where T : class;
        bool IsEmpty();
    }
}