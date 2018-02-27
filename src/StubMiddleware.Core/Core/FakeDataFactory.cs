using StubGenerator.Core.Interfaces;
using System.Reflection;
using StubGenerator.Extensions;
using System;
using StubGenerator.Defaults;
using System.Linq;
using StubGenerator.Core.FakeDataGenerators;

namespace StubGenerator.Core.FakeDataProvider
{
    public class FakeDataFactory : IFakeDataFactory
    {
        private readonly IConventionMappingProfile _stubDataMappingProfile;

        public FakeDataFactory()
            :this(new DefaultConventionMappingProfile())
        {
        }

        public FakeDataFactory(IConventionMappingProfile stubDataMappingProfile)
        {
            _stubDataMappingProfile = stubDataMappingProfile;
        }

        public object ProvideValue(PropertyInfo propertyInfo)
        {
            if (!propertyInfo.PropertyType.IsSimple())
                return null;

            var matchingConvetion = _stubDataMappingProfile.Conventions.Where(c => c.Condition(propertyInfo)).FirstOrDefault();
            if (matchingConvetion != null)
                return matchingConvetion.Generator.Generate();

            var propertyType = propertyInfo.PropertyType;

            if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                propertyType = propertyInfo.PropertyType.GetGenericArguments()[0];
            
            return GenerateValueByType(propertyType);
        }

        private static object GenerateValueByType(Type propertyType)
        {
            if (propertyType == typeof(string))
                return new RandomStringValueGenerator().Generate();
            else if (propertyType == typeof(int) || propertyType == typeof(double))
                return new IntegerValueGenerator().Generate();
            else if (propertyType == typeof(decimal))
                return new DecimalValueGenerator().Generate();
            else if (propertyType == typeof(DateTime))
                return new DateTimeValueGenerator().Generate();
            else if (propertyType.IsEnum)
                return new EnumValueGenerator(propertyType).Generate();
            else if (propertyType == typeof(Guid))
                return new GuidValueGenerator().Generate();
            else
                return null;
        }
    }
}
