using System;
using System.Reflection;
using StubGenerator.Core;

namespace StubGenerator.Defaults
{
    public class EmailStubDataMap : IStubDataMap<string>
    {
        public Predicate<PropertyInfo> Condition => w => w.Name.Contains("mail");

        public StubDataType StubDataType { get => StubDataType.Email; }
    }
}
