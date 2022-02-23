using System;
using System.Linq;

namespace Workspace.Learning.ObjectsEssence.Resources
{
    public static class RandomString
    {
        private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        
        private static readonly Random _random = new Random();
    
        public static string GetRandomString(int length)
        {
            return new string(Enumerable.Repeat(CHARS, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
}