namespace StubGenerator.Caching
{
    public abstract class CacheKeyGeneratorBase
    {
        public abstract string GenerateKey<T>();
    }
}