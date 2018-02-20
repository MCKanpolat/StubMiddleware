using StubGenerator.Core;

namespace StubGenerator.Caching
{
    public interface IStubTypeCache
    {
        void Clear();
        StubTypeItem Get<T>(T instance) where T : class;
        bool Set<T>(T instance, StubTypeItem stubTypeItem) where T : class;
        bool IsEmpty();
    }
}