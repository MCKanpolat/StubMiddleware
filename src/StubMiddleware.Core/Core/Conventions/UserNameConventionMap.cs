using System;
using System.Reflection;
using StubGenerator.Core.FakeDataGenerators;

namespace StubGenerator.Core.Conventions
{
    public class UserNameConventionMap : IConventionMap
    {
        public Predicate<PropertyInfo> Condition => w => w.PropertyType == typeof(string) && (w.Name.ToLowerInvariant().Contains("username"));

        public IValueGenerator Generator => new UserNameValueGenerator();
    }
}
