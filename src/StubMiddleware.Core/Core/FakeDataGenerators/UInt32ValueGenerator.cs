using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class UInt32ValueGenerator : IValueGenerator
    {
        private static readonly Lazy<Random> _random;

        static UInt32ValueGenerator()
        {
            _random = new Lazy<Random>(() => new Random());
        }

        public object Generate()
        {
            uint thirtyBits = (uint)_random.Value.Next(1 << 30);
            uint twoBits = (uint)_random.Value.Next(1 << 2);
            return (thirtyBits << 2) | twoBits;
        }
    }
}
