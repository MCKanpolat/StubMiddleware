using StubGenerator.Core;

namespace StubGenerator.Caching
{
    public class StubTypeCacheManager : IStubTypeCacheManager
    {
        readonly IStubTypeCache _cache;
        public StubTypeCacheManager(IStubTypeCache cache)
        {
            _cache = cache;
        }

        public StubTypeItem Get<T>(T instance) where T : class
        {
            return _cache.Get(instance);
        }

        public bool Set<T>(T instance, StubTypeItem stubTypeItem) where T : class
        {
            return _cache.Set(instance, stubTypeItem);
        }

        public void Clear() => _cache.Clear();

        public bool IsEmpty() => _cache.IsEmpty();
    }
}
