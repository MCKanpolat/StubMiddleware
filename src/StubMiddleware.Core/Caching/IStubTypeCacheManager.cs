using StubGenerator.Core;

namespace StubGenerator.Caching
{
    public interface IStubTypeCacheManager
    {
        void Clear();
        StubTypeItem Get<T>(T instance) where T : class;
        bool IsEmpty();
        bool Set<T>(T instance, StubTypeItem stubTypeItem) where T : class;
    }
}