using System;

namespace Learning.Exceptions;

public static class ExceptionHandling
{
    private static void TestIndexOutOfRangeException()
    {
        try
        {
            int[] numbers = { 2, 4, 6, 8, 10, 12, 14, 16, 18, 20 };

            int GetNumber(int index)
            {
                if (index < 0 || index >= numbers.Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return numbers[index];
            }

            Console.WriteLine(GetNumber(10));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception message: {ex.Message}", ex.Message);
            Console.WriteLine($"Exception source: {ex.Source}", ex.Source);
            Console.WriteLine($"Exception StackTrace: {ex.StackTrace}", ex.StackTrace);
            Console.WriteLine($"Exception TargetSite: {ex.TargetSite}", ex.TargetSite);
            //throw;
        }
    }

    public static void CallTypicalExceptionHandlingCase()
    {
        TestIndexOutOfRangeException();
    }
}