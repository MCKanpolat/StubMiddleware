using System;
using System.Reflection;
using StubGenerator.Core.FakeDataGenerators;

namespace StubGenerator.Core.Conventions
{
    public class PhoneNumberConventionMap : IConventionMap
    {
        public Predicate<PropertyInfo> Condition => w => w.PropertyType == typeof(string) && (w.Name.ToLowerInvariant().Contains("phone") || w.Name.ToLowerInvariant().Contains("mobile"));

        public IValueGenerator Generator => new PhoneNumberValueGenerator();
    }
}
