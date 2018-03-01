using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using StubGenerator.Caching;
using StubGenerator.Core.FakeDataProvider;
using StubGenerator.Core.Interfaces;
using StubGenerator.Extensions;

namespace StubGenerator.Core
{
    public class StubManager : IStubManager
    {
        private readonly IFakeDataFactory _fakeDataFactory;
        private readonly IStubTypeCache _stubTypeCache;

        public StubManager(StubManagerOptions stubManagerOptions)
            : this(stubManagerOptions, new MemoryStubTypeCache(), new FakeDataFactory())
        {
        }

        public StubManager(StubManagerOptions stubManagerOptions, IStubTypeCache stubTypeCache, IFakeDataFactory fakeDataFactory)
        {
            StubManagerOptions = stubManagerOptions ?? throw new ArgumentNullException(nameof(stubManagerOptions));
            _stubTypeCache = stubTypeCache ?? throw new ArgumentNullException(nameof(stubTypeCache));
            _fakeDataFactory = fakeDataFactory ?? throw new ArgumentNullException(nameof(fakeDataFactory));
        }

        public StubManagerOptions StubManagerOptions { get; private set; }

        public T CreateNew<T>(Action<T> setDefaults) where T : class, new() => CreateNew(Constants.DefaultListSize, setDefaults);

        public T CreateNew<T>() where T : class, new() => CreateNew<T>(Constants.DefaultListSize, null);

        public T CreateNew<T>(int subItemSize, Action<T> setDefaults) where T : class, new()
        {
            var instance = new T();
            var cachedPropertyInfo = _stubTypeCache.Get(instance);
            if (cachedPropertyInfo == null)
            {
                cachedPropertyInfo = instance.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(p => p.CanWrite).ToArray();
                _stubTypeCache.Set(instance, cachedPropertyInfo);
            }

            FillPropertiesWithFakeData(instance, cachedPropertyInfo, subItemSize);

            setDefaults?.Invoke(instance);

            return instance;
        }

        public IList<T> CreateListOfSize<T>(int size) where T : class, new() =>
            CreateListOfSize<T>(size, Constants.DefaultListSize, null);

        public IList<T> CreateListOfSize<T>(int size, Action<T> setDefaults) where T : class, new() =>
            CreateListOfSize(size, Constants.DefaultListSize, setDefaults);

        public IList<T> CreateListOfSize<T>(int size, int subItemSize) where T : class, new() =>
            CreateListOfSize<T>(size, subItemSize, null);

        public IList<T> CreateListOfSize<T>(int size, int subItemSize, Action<T> setDefaults) where T : class, new()
        {
            var result = new List<T>();
            for (int i = 0; i < size; i++)
            {
                result.Add(CreateNew(subItemSize, setDefaults));
            }
            return result;
        }

        private void FillPropertiesWithFakeData<TObject>(TObject obj, PropertyInfo[] propertyInfos, int listItemSize = Constants.DefaultListSize)
        {
            foreach (PropertyInfo property in propertyInfos)
            {
                if (property.PropertyType.IsCollectionType())
                {
                    var collectionTypeInstance = Activator.CreateInstance(property.PropertyType);
                    var complexType = property.PropertyType.GetGenericArguments()[0];
                    property.SetValue(obj, collectionTypeInstance);
                    for (var i = 0; i < listItemSize; i++)
                    {
                        dynamic item = Activator.CreateInstance(complexType);
                        FillPropertiesWithFakeData(item, _stubTypeCache.GetOrAdd(item, property.PropertyType.GetGenericArguments()[0].GetProperties()));
                        collectionTypeInstance.GetType().GetMethod("Add").Invoke(collectionTypeInstance, new[] { item });
                    }
                }
                else
                {
                    if (!property.PropertyType.IsSimple())
                    {
                        /*check the type has parameterless constructor*/
                        if ((property.PropertyType.GetConstructor(Type.EmptyTypes) != null))
                        {
                            dynamic innerComplexObj = Activator.CreateInstance(property.PropertyType);
                            obj.GetType().GetProperty(property.Name).SetValue(obj, innerComplexObj);
                            FillPropertiesWithFakeData(innerComplexObj, _stubTypeCache.GetOrAdd(innerComplexObj, innerComplexObj.GetType().GetProperties()));
                        }
                    }
                    else
                    {
                        var generatedData = _fakeDataFactory.ProvideValue(property);
                        property.SetValue(obj, generatedData, null);
                    }
                }
            }
        }
    }
}
