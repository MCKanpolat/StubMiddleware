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
            services.AddSingleton<IConventionMappingProfile, DefaultConventionMappingProfile>();
            services.AddSingleton<IStubTypeCacheKeyGenerator, DefaultStubTypeCacheKeyGenerator>();
            services.AddSingleton<IStubTypeCache, MemoryStubTypeCache>();
            services.AddSingleton<IStubManager, StubManager>();
        }

        public static void AddStubMiddleware<TStubDataMappingProfile, TCacheKeyGenerator, TStubTypeCache>(this IServiceCollection services, StubMiddlewareOptions stubMiddlewareOptions)
            where TStubDataMappingProfile : class, IConventionMappingProfile
            where TCacheKeyGenerator : class, IStubTypeCacheKeyGenerator
            where TStubTypeCache : class, IStubTypeCache
        {
            services.AddSingleton<StubManagerOptions>(stubMiddlewareOptions);
            services.AddSingleton<IConventionMappingProfile, TStubDataMappingProfile>();
            services.AddSingleton<IStubTypeCacheKeyGenerator, TCacheKeyGenerator>();
            services.AddSingleton<IStubTypeCache, TStubTypeCache>();
            services.AddSingleton<IStubManager, StubManager>();
        }

        public static void AddStubMiddleware<TStubDataMappingProfile>(this IServiceCollection services, StubMiddlewareOptions stubMiddlewareOptions)
            where TStubDataMappingProfile : class, IConventionMappingProfile
        {
            services.AddSingleton<StubManagerOptions>(stubMiddlewareOptions);
            services.AddSingleton<IConventionMappingProfile, TStubDataMappingProfile>();
            services.AddSingleton<IStubTypeCacheKeyGenerator, DefaultStubTypeCacheKeyGenerator>();
            services.AddSingleton<IStubTypeCache, MemoryStubTypeCache>();
            services.AddSingleton<IStubManager, StubManager>();
        }

        public static void AddStubMiddleware<TStubDataMappingProfile, TStubTypeCacheKeyGenerator>(this IServiceCollection services, StubMiddlewareOptions stubMiddlewareOptions)
            where TStubDataMappingProfile : class, IConventionMappingProfile
            where TStubTypeCacheKeyGenerator : class, IStubTypeCacheKeyGenerator
        {
            services.AddSingleton<StubManagerOptions>(stubMiddlewareOptions);
            services.AddSingleton<IConventionMappingProfile, TStubDataMappingProfile>();
            services.AddSingleton<IStubTypeCacheKeyGenerator, TStubTypeCacheKeyGenerator>();
            services.AddSingleton<IStubTypeCache, MemoryStubTypeCache>();
            services.AddSingleton<IStubManager, StubManager>();
        }
    }
}
