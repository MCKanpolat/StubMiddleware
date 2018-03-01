using System.Threading.Tasks;
using StubGenerator.Caching;
using StubGenerator.Test.Models;
using Xunit;

namespace StubGenerator.Test
{
    public class CacheManagerTests
    {
        private readonly IStubTypeCacheKeyGenerator _cacheKeyGenerator;
        private readonly IStubTypeCache _stubTypeMemoryCache;

        public CacheManagerTests()
        {
            _cacheKeyGenerator = new DefaultStubTypeCacheKeyGenerator();
            _stubTypeMemoryCache = new MemoryStubTypeCache(_cacheKeyGenerator);
        }

        [Fact(DisplayName = "Cache Key Generator Test")]
        public void CacheKeyGeneratorTest()
        {
            var cacheKey = _cacheKeyGenerator.GenerateKey<PersonDto>();
            Assert.NotEmpty(cacheKey);
        }

        [Fact(DisplayName = "Should Add PropertyInfo Cache Successfully")]
        public void Should_Add_PropertyInfos_To_Cache_Successfully()
        {
            var personData = new PersonDto();
            _stubTypeMemoryCache.Set(personData, personData.GetType().GetProperties());
            var cachedPropertyInfos = _stubTypeMemoryCache.Get(personData);
            Assert.Equal(cachedPropertyInfos.Length, personData.GetType().GetProperties().Length);
        }


        [Fact(DisplayName = "Ensure Memory Cache Manager Empty")]
        public void CacheManagerEmptyTest()
        {
            var personData = new PersonDto();
            _stubTypeMemoryCache.Set(personData, personData.GetType().GetProperties());
            _stubTypeMemoryCache.Clear();
            Assert.True(_stubTypeMemoryCache.IsEmpty());
        }


        [Fact(DisplayName = "Memory Cache Manager Concurrency")]
        public void CacheManagerConcurrencyTest()
        {
            var personData = new PersonDto();
            var mainTask = Task.Run(async () =>
             {
                 await Task.Run(() => _stubTypeMemoryCache.Set(personData, personData.GetType().GetProperties())).ConfigureAwait(false);
                 await Task.Run(() => _stubTypeMemoryCache.Get(personData)).ConfigureAwait(false);
             });

            Assert.Null(mainTask.Exception);
        }
    }
}
