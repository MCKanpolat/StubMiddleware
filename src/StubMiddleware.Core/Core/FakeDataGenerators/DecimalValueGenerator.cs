using StubGenerator.Extensions;
using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class DecimalValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return new Random().NextDecimal();
        }
    }
}
