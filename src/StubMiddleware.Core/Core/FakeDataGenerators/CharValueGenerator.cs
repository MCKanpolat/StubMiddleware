using System;

namespace StubGenerator.Core.FakeDataGenerators
{
    public class CharValueGenerator : IValueGenerator
    {
        private static char[] charValues;
        private static int charsize;
        static CharValueGenerator()
        {
            charValues = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            charsize = charValues.Length;
        }
        public object Generate()
        {
            return charValues[new Random().Next(0, charsize - 1)];
        }
    }
}
