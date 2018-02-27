using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class GuidValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Guid.NewGuid();
        }
    }
}
