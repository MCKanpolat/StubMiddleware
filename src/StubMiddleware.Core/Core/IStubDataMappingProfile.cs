using System.Collections.Generic;

namespace StubGenerator.Core
{
    public interface IStubDataMappingProfile
    {
        IEnumerable<IStubDataMap> Conventions { get; }
    }
}
