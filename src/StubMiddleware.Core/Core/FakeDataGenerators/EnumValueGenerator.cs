using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class EnumValueGenerator : IValueGenerator
    {
        private readonly Type _enumType;

        private static readonly Lazy<Random> _random;
        static EnumValueGenerator()
        {
            _random = new Lazy<Random>(() => new Random());
        }

        public EnumValueGenerator(Type enumType)
        {
            _enumType = enumType ?? throw new ArgumentNullException(nameof(enumType));
        }

        public object Generate()
        {
            var values = Enum.GetValues(_enumType);
            return values.GetValue(_random.Value.Next(values.Length));
        }
    }
}
