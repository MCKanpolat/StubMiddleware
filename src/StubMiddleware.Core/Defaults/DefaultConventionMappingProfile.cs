using System.Collections.Generic;
using StubGenerator.Core;
using StubGenerator.Core.Conventions;

namespace StubGenerator.Defaults
{
    public class DefaultConventionMappingProfile : IConventionMappingProfile
    {
        private readonly List<IConventionMap> _conventions;
        public DefaultConventionMappingProfile()
        {
            _conventions = new List<IConventionMap>();
            _conventions.Add(new FirstnameConventionMap());
            _conventions.Add(new LastnameConvetionMap());
            _conventions.Add(new EmailConventionMap());
            _conventions.Add(new PhoneNumberConventionMap());
            _conventions.Add(new CompanyNameConventionMap());
        }

        public IEnumerable<IConventionMap> Conventions => _conventions;
    }
}
