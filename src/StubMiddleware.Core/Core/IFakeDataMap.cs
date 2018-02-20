using System;
using System.Reflection;

namespace StubGenerator.Core
{
    public interface IFakeDataMap
    {
        Predicate<PropertyInfo> Condition { get; }
        FakeDataType FakeDataType { get; }
    }
}
