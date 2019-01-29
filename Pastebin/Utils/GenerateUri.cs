using System;
using System.Linq;

namespace Pastebin.Utils
{
    public static class GenerateUri
    {
        private const string _chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private static readonly Random _random = new Random();

        public static string RandomString(int length = 12)
        {
            return new string(Enumerable.Repeat(_chars, length)
                .Select(s => s[_random.Next(s.Length)])
                .ToArray());
        }
    }
}