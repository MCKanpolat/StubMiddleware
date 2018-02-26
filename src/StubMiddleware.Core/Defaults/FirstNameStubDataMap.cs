using System;
using System.Reflection;
using StubGenerator.Core;

namespace StubGenerator.Defaults
{
    public class FirstNameStubDataMap : IStubDataMap<string>
    {
        public Predicate<PropertyInfo> Condition => w => w.Name.ToLowerInvariant().Contains("name") && w.Name.ToLowerInvariant().Contains("first");

        public StubDataType StubDataType { get => StubDataType.FirstName; }
    }
}
