namespace StubGenerator.Core.FakeDataGenerators
{
    public class CountryValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Address.Country();
        }
    }
}
