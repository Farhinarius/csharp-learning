using System;
namespace Learning.Delegates.Resources;

internal delegate double Function(double x);

internal static class DelegateExample
{
    public static double[] Apply(double[] a, Function f)
    {
        var result = new double[a.Length];
        for (int i = 0; i < a.Length; i++)
            result[i] = f(a[i]);
        return result;
    }

    public static void OutputArray(double[] a)
    {
        foreach (var element in a)
        {
            Console.Write(element + " ");
        }

        Console.WriteLine();
    }
}
