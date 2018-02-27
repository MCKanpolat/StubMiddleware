using System.Collections.Concurrent;
using StubGenerator.Core;
using System.Reflection;

namespace StubGenerator.Caching
{
    public class MemoryStubTypeCache : IStubTypeCache
    {
        private readonly ConcurrentDictionary<string, PropertyInfo[]> Cache;
        private readonly IStubTypeCacheKeyGenerator _cacheKeyGenerator;

        public MemoryStubTypeCache()
            :this(new DefaultStubTypeCacheKeyGenerator())
        {
        }

        public MemoryStubTypeCache(IStubTypeCacheKeyGenerator cacheKeyGenerator)
        {
            Cache = new ConcurrentDictionary<string, PropertyInfo[]>();
            _cacheKeyGenerator = cacheKeyGenerator;
        }

        public PropertyInfo[] Get<T>(T instance) where T : class
        {
            string cacheKey = _cacheKeyGenerator.GenerateKey<T>();
            Cache.TryGetValue(cacheKey, out PropertyInfo[] result);
            return result;
        }

        public PropertyInfo[] GetOrAdd<T>(T instance, PropertyInfo[] propertyInfos) where T : class
        {
            var cacheKey = _cacheKeyGenerator.GenerateKey<T>();
            return Cache.GetOrAdd(cacheKey, i => { return propertyInfos; });
        }

        public bool Set<T>(T instance, PropertyInfo[] stubTypeItem) where T : class
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
