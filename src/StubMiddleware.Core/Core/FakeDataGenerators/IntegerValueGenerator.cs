using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class IntegerValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return new Random().Next(0, int.MaxValue);
        }
    }
}
