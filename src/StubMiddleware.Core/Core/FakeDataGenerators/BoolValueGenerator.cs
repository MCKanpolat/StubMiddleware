using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class BoolValueGenerator : IValueGenerator
    {
        private static readonly Lazy<Random> _random;
        static BoolValueGenerator()
        {
            _random = new Lazy<Random>(() => new Random());
        }

        public object Generate()
        {
            return _random.Value.NextDouble() >= 0.5;
        }
    }
}
