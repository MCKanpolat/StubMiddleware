namespace StubGenerator.Core.FakeDataGenerators
{
    public class ZipCodeValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Address.ZipCode();
        }
    }
}
