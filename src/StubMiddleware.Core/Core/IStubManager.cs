using System.Collections.Generic;

namespace StubGenerator.Core
{
    public interface IStubManager
    {
        IList<T> CreateListOfSize<T>(int size) where T : class, new();
        T CreateNew<T>() where T : class, new();
    }
}