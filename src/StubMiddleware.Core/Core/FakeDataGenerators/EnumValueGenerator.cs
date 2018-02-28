using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class EnumValueGenerator : IValueGenerator
    {
        private readonly Type _enumType;

        private static readonly Random _random;
        static EnumValueGenerator() => _random = new Random();

        public EnumValueGenerator(Type enumType)
        {
            _enumType = enumType ?? throw new ArgumentNullException(nameof(enumType));
        }

        public object Generate()
        {
            var values = Enum.GetValues(_enumType);
            return values.GetValue(_random.Next(values.Length));
        }
    }
}
