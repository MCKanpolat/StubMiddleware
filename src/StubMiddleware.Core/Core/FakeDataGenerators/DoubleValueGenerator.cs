using System;
namespace StubGenerator.Core.FakeDataGenerators
{
    public class DoubleValueGenerator : IValueGenerator
    {
        private static readonly Random _random;
        static DoubleValueGenerator() => _random = new Random();

        public object Generate()
        {
            return _random.NextDouble();
        }
    }
}
