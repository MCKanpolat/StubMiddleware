using StubGenerator.Core.Interfaces;
using System.Reflection;
using StubGenerator.Extensions;
using System;
using StubGenerator.Defaults;
using System.Linq;
using StubGenerator.Core.FakeDataGenerators;
using StubGenerator.Core.Attributes;

namespace StubGenerator.Core.FakeDataProvider
{
    public class FakeDataFactory : IFakeDataFactory
    {
        private readonly IConventionMappingProfile _stubDataMappingProfile;

        public FakeDataFactory()
            : this(new DefaultConventionMappingProfile())
        {
        }

        public FakeDataFactory(IConventionMappingProfile stubDataMappingProfile)
        {
            _stubDataMappingProfile = stubDataMappingProfile ?? throw new ArgumentNullException(nameof(stubDataMappingProfile));
        }

        public object ProvideValue(PropertyInfo propertyInfo)
        {
            if (!propertyInfo.PropertyType.IsSimple())
            {
                return null;
            }

            if (propertyInfo.GetCustomAttribute<StubGeneratorIgnoreAttribute>() != null)
            {
                return null;
            }

            var stubGeneratorDefaultValueAttribute = propertyInfo.GetCustomAttribute<StubGeneratorDefaultValueAttribute>();
            if (stubGeneratorDefaultValueAttribute != null)
            {
                return stubGeneratorDefaultValueAttribute.DefaultValue;
            }

            var matchingConvetion = _stubDataMappingProfile.Conventions.FirstOrDefault(c => c.Condition(propertyInfo));
            if (matchingConvetion != null)
            {
                return matchingConvetion.Generator.Generate();
            }

            var propertyType = propertyInfo.PropertyType;

            if (propertyInfo.PropertyType.IsGenericType && propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                propertyType = propertyInfo.PropertyType.GetGenericArguments()[0];
            }

            return GenerateValueByType(propertyType);
        }

        private static object GenerateValueByType(Type propertyType)
        {
            if (propertyType.IsEnum)
            {
                return new EnumValueGenerator(propertyType).Generate();
            }
            else if (propertyType == typeof(Guid))
            {
                return new GuidValueGenerator().Generate();
            }
            switch (Type.GetTypeCode(propertyType))
            {
                case TypeCode.Char:
                    return new CharValueGenerator().Generate();
                case TypeCode.Int16:
                    return new IntegerValueGeneratorBase<Int16>().Generate();
                case TypeCode.Int32:
                    return new IntegerValueGeneratorBase<Int32>().Generate();
                case TypeCode.Int64:
                    return new FloatValueGeneratorBase<Int64>().Generate();
                case TypeCode.UInt16:
                    return new IntegerValueGeneratorBase<UInt16>().Generate();
                case TypeCode.UInt32:
                    return new UInt32ValueGenerator().Generate();
                case TypeCode.UInt64:
                    return new FloatValueGeneratorBase<UInt64>().Generate();
                case TypeCode.Single:
                    return new FloatValueGeneratorBase<Single>().Generate();
                case TypeCode.Byte:
                    return new IntegerValueGeneratorBase<Byte>().Generate();
                case TypeCode.Double:
                    return new DoubleValueGenerator().Generate();
                case TypeCode.Decimal:
                    return new DecimalValueGenerator().Generate();
                case TypeCode.DateTime:
                    return new DateTimeValueGenerator().Generate();
                case TypeCode.Boolean:
                    return new BoolValueGenerator().Generate();
                default:
                    {
                        return null;
                    }
            }
        }
    }
}
