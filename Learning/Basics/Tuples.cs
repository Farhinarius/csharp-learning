using System;

namespace Learning.Basics
{
    public static class Tuples
    {
        public static void TupleUsage()
        {
            // (double, int) t1 = (4.5, 3);
            (double sum, int count) t2 = (4.5, 3);
            Console.WriteLine($"Sum of {t2.count} elements is {t2.sum}.");


            (string, int, string) values = ("s", 5, "c");
            Console.WriteLine($"First item: {values.Item1}");
            Console.WriteLine($"Second item: {values.Item2}");
            Console.WriteLine($"Third item: {values.Item3}");

            // deconstructed tuple
            var (item1, item2, item3) = ("s", 5, "c");
            Console.WriteLine($"First item: {item1}");
            Console.WriteLine($"Second item: {item2}");
            Console.WriteLine($"Third item: {item3}");
        }

        public static (int id, string message) TuplesReturn() => (0, "name");

        public static void ReturnTuplesUsage()
        {
            var returnedTuple = TuplesReturn();
            Console.WriteLine(returnedTuple.id);
            Console.WriteLine(returnedTuple.message);
        }
    }
}