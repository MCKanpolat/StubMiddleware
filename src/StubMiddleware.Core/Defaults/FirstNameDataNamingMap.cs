using System;
using System.Reflection;
using StubGenerator.Core;

namespace StubGenerator.Defaults
{
    public class FirstNameDataNamingMap : IFakeDataMap<string>
    {
        public Predicate<PropertyInfo> Condition => w => w.Name.ToLowerInvariant().Contains("name") && w.Name.ToLowerInvariant().Contains("first");

        public FakeDataType FakeDataType { get => FakeDataType.FirstName; }
    }
}
