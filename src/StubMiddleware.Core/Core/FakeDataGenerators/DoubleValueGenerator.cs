﻿using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class DoubleValueGenerator : IValueGenerator
    {
        private static readonly Lazy<Random> _random;
        static DoubleValueGenerator()
        {
            _random = new Lazy<Random>(() => new Random());
        }

        public object Generate()
        {
            return _random.Value.NextDouble();
        }
    }
}
