﻿using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class IntegerValueGeneratorBase<T> : IValueGenerator where T : struct
    {
#pragma warning disable S2743 // Static fields should not be used in generic types
        private static readonly Lazy<Random> _random;
#pragma warning restore S2743 // Static fields should not be used in generic types

        static IntegerValueGeneratorBase()
        {
            _random = new Lazy<Random>(() => new Random());
        }

        public object Generate()
        {
            var maxValue = Convert.ToInt32(Convert.ChangeType(typeof(T).GetField("MaxValue").GetValue(null), typeof(T)));
            var minValue = Convert.ToInt32(Convert.ChangeType(typeof(T).GetField("MinValue").GetValue(null), typeof(T)));
            var randomValue = _random.Value.Next(minValue, maxValue);
            return Convert.ChangeType(randomValue, typeof(T));
        }
    }
}
