using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class CharValueGenerator : IValueGenerator
    {
        private static readonly Lazy<Random> _random;
        private static char[] _charValues;
        private static int _charsize;
        static CharValueGenerator()
        {
            _random = new Lazy<Random>(() => new Random());
            _charValues = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            _charsize = _charValues.Length;
        }
  
        public object Generate()
        {
            return _charValues[_random.Value.Next(0, _charsize - 1)];
        }
    }
}
