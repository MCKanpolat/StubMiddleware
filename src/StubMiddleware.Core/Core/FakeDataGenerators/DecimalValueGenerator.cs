using StubGenerator.Extensions;
using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class DecimalValueGenerator : IValueGenerator
    {
        private static readonly Random _random;
        static DecimalValueGenerator() => _random = new Random();
        public object Generate()
        {
            return _random.NextDecimal();
        }
    }
}
