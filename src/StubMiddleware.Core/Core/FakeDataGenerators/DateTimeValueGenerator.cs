using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class DateTimeValueGenerator : IValueGenerator
    {
        private static readonly Lazy<Random> _random;
        static DateTimeValueGenerator()
        {
            _random = new Lazy<Random>(() => new Random());
        }

        public object Generate()
        {
            var startDate = new DateTime(1900, 1, 1);
            return startDate.AddDays(_random.Value.Next(0, (DateTime.Today - startDate).Days));
        }
    }
}
