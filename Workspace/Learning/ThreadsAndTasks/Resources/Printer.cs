using System;
using System.Threading;

namespace Workspace.Learning.ThreadsAndTasks.Resources
{
    public class Printer
    {
        public void PrintNubmers()
        {
            Console.WriteLine("-> {0} is executing PrintNumbers()",
                Thread.CurrentThread.Name);

            Console.Write("Your numbers: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write("{0}, ", i);
                Thread.Sleep(2000);
            }
            Console.WriteLine();
        }
    }
}
