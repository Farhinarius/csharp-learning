using Learning.Libraries;
using System;
using System.Threading.Tasks;

namespace Learning
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
            LibrariesUsage.UseNamespaceTypesWithoutUsingStatement();
        }

    }
}