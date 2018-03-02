using System;
using System.Reflection;
using StubGenerator.Core.FakeDataGenerators;

namespace StubGenerator.Core.Conventions
{
    public class ZipCodeConventionMap : IConventionMap
    {
        public Predicate<PropertyInfo> Condition => w => w.PropertyType == typeof(string) && (w.Name.ToLowerInvariant().Contains("zipcode"));

        public IValueGenerator Generator => new ZipCodeValueGenerator();
    }
}
