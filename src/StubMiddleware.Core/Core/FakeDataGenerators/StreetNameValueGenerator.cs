namespace StubGenerator.Core.FakeDataGenerators
{
    public class StreetNameValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Address.StreetName();
        }
    }
}
