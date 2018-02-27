using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class EnumValueGenerator : IValueGenerator
    {
        private readonly Type _enumType;

        public EnumValueGenerator(Type enumType)
        {
            _enumType = enumType ?? throw new ArgumentNullException(nameof(enumType));
        }

        public object Generate()
        {
            var values = Enum.GetValues(_enumType);
            return values.GetValue(new Random().Next(values.Length));
        }
    }
}
