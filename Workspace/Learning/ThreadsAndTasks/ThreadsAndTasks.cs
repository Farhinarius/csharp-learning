using System;
using System.Windows.Forms;
using System.Threading;
using Workspace.Learning.ThreadsAndTasks.Resources;

namespace Workspace.Learning.ThreadsAndTasks;

public class ThreadsAndTasks
{
    public static void ExtractExecutingThread()
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    }

    public static void ExtractAppDomainHostingThread()
    {
        AppDomain appDomain = Thread.GetDomain();
    }

    public static void ExtractCurrentThreadExecutionContext()
    {
        var context = Thread.CurrentThread.ExecutionContext;
    }

    public static void ThreadStaticProperties()
    {
        // Получить имя текущего потока.
        Thread primaryThread = Thread.CurrentThread;
        primaryThread.Name = "ThePrimaryThread";
        // Вывести статистические данные о текущем потоке.
        Console.WriteLine("ID of current thread: {0}", primaryThread.ManagedThreadId);
        Console.WriteLine("Thread Name: {0}", primaryThread.Name);
        Console.WriteLine("Has thread started?: {0}", primaryThread.IsAlive);
        Console.WriteLine("Priority Level: {0}", primaryThread.Priority);
        Console.WriteLine("Thread State: {0}", primaryThread.ThreadState);
    }

    public static void MultiThreadInteraction()
    {
        Console.WriteLine("Do you prefer [1] or [2] threads?");
        var threadCount = Console.ReadLine();

        var primaryThread = Thread.CurrentThread;
        primaryThread.Name = "Primary";

        Console.WriteLine("-> {0} is executing Main()", Thread.CurrentThread.Name);
        Console.WriteLine("-> {0} is executing MultiThreadInteraction()", 
            Thread.CurrentThread.Name);

        var printer = new Printer();

        switch (threadCount)
        {
            case "2":
                Thread backgroundThread = 
                    new Thread(new ThreadStart(printer.PrintNubmers));
                backgroundThread.Name = "Secondary";
                backgroundThread.Start();
                break;

            case "1":
                printer.PrintNubmers();
                break;
            default:
                Console.WriteLine("I don't know what you want... you get 1 thread");
                goto case "1";
        }

        MessageBox.Show("I'm busy!", "Work on main thread...");
    }
}
