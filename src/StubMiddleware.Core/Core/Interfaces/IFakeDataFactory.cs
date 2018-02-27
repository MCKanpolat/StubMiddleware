using System.Reflection;

namespace StubGenerator.Core.Interfaces
{
    public interface IFakeDataFactory
    {
        object ProvideValue(PropertyInfo propertyInfo);
    }
}
