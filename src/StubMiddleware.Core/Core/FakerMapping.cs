using System;
using System.Collections.Concurrent;

namespace StubGenerator.Core
{
    internal class FakerMapping
    {
        private readonly ConcurrentDictionary<StubDataType, Func<object>> _fakerMappings;
        public FakerMapping()
        {
            _fakerMappings = new ConcurrentDictionary<StubDataType, Func<object>>();
            _fakerMappings.AddOrUpdate(StubDataType.Email,
                () => { return Faker.Internet.Email(); },
               ArgumentExistingEx());

            _fakerMappings.AddOrUpdate(StubDataType.FirstName,
             () => { return Faker.Name.First(); },
             ArgumentExistingEx());

            _fakerMappings.AddOrUpdate(StubDataType.LastName,
            () => { return Faker.Name.Last(); },
            ArgumentExistingEx());

            _fakerMappings.AddOrUpdate(StubDataType.City,
             () => { return Faker.Address.City(); },
             ArgumentExistingEx());
        }

        private static Func<StubDataType, Func<object>, Func<object>> ArgumentExistingEx()
        {
            return (key, eval) =>
            {
                throw new ArgumentException(key.ToString());
            };
        }

        static FakerMapping()
        {
            Instance = new FakerMapping();
        }
        internal static FakerMapping Instance { get; private set; }


        public object GenerateData(StubDataType stubDataType)
        {
            if (_fakerMappings.TryGetValue(stubDataType, out Func<object> func))
            {
                return func.Invoke();
            }
            else
            {
                throw new NotSupportedException($"The {stubDataType} type not found!");
            }
        }
    }
}
