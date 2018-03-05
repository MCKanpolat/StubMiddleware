using System;
using System.Collections.Generic;

namespace StubGenerator.Test.Models
{
    public class ModelWithComplexTypeProperty
    {
        public char PrefixChar { get; set; }
        public string ParentString { get; set; }

        public decimal ParentDecimal { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public int? NullableInteger { get; set; }

        public InnerComplexType ComplexType { get; set; }

        public ModelConstructorHasParameters ModelConstructorHasParameters { get; set; }

        public ModelConstructorMixed ModelConstructorMixed { get; set; }

        public List<InnerComplexType> CollectionTypeComplex { get; set; }
    }

    public class InnerComplexType
    {
        public int IntegerProperty { get; set; }

        public string StringProperty { get; set; }

        public DateTime DateTimeProperty { get; set; }

        public EnTestEnum EnumProperty { get; set; }

        public Guid GuidProperty { get; set; }

        public decimal DecimalProperty { get; set; }

        public double DoubleProperty { get; set; }

        public int? NullableIntegerProperty { get; set; }

        public Nullable<int> NullableIntegerProperty2 { get; set; }
    }


    public class ModelConstructorHasParameters
    {
        public ModelConstructorHasParameters(int intField)
        {
            IntField = intField;
        }

        public int IntField { get; set; }
    }


    public class UnsupportedTypes
    {
        public byte[] ByteArray { get; set; }
    }


    public class ModelConstructorMixed
    {
        public ModelConstructorMixed()
        {
        }

        public ModelConstructorMixed(string firstName)
        {
            FirstName = firstName;
        }

        public string FirstName { get; set; }
    }

    public class ModelOfType<T> where T : struct
    {
        public T Value { get; set; }
    }
}
