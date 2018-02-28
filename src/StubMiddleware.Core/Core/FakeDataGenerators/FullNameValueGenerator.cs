namespace StubGenerator.Core.FakeDataGenerators
{
    public class FullNameValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Name.FullName();
        }
    }
}
