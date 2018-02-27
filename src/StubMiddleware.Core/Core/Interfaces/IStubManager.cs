using System;
using System.Collections.Generic;

namespace StubGenerator.Core
{
    public interface IStubManager
    {
        IList<T> CreateListOfSize<T>(int size, Action<T> setDefaults = null) where T : class, new();
        T CreateNew<T>(Action<T> setDefaults = null) where T : class, new();
    }
}