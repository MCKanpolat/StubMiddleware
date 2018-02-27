using System;
using System.Collections.Generic;

namespace StubGenerator.Test.Models
{
    public class ModelWithComplexTypeProperty
    {
        public string ParentString { get; set; }

        public decimal ParentDecimal { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public int? NullableInteger { get; set; }

        public InnerComplexType ComplexType { get; set; }

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

    public enum EnTestEnum
    {
        Option1,
        Option2,
        Option3
    }
}
