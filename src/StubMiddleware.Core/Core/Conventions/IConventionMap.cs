using StubGenerator.Core.FakeDataGenerators;
using System;
using System.Reflection;

namespace StubGenerator.Core
{
    public interface IConventionMap
    {
        Predicate<PropertyInfo> Condition { get; }
        IValueGenerator Generator { get; }
    }
}
