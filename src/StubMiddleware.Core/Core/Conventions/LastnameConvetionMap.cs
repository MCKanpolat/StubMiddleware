using System;
using System.Reflection;
using StubGenerator.Core;
using StubGenerator.Core.FakeDataGenerators;

namespace StubGenerator.Defaults
{
    public class LastnameConvetionMap : IConventionMap
    {
        public Predicate<PropertyInfo> Condition => w => w.PropertyType == typeof(string) && w.Name.ToLowerInvariant().Contains("name") && w.Name.ToLowerInvariant().Contains("last");

        public IValueGenerator Generator => new LastNameValueGenerator();
    }
}
