using System;
using System.Reflection;
using StubGenerator.Core.FakeDataGenerators;

namespace StubGenerator.Core.Conventions
{
    public class CountryConventionMap : IConventionMap
    {
        public Predicate<PropertyInfo> Condition => w => w.PropertyType == typeof(string) && w.Name.ToLowerInvariant().Contains("country");

        public IValueGenerator Generator => new CountryValueGenerator();
    }
}
