using System.Threading.Tasks;
using StubGenerator.Caching;
using StubGenerator.Core;
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

        

        [Fact(DisplayName = "Cache_Key_Generator_Test")]
        public void CacheKeyGeneratorTest()
        {
            var cacheKey = _cacheKeyGenerator.GenerateKey<PersonDto>();
            
        }

        [Fact(DisplayName = "Should add PropertyInfo Cache Successfully")]
        public void Should_Add_PropertyInfos_To_Cache_Successfully()
        {
            var personData = new PersonDto();
            _stubTypeMemoryCache.Set(personData, personData.GetType().GetProperties());
            var cachedPropertyInfos = _stubTypeMemoryCache.Get(personData);
            Assert.Equal(cachedPropertyInfos.Length, personData.GetType().GetProperties().Length);
        }


        [Fact(DisplayName = "Memory_Cache_Manager_Empty_Test")]
        public void CacheManagerEmptyTest()
        {
            var personData = new PersonDto();
            _stubTypeMemoryCache.Set(personData, personData.GetType().GetProperties());
            _stubTypeMemoryCache.Clear();
            Assert.True(_stubTypeMemoryCache.IsEmpty());
        }


        [Fact(DisplayName = "Memory_Cache_Manager_Concurrency_Test")]
        public void CacheManagerConcurrencyTest()
        {
            var personData = new PersonDto();
            var mainTask = Task.Run(async () =>
             {
                 await Task.Run(() => _stubTypeMemoryCache.Set(personData, personData.GetType().GetProperties()));
                 await Task.Run(() => _stubTypeMemoryCache.Get(personData));
             });

            Assert.Null(mainTask.Exception);
        }
    }
}
