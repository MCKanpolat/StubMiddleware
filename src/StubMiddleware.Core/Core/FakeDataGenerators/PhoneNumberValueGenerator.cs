namespace StubGenerator.Core.FakeDataGenerators
{
    public class PhoneNumberValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Phone.Number();
        }
    }
}
