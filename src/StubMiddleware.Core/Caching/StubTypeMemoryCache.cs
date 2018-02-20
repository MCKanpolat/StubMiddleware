using System.Collections.Concurrent;
using StubGenerator.Core;

namespace StubGenerator.Caching
{
    public class StubTypeMemoryCache : IStubTypeCache
    {
        private readonly ConcurrentDictionary<string, StubTypeItem> Cache;
        private readonly CacheKeyGeneratorBase _cacheKeyGenerator;
        public StubTypeMemoryCache(CacheKeyGeneratorBase cacheKeyGenerator)
        {
            Cache = new ConcurrentDictionary<string, StubTypeItem>();
            _cacheKeyGenerator = cacheKeyGenerator;
        }

        public StubTypeItem Get<T>(T instance) where T : class
        {
            string cacheKey = _cacheKeyGenerator.GenerateKey<T>();
            Cache.TryGetValue(cacheKey, out StubTypeItem result);
            return result;
        }

        public bool Set<T>(T instance, StubTypeItem stubTypeItem) where T : class
        {
            string cacheKey = _cacheKeyGenerator.GenerateKey<T>();
            return Cache.TryAdd(cacheKey, stubTypeItem);
        }

        public void Clear() => Cache.Clear();

        public bool IsEmpty()
        {
            return Cache.Count == 0;
        }
    }
}
