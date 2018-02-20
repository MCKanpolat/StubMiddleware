using System;
using System.Reflection;
using StubGenerator.Core;

namespace StubGenerator.Defaults
{
    public class EmailFakeDataNamingMap : IFakeDataMap<string>
    {
        public Predicate<PropertyInfo> Condition => w => w.Name.Contains("mail");

        public FakeDataType FakeDataType { get => FakeDataType.Email; }
    }
}
