using System;

namespace StubGenerator.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public sealed class StubGeneratorIgnoreAttribute : Attribute
    {

    }
}
