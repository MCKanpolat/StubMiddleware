using System;
using System.Collections.Generic;

namespace StubGenerator.Core
{
    public interface IStubManager
    {
        IList<T> CreateListOfSize<T>(int size) where T : class, new();
        IList<T> CreateListOfSize<T>(int size, Action<T> setDefaults) where T : class, new();
        IList<T> CreateListOfSize<T>(int size, int subItemSize) where T : class, new();
        IList<T> CreateListOfSize<T>(int size, int subItemSize, Action<T> setDefaults) where T : class, new();
        T CreateNew<T>(int subItemSize, Action<T> setDefaults) where T : class, new();
        T CreateNew<T>(Action<T> setDefaults) where T : class, new();
        T CreateNew<T>() where T : class, new();
    }
}