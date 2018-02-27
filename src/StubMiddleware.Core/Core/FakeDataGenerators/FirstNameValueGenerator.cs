namespace StubGenerator.Core.FakeDataGenerators
{
    public class FirstNameValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Name.First();
        }
    }
}
