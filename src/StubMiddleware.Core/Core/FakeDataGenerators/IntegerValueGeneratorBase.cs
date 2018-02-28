using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class IntegerValueGeneratorBase<T> : IValueGenerator where T : struct
    {
        public object Generate()
        {
            var maxValue = (int)typeof(T).GetField("MaxValue").GetValue(null);
            var minValue = (int)typeof(T).GetField("MinValue").GetValue(null);
            return new Random().Next(minValue, maxValue);
        }
    }
}
