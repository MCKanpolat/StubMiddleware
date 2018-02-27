using System;
using System.Reflection;
using StubGenerator.Core;
using StubGenerator.Core.FakeDataGenerators;

namespace StubGenerator.Defaults
{
    public class EmailConventionMap : IConventionMap
    {
        public Predicate<PropertyInfo> Condition => w => w.PropertyType == typeof(string) && w.Name.Contains("mail");

        public IValueGenerator Generator => new EmailValueGenerator();
    }
}
