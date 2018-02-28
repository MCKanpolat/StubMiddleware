namespace StubGenerator.Core.FakeDataGenerators
{
    public class CityValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Address.City();
        }
    }
}
