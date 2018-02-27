using System.Collections.Generic;

namespace StubGenerator.Core
{
    public interface IConventionMappingProfile
    {
        IEnumerable<IConventionMap> Conventions { get; }
    }
}
