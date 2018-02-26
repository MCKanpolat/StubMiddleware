using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StubGenerator.Caching;

namespace StubGenerator.Core
{
    public class StubManager : IStubManager
    {
        public StubManager(StubManagerOptions stubManagerOptions, IStubTypeCacheManager stubTypeCacheManager, IStubDataMappingProfile stubDataMappingProfile)
        {
            StubManagerOptions = stubManagerOptions ?? throw new ArgumentNullException(nameof(stubManagerOptions));
            StubTypeCacheManager = stubTypeCacheManager ?? throw new ArgumentNullException(nameof(stubTypeCacheManager));
            StubDataMappingProfile = stubDataMappingProfile ?? throw new ArgumentNullException(nameof(stubDataMappingProfile));
        }

        public IStubTypeCacheManager StubTypeCacheManager { get; private set; }
        public IStubDataMappingProfile StubDataMappingProfile { get; private set; }
        public StubManagerOptions StubManagerOptions { get; private set; }

        internal void GenerateData<T>(T instance, PropertyInfo propertyInfo)
        {
            var convention = StubDataMappingProfile.Conventions.FirstOrDefault(w => w.Condition.Invoke(propertyInfo));
            object generatedData = convention != null ? HandleKnownType(instance, convention.StubDataType) : HandleUnknownType(propertyInfo);
            propertyInfo.SetValue(instance, generatedData, null);
        }

        internal object HandleKnownType<T>(T instance, StubDataType fakeDataType)
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
                var mapping = new List<KeyValuePair<string, StubDataType>>();
                foreach (var pinfo in avaliableProps)
                {
                    var convention = StubDataMappingProfile.Conventions.FirstOrDefault(w => w.Condition.Invoke(pinfo));
                    if (convention != null)
                        mapping.Add(new KeyValuePair<string, StubDataType>(pinfo.Name, convention.StubDataType));
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
