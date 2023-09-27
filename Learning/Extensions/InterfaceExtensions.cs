using System;

namespace Learning.Extensions
{
    public static class InterfaceExtensions
    {
        // Extensions to classes that implements IEnumerable interface
        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator)
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
                Console.Beep();
            }
        }
    }
}
