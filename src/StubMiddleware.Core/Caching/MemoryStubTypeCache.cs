using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace StubGenerator.Caching
{
    public class MemoryStubTypeCache : IStubTypeCache
    {
        private readonly ConcurrentDictionary<string, PropertyInfo[]> _cache = new ConcurrentDictionary<string, PropertyInfo[]>();
        private readonly IStubTypeCacheKeyGenerator _cacheKeyGenerator;

        public MemoryStubTypeCache()
            : this(new DefaultStubTypeCacheKeyGenerator())
        {
        }

        public MemoryStubTypeCache(IStubTypeCacheKeyGenerator cacheKeyGenerator)
        {
            _cacheKeyGenerator = cacheKeyGenerator ?? throw new ArgumentNullException(nameof(cacheKeyGenerator));
        }

        public PropertyInfo[] Get<T>(T instance) where T : class
        {
            string cacheKey = _cacheKeyGenerator.GenerateKey<T>();
            _cache.TryGetValue(cacheKey, out PropertyInfo[] result);
            return result;
        }

        public PropertyInfo[] GetOrAdd<T>(T instance, PropertyInfo[] propertyInfos) where T : class
        {
            var cacheKey = _cacheKeyGenerator.GenerateKey<T>();
            return _cache.GetOrAdd(cacheKey, i => { return propertyInfos; });
        }

        public bool Set<T>(T instance, PropertyInfo[] stubTypeItem) where T : class
        {
            string cacheKey = _cacheKeyGenerator.GenerateKey<T>();
            return _cache.TryAdd(cacheKey, stubTypeItem);
        }

        public void Clear() => _cache.Clear();

        public bool IsEmpty() => _cache.Count == 0;
    }
}
