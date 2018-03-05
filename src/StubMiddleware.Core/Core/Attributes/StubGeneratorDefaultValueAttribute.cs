using System;

namespace StubGenerator.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class StubGeneratorDefaultValueAttribute : Attribute
    {
        private object _defaultValue;

        public StubGeneratorDefaultValueAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
        }

        public object DefaultValue { get => _defaultValue; private set => _defaultValue = value; }
    }
}
