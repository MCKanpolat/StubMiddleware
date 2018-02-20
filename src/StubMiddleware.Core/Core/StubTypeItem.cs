using System;
using System.Collections.Generic;

namespace StubGenerator.Core
{
    public sealed class StubTypeItem
    {
        private List<KeyValuePair<string, FakeDataType>> _propertyMapping;
        public StubTypeItem() => _propertyMapping = new List<KeyValuePair<string, FakeDataType>>();

        public void SetMapping(List<KeyValuePair<string, FakeDataType>> mapping)
        {
            _propertyMapping = mapping ?? throw new ArgumentNullException(nameof(mapping));
        }

        public void PrepareData<T>(T instance) where T : class
        {
            foreach (var item in _propertyMapping)
            {
                instance.GetType().GetProperty(item.Key).SetValue(instance, FakerMapping.Instance.GenerateData(item.Value), null);
            }
        }
    }
}
