using System.Threading.Tasks;
using StubGenerator.Caching;
using StubGenerator.Core;
using StubGenerator.Defaults;
using StubGenerator.Test.Models;
using Xunit;

namespace StubGenerator.Test
{
    public class CacheManagerTests
    {
        private readonly IStubTypeCacheKeyGenerator _cacheKeyGenerator;
        private readonly StubTypeCacheManager _stubTypeCacheManager;
        private readonly IStubTypeCache _stubTypeMemoryCache;
        private readonly IStubManager _stubManager;

        public CacheManagerTests()
        {
            _cacheKeyGenerator = new DefaultStubTypeCacheKeyGenerator();
            _stubTypeMemoryCache = new StubTypeMemoryCache(_cacheKeyGenerator);
            _stubTypeCacheManager = new StubTypeCacheManager(_stubTypeMemoryCache);
            var stubManagerOptions = new StubManagerOptions() { AutoGenerateUnknown = true, AutoResolveByNaming = true };
            _stubManager = new StubManager(stubManagerOptions, _stubTypeCacheManager, new DefaultStubDataMappingProfile());
        }

        [Fact(DisplayName = "Cache_Key_Generator_Test")]
        public void CacheKeyGeneratorTest()
        {
            var cacheKey = _cacheKeyGenerator.GenerateKey<PersonDto>();
            Assert.NotEmpty(cacheKey);
        }


        [Fact(DisplayName = "Memory_Cache_Manager_Empty_Test")]
        public void CacheManagerEmptyTest()
        {
            var stubDto = _stubManager.CreateNew<PersonDto>();
            var stubTypeItem = new StubTypeItem();
            _stubTypeCacheManager.Set(stubDto, stubTypeItem);
            _stubTypeCacheManager.Clear();
            Assert.Null(_stubTypeCacheManager.Get(stubDto));
            Assert.True(_stubTypeCacheManager.IsEmpty());
        }


        [Fact(DisplayName = "Memory_Cache_Manager_Concurrency_Test")]
        public void CacheManagerConcurrencyTest()
        {
            var stubDto = _stubManager.CreateNew<PersonDto>();
            var stubTypeItem = new StubTypeItem();

            var mainTask = Task.Run(async () =>
             {
                 await Task.Run(() => _stubTypeMemoryCache.Set(stubDto, stubTypeItem));
                 await Task.Run(() => _stubTypeMemoryCache.Get(stubDto));
             });

            Assert.Null(mainTask.Exception);
        }
    }
}
