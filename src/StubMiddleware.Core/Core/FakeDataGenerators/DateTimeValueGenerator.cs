using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class DateTimeValueGenerator : IValueGenerator
    {
        private static readonly Random _random;
        static DateTimeValueGenerator() => _random = new Random();
        public object Generate()
        {
            var startDate = new DateTime(1995, 1, 1);
            return startDate.AddDays(_random.Next(0, (DateTime.Today - startDate).Days));
        }
    }
}
