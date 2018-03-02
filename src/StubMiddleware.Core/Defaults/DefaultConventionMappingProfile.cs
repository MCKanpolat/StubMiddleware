using System.Collections.Generic;
using StubGenerator.Core;
using StubGenerator.Core.Conventions;

namespace StubGenerator.Defaults
{
    public class DefaultConventionMappingProfile : IConventionMappingProfile
    {
        private readonly List<IConventionMap> _conventions;
        public DefaultConventionMappingProfile() => _conventions = new List<IConventionMap>
            {
                new FirstnameConventionMap(),
                new LastnameConvetionMap(),
                new EmailConventionMap(),
                new PhoneNumberConventionMap(),
                new CompanyNameConventionMap(),
                new UserNameConventionMap(),
                new StreetNameConventionMap(),
                new CountryConventionMap(),
                new ZipCodeConventionMap()
            };

        public IEnumerable<IConventionMap> Conventions => _conventions;
    }
}
