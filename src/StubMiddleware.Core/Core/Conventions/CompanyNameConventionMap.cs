using System;
using System.Reflection;
using StubGenerator.Core.FakeDataGenerators;

namespace StubGenerator.Core.Conventions
{
    public class CompanyNameConventionMap : IConventionMap
    {
        public Predicate<PropertyInfo> Condition => w => w.PropertyType == typeof(string) && (w.Name.ToLowerInvariant().Contains("company") && w.Name.ToLowerInvariant().Contains("name"));

        public IValueGenerator Generator => new CompanyNameValueGenerator();
    }
}
