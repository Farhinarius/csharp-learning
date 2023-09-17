﻿using System;
using System.Windows.Forms;
using System.Threading;
using Workspace.Learning.ThreadsAndTasks.Resources;


namespace Workspace.Learning.ThreadsAndTasks;

public static class ThreadsAndTasks
{
    private static Printer s_Printer = new Printer();

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
        
        // Retrieve current implementation thread and assign name to it
        var primaryThread = Thread.CurrentThread;
        primaryThread.Name = "Primary";

        // Show call stack
        Console.WriteLine("-> {0} is executing Main()", Thread.CurrentThread.Name);
        Console.WriteLine("-> {0} is executing MultiThreadInteraction()", 
            Thread.CurrentThread.Name);

        var printer = new Printer();

        switch (threadCount)
        {
            // Create new thread for Printing nubmers
            case "2":
                Thread backgroundThread = 
                    new Thread(new ThreadStart(printer.PrintNumbers));
                backgroundThread.Name = "Secondary";
                backgroundThread.Start();
                break;
            
            // Use primary thread for printing numbers
            case "1":
                printer.PrintNumbers();
                break;

            // Use primary thread for printing nubmers else
            default:
                Console.WriteLine("I don't know what you want... you get 1 thread");
                goto case "1";
        }

        MessageBox.Show("I'm busy!", "Work on main thread...");
    }

    public static void TestParametrizedThreadStart()
    {
        Console.WriteLine("ID of thread in Main(): {0}",
            Thread.CurrentThread.ManagedThreadId);

        var thread = new Thread(
            new ParameterizedThreadStart(valueToIncrease =>
        {
            Console.WriteLine("ID of new parametrized thread {0}",
                Thread.CurrentThread.ManagedThreadId);

            if (valueToIncrease is int numberToIncrease)
                Console.WriteLine("Increased number: {0}", ++numberToIncrease);
        }));

        thread.Start(0);

        // wait until another thread will finish
        Thread.Sleep(5);
    }

    // Thread waiting function.
    // Primary thread waiting for the completion of second thread
    public static void TestAutoResetEventAsWaitHandle()
    {
        var waitHandle = new AutoResetEvent(false);
        Console.WriteLine("ID of thread in Main(): {0}",
            Thread.CurrentThread.ManagedThreadId);

        var thread = new Thread(
            new ParameterizedThreadStart(valueToIncrease =>
        {
            Console.WriteLine("ID of thread in ShowIncreasedNumber(object valueToIncrease): {0}", 
                Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);

            if (valueToIncrease is int numberToIncrease)
                Console.WriteLine("Increased number: {0}", numberToIncrease++);

            // Сообщить другому потому о том, что работа завершена и можно продолжать выполнение
            waitHandle.Set();
        }));

        thread.Start(5);

        waitHandle.WaitOne();
        Console.WriteLine("ID of thread in Main(): {0}", Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("Other thread is done!");
    }

    // If background thread is used, primary front plane thread of application
    // will end without waiting completion of background thread
    public static void TestBackgroundThread()
    {
        var printer = new Printer();
        var backgroundThread = new Thread(new ThreadStart(printer.PrintNumbers));
        
        backgroundThread.IsBackground = true;       // comment line to see how app
                                                    // will wait this thread
        backgroundThread.Start();
    }

    public static void UnsynchronizedThreadsInConsole()
    {
        InvokeMultipleThreads(numberOfThreads: 4, threadMethod: s_Printer.PrintNumbers);
    }

    public static void UnsynchronizedThreadsInClassField()
    {
        InvokeMultipleThreads(numberOfThreads: 4, threadMethod: s_Printer.SwitchValue);
    }

    public static void SynchronizedThreads()
    {
        InvokeMultipleThreads(numberOfThreads: 4, threadMethod: s_Printer.PrintNumbersLocked);
    }

    // Example of printing number into console in unsynchronized mode
    private static void InvokeMultipleThreads(int numberOfThreads, Action threadMethod)
    {
        var threads = new Thread[numberOfThreads];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(new ThreadStart(threadMethod))
            {
                Name = $"#{i}"
            };
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }
    }

    public static void TestTimer()
    {
        Console.WriteLine("Press Enter to terminate process...");
        var timer = new System.Threading.Timer(
            callback: (object state) => Console.WriteLine(DateTime.Now.ToLongTimeString()),
            state: null,
            dueTime: 0,
            period: 1000);      // starts timer at creation time

        Console.ReadLine();
    }

}
