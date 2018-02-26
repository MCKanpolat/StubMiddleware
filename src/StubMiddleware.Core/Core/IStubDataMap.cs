using System;
using System.Reflection;

namespace StubGenerator.Core
{
    public interface IStubDataMap
    {
        Predicate<PropertyInfo> Condition { get; }
        StubDataType StubDataType { get; }
    }
}
