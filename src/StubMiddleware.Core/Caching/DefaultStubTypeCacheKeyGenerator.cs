namespace StubGenerator.Caching
{
    public sealed class DefaultStubTypeCacheKeyGenerator : IStubTypeCacheKeyGenerator
    {
        public string GenerateKey<T>()
        {
            var refType = typeof(T);
            return $"{refType.Assembly.GetName().Name}_{refType.FullName}";
        }
    }
}
