using System.Collections.Generic;
using StubGenerator.Core;

namespace StubGenerator.Defaults
{
    public class DefaultStubDataMappingProfile : IStubDataMappingProfile
    {
        private readonly List<IStubDataMap> _conventions;
        public DefaultStubDataMappingProfile()
        {
            _conventions = new List<IStubDataMap>();
            _conventions.Add(new FirstNameStubDataMap());
            _conventions.Add(new LastNameStubDataMap());
            _conventions.Add(new EmailStubDataMap());
        }

        public IEnumerable<IStubDataMap> Conventions => _conventions;
    }
}
