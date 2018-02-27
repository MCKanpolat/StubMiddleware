namespace StubGenerator.Core.FakeDataGenerators
{
    public class EmailValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Internet.Email();
        }
    }
}
