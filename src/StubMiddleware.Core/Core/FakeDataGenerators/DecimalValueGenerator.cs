using StubGenerator.Extensions;
using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class DecimalValueGenerator : IValueGenerator
    {
        private static readonly Lazy<Random> _random;
        static DecimalValueGenerator()
        {
            _random = new Lazy<Random>(() => new Random());
        }

        public object Generate()
        {
            return _random.Value.NextDecimal();
        }
    }
}
