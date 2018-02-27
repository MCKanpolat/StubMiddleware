using System;
using System.Collections.Generic;

namespace StubGenerator.Core
{
    public interface IStubManager
    {
        IList<T> CreateListOfSize<T>(int size, int subItemSize = 3, Action<T> setDefaults = null) where T : class, new();
        T CreateNew<T>(int subItemSize = 3, Action<T> setDefaults = null) where T : class, new();
    }
}