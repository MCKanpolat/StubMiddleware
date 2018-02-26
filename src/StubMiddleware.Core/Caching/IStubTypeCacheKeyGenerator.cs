namespace StubGenerator.Caching
{
    public interface IStubTypeCacheKeyGenerator
    {
        string GenerateKey<T>();
    }
}