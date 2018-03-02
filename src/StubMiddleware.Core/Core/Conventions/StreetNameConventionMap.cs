using System;
using System.Reflection;
using StubGenerator.Core.FakeDataGenerators;

namespace StubGenerator.Core.Conventions
{
    public class StreetNameConventionMap : IConventionMap
    {
        public Predicate<PropertyInfo> Condition => w => w.PropertyType == typeof(string) && w.Name.ToLowerInvariant().Contains("street");

        public IValueGenerator Generator => new StreetNameValueGenerator();
    }
}
