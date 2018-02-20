using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StubGenerator.Caching;

namespace StubGenerator.Core
{
    public class StubManager
    {
        public StubManager(StubManagerOptions stubManagerOptions, IStubTypeCacheManager stubTypeCacheManager, IFakeDataMappingProfile fakeDataMappingProfile)
        {
            StubManagerOptions = stubManagerOptions ?? throw new ArgumentNullException(nameof(stubManagerOptions));
            StubTypeCacheManager = stubTypeCacheManager ?? throw new ArgumentNullException(nameof(stubTypeCacheManager));
            FakeDataMappingProfile = fakeDataMappingProfile ?? throw new ArgumentNullException(nameof(fakeDataMappingProfile));
        }

        public IStubTypeCacheManager StubTypeCacheManager { get; private set; }
        public IFakeDataMappingProfile FakeDataMappingProfile { get; private set; }
        public StubManagerOptions StubManagerOptions { get; private set; }

        internal void GenerateData<T>(T instance, PropertyInfo propertyInfo)
        {
            var convention = FakeDataMappingProfile.Conventions.FirstOrDefault(w => w.Condition.Invoke(propertyInfo));
            object generatedData = convention != null ? HandleKnownType(instance, convention.FakeDataType) : HandleUnknownType(propertyInfo);
            propertyInfo.SetValue(instance, generatedData, null);
        }

        internal object HandleKnownType<T>(T instance, FakeDataType fakeDataType)
        {
            return FakerMapping.Instance.GenerateData(fakeDataType);
        }

        internal object HandleUnknownType(PropertyInfo propertyInfo)
        {
            if (propertyInfo.DeclaringType.IsValueType)
            {
                return Activator.CreateInstance(propertyInfo.DeclaringType);
            }

            return null;
        }

        public T CreateNew<T>() where T : class, new()
        {
            var instance = new T();
            var cachedStub = StubTypeCacheManager.Get(instance);
            if (cachedStub == null)
            {
                var avaliableProps = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(w => w.CanWrite);
                var mapping = new List<KeyValuePair<string, FakeDataType>>();
                foreach (var pinfo in avaliableProps)
                {
                    var convention = FakeDataMappingProfile.Conventions.FirstOrDefault(w => w.Condition.Invoke(pinfo));
                    if (convention != null)
                        mapping.Add(new KeyValuePair<string, FakeDataType>(pinfo.Name, convention.FakeDataType));
                }
                var typeItem = new StubTypeItem();
                typeItem.SetMapping(mapping);
                StubTypeCacheManager.Set(instance, typeItem);
                typeItem.PrepareData(instance);
            }
            else
            {
                cachedStub.PrepareData(instance);
            }

            return instance;
        }

        public IList<T> CreateListOfSize<T>(int size) where T : class, new()
        {
            var result = new List<T>();
            for (int i = 0; i < size; i++)
            {
                result.Add(CreateNew<T>());
            }
            return result;
        }
    }
}
