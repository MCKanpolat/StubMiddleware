using Microsoft.Extensions.DependencyInjection;
using StubGenerator.Caching;
using StubGenerator.Core;
using StubGenerator.Defaults;

namespace StubMiddleware
{
    public static class StubMiddlewareExtensions
    {
        public static void AddStubMiddlewareWithDefaults(this IServiceCollection services)
        {
            var stubMiddlewareOptions = new StubMiddlewareOptions();
            services.AddSingleton<StubManagerOptions>(stubMiddlewareOptions);
            services.AddSingleton<IStubDataMappingProfile, DefaultStubDataMappingProfile>();
            services.AddSingleton<IStubTypeCacheKeyGenerator, DefaultStubTypeCacheKeyGenerator>();
            services.AddSingleton<IStubTypeCache, StubTypeMemoryCache>();
            services.AddSingleton<IStubTypeCacheManager, StubTypeCacheManager>();
            services.AddSingleton<IStubManager, StubManager>();
        }

        public static void AddStubMiddleware<TStubDataMappingProfile, TCacheKeyGenerator, TStubTypeCache>(this IServiceCollection services, StubMiddlewareOptions stubMiddlewareOptions)
            where TStubDataMappingProfile : class, IStubDataMappingProfile
            where TCacheKeyGenerator : class, IStubTypeCacheKeyGenerator
            where TStubTypeCache : class, IStubTypeCache
        {
            services.AddSingleton<StubManagerOptions>(stubMiddlewareOptions);
            services.AddSingleton<IStubDataMappingProfile, TStubDataMappingProfile>();
            services.AddSingleton<IStubTypeCacheKeyGenerator, TCacheKeyGenerator>();
            services.AddSingleton<IStubTypeCache, TStubTypeCache>();
            services.AddSingleton<IStubTypeCacheManager, StubTypeCacheManager>();
            services.AddSingleton<IStubManager, StubManager>();
        }

        public static void AddStubMiddleware<TStubDataMappingProfile>(this IServiceCollection services, StubMiddlewareOptions stubMiddlewareOptions)
            where TStubDataMappingProfile : class, IStubDataMappingProfile
        {
            services.AddSingleton<StubManagerOptions>(stubMiddlewareOptions);
            services.AddSingleton<IStubDataMappingProfile, TStubDataMappingProfile>();
            services.AddSingleton<IStubTypeCacheKeyGenerator, DefaultStubTypeCacheKeyGenerator>();
            services.AddSingleton<IStubTypeCache, StubTypeMemoryCache>();
            services.AddSingleton<IStubTypeCacheManager, StubTypeCacheManager>();
            services.AddSingleton<IStubManager, StubManager>();
        }

        public static void AddStubMiddleware<TStubDataMappingProfile, TStubTypeCacheKeyGenerator>(this IServiceCollection services, StubMiddlewareOptions stubMiddlewareOptions)
            where TStubDataMappingProfile : class, IStubDataMappingProfile
            where TStubTypeCacheKeyGenerator : class, IStubTypeCacheKeyGenerator
        {
            services.AddSingleton<StubManagerOptions>(stubMiddlewareOptions);
            services.AddSingleton<IStubDataMappingProfile, TStubDataMappingProfile>();
            services.AddSingleton<IStubTypeCacheKeyGenerator, TStubTypeCacheKeyGenerator>();
            services.AddSingleton<IStubTypeCache, StubTypeMemoryCache>();
            services.AddSingleton<IStubTypeCacheManager, StubTypeCacheManager>();
            services.AddSingleton<IStubManager, StubManager>();
        }
    }
}
