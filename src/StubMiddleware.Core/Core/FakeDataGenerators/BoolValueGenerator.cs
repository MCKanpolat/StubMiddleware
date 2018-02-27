using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class BoolValueGenerator : IValueGenerator
    {
        private readonly Random _random;
        public BoolValueGenerator()
        {
            _random = new Random();
        }
        public object Generate()
        {
            return _random.NextDouble() >= 0.5;
        }
    }
}
