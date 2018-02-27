namespace StubGenerator.Core.FakeDataGenerators
{
    public class LastNameValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Name.Last();
        }
    }
}
