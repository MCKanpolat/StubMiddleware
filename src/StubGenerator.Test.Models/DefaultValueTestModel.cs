using StubGenerator.Core;
using StubGenerator.Core.Attributes;

namespace StubGenerator.Test.Models
{
    public class DefaultValueTestModel
    {
        public const string defaultEmail = "default@default.com";
        public const EnTestEnum defaultEnum = EnTestEnum.Option2;
        public const int defaultInt = 123456;


        public string FirstName { get; set; }
        public string LastName { get; set; }
        [StubGeneratorDefaultValue(defaultEmail)]
        public string Email { get; set; }

        [StubGeneratorDefaultValue(defaultEnum)]
        public EnTestEnum TestEnum { get; set; }

        [StubGeneratorDefaultValue(defaultInt)]
        public int TestInt { get; set; }

        [StubGeneratorIgnore]
        public int TestIntIgnored { get; set; }

        [StubGeneratorIgnore]
        public string Country { get; set; }
    }
}
