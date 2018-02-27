namespace StubGenerator.Core.FakeDataGenerators
{
    public class RandomStringValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Lorem.GetFirstWord();
        }
    }
}
