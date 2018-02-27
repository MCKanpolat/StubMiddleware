using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class DateTimeValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            var startDate = new DateTime(1995, 1, 1);
            return startDate.AddDays(new Random().Next(0, (DateTime.Today - startDate).Days));
        }
    }
}
