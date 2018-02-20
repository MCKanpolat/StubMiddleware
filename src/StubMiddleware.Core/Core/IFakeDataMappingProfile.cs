using System.Collections.Generic;

namespace StubGenerator.Core
{
    public interface IFakeDataMappingProfile
    {
        IEnumerable<IFakeDataMap> Conventions { get; }
    }
}
