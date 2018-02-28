namespace StubGenerator.Caching
{
    public sealed class DefaultStubTypeCacheKeyGenerator : IStubTypeCacheKeyGenerator
    {
        public string GenerateKey<T>()
        {
            var refType = typeof(T);
            if (refType.IsGenericType)
            {
                return $"{refType.Assembly.GetName().Name}_{refType.GetGenericTypeDefinition().FullName}";
            }
            return $"{refType.Assembly.GetName().Name}_{refType.FullName}";
        }
    }
}
