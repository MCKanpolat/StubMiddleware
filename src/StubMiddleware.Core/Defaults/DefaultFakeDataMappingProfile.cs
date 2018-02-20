using System.Collections.Generic;
using StubGenerator.Core;

namespace StubGenerator.Defaults
{
    public class DefaultFakeDataMappingProfile : IFakeDataMappingProfile
    {
        private readonly List<IFakeDataMap> _conventions;
        public DefaultFakeDataMappingProfile()
        {
            _conventions = new List<IFakeDataMap>();
            _conventions.Add(new FirstNameDataNamingMap());
            _conventions.Add(new LastNameDataNamingMap());
            _conventions.Add(new EmailFakeDataNamingMap());
        }

        public IEnumerable<IFakeDataMap> Conventions => _conventions;
    }
}
