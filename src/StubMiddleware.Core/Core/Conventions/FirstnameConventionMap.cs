using System;
using System.Reflection;
using StubGenerator.Core;
using StubGenerator.Core.FakeDataGenerators;

namespace StubGenerator.Defaults
{
    public class FirstnameConventionMap : IConventionMap
    {
        public Predicate<PropertyInfo> Condition => w => w.PropertyType == typeof(string) && w.Name.ToLowerInvariant().Contains("name") && w.Name.ToLowerInvariant().Contains("first");

        public IValueGenerator Generator => new FirstNameValueGenerator();
    }
}
