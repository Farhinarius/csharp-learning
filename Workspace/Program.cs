using System;
using Workspace.Learning.ThreadsAndTasks;

namespace Workspace
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            ThreadsAndTasks.TestTimer();
        }
    }
}

namespace Workspace
{

    public static class ExecutionHandler
    {
        public static void DelegateUsage()
        {
            double[] a = { 0.0, 0.5, 1.0 };
            double[] squares = DelegateExample.Apply(a, (x) => x * x);
            DelegateExample.OutputArray(squares);

            double[] sines = DelegateExample.Apply(a, Math.Sin);
            DelegateExample.OutputArray(sines);

            Multiplier m = new Multiplier(2.0);
            double[] doubles = DelegateExample.Apply(a, m.Multiply);
            DelegateExample.OutputArray(doubles);
        }

    }

    #region Delegate Usage

    class Multiplier
    {
        double _factor;

        public Multiplier(double factor) => _factor = factor;

        public double Multiply(double x) => x * _factor;
    }

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

    #endregion
}
