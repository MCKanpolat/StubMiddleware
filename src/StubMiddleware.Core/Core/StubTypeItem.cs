using System;
using System.Collections.Generic;

namespace StubGenerator.Core
{
    public sealed class StubTypeItem
    {
        private List<KeyValuePair<string, StubDataType>> _propertyMapping;
        public StubTypeItem() => _propertyMapping = new List<KeyValuePair<string, StubDataType>>();

        public void SetMapping(List<KeyValuePair<string, StubDataType>> mapping)
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
