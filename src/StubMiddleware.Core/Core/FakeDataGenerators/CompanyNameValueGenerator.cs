using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class CompanyNameValueGenerator : IValueGenerator
    {
        public object Generate()
        {
            return Faker.Company.Name();
        }
    }
}
