using System;
using System.Reflection;
using StubGenerator.Core;

namespace StubGenerator.Defaults
{
    public class LastNameStubDataMap : IStubDataMap<string>
    {
        public Predicate<PropertyInfo> Condition => w => w.Name.ToLowerInvariant().Contains("name") && w.Name.ToLowerInvariant().Contains("last");

        public StubDataType StubDataType { get => StubDataType.LastName; }
    }
}
