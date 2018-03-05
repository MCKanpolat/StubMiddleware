using System;
using System.Threading;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class FloatValueGeneratorBase<T> : IValueGenerator where T : struct
    {
#pragma warning disable S2743 // Static fields should not be used in generic types
        private static readonly Lazy<Random> _random;
#pragma warning restore S2743 // Static fields should not be used in generic types

        static FloatValueGeneratorBase()
        {
            _random = new Lazy<Random>(() => new Random());
        }

        public object Generate()
        {
            object randomValue = (long)(_random.Value.NextDouble() * Int64.MaxValue);
            return Convert.ChangeType(randomValue, typeof(T));
        }
    }
}
