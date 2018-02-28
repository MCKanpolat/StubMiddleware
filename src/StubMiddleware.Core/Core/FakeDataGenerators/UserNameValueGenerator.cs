namespace StubGenerator.Core.FakeDataGenerators
{
    public class UserNameValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Internet.UserName();
        }
    }
}
