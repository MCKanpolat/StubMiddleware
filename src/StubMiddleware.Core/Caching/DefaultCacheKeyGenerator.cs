namespace StubGenerator.Caching
{
    public sealed class DefaultCacheKeyGenerator : CacheKeyGeneratorBase
    {
        public override string GenerateKey<T>()
        {
            var refType = typeof(T);
            return $"{refType.Assembly.GetName().Name}_{refType.FullName}";
        }
    }
}
