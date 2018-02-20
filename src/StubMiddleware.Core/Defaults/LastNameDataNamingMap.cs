using System;
using System.Reflection;
using StubGenerator.Core;

namespace StubGenerator.Defaults
{
    public class LastNameDataNamingMap : IFakeDataMap<string>
    {
        public Predicate<PropertyInfo> Condition => w => w.Name.ToLowerInvariant().Contains("name") && w.Name.ToLowerInvariant().Contains("last");

        public FakeDataType FakeDataType { get => FakeDataType.LastName; }
    }
}
