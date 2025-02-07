﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Learning.ThreadsAndTasks.Resources;
using Timer = System.Threading.Timer;               // alias for namespaces (chapter 16 example)

namespace Learning.ThreadsAndTasks;

public static class ThreadsAndTasksUsage
{
    #region System.Threading examples

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
        InvokeMultipleThreads(numberOfThreads: 4, threadMethod: s_Printer.PrintNumbersThreadSafe);
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
        var _ = new Timer(
            callback: (state) => Console.WriteLine(DateTime.Now.ToLongTimeString()),
            state: null,
            dueTime: 0,
            period: 1000);      // starts timer at creation time

        Console.ReadLine();
    }

    // all threads in ThreadPool is background!!!
    public static void TestThreadPool()
    {
        Console.WriteLine("Main thrad started. ThreadID = {0}",
            Thread.CurrentThread.ManagedThreadId);

        var printer = new Printer();

        for (int i = 0; i < 10; i++)
        {
            // pass delegate instance and static field to thread pool queue implementation
            ThreadPool.QueueUserWorkItem(state =>
            {
                if (state is Printer printerObject)
                {
                    printerObject.PrintNumbersThreadSafe();
                }
            }, state: printer);
        }
        Console.WriteLine("All tasks queued");
        Console.ReadLine();
    }

    #endregion

    #region Task Parallel library examples

    // 1. Parallel.ForEach and Dispatcher examples in ThreadsInUI project

    // 2. Parallel.Invoke EBookReader class
    public static void TestEBookReadParallelInvoke()
    {
        var downloadedBookPath = EBookReader.GetBook();
        EBookReader.GetBookStats(downloadedBookPath);
    }

    // 3. AsParallel() iteration and Task.Factory.StartNew parallel execution examples
    public static void TestAsParallelMethod()
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        do
        {
            Console.WriteLine("Press any key to start processing");
            Console.ReadKey();

            Console.WriteLine("Start processing");
            Task.Factory.StartNew(() =>
            {
                try
                {
                    // Получить обчень большой массив целых чисел
                    int[] sourceNumbers = Enumerable.Range(1, 10_100_000).ToArray();
                    // Найти числа, для которых истинно условие num % 3 == 0
                    // и возвратить их в убывающем порядке
                    int[] modThreeIsZero = sourceNumbers.AsParallel()
                        .WithCancellation(cancellationTokenSource.Token)
                        .Where(n => n % 3 == 0)
                        .OrderByDescending(n => n)
                        .ToArray();

                    Console.WriteLine();

                    Console.WriteLine($"Found {modThreeIsZero.Count()} numbers that match query!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });

            Console.Write("Enter q to quit: ");
            var answer = Console.ReadLine();

            if (answer.Equals("Q", StringComparison.OrdinalIgnoreCase))
            {
                cancellationTokenSource.Cancel();
                break;
            }
        }
        while (true);
    }

    // 4. run parallel task example
    public static void TestParallelExecutionWithTaskRun()
    {
        // Console.WriteLine(DoWork());             // lock thread and cannot continue implementation
        Console.WriteLine($"Primary thread: {Thread.CurrentThread.ManagedThreadId}");

        // run in parallel thread
        Task.Run(() => DoWork($"Method called from thread: {Thread.CurrentThread.ManagedThreadId}"));

        Console.WriteLine("Primary thread continued executing code...");
        Task.Delay(4_000).Wait();                   // imitate execution of some code
    }

    #endregion

    #region Task-based asynchronous pattern examples

    // test example replaced from parallel execution to task-based async parallel execution
    public static async Task TestEBookReadAsync()
    {
        var downloadedContentFilePath = await EBookReader.GetBookAsync();   // wait until GetBook will completed
        await EBookReader.GetBookStatsAsync(downloadedContentFilePath);     // wait until GetStats will completed, start after GetBook() completion 
    }

    // lock thread
    private static void DoWork(string text)
    {
        Console.WriteLine($"Start method {nameof(DoWork)} in thread {Thread.CurrentThread.ManagedThreadId}");
        Task.Delay(3_000).Wait();
        Console.WriteLine("Work is done");
    }

    // does not lock thread
    private static async Task DoWorkAsync(int number)
    {
        Console.WriteLine($"Start method {nameof(DoWorkAsync)}({number}) in thread {Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(3_000);
        Console.WriteLine("Work is done");
    }

    public static async Task TestAsyncAwaitWaiting()
    {
        // Console.WriteLine(PrintString());        // lock thread and cannot continue implementation

        // wait each method execution
        await DoWorkAsync(1);
        await DoWorkAsync(2);
        await DoWorkAsync(3);

        Console.WriteLine("Completed");
    }

    public static async Task TestAyncAwaitParallelMethodInvocation()
    {
        // Console.WriteLine(DoWork());             // lock thread and restrict continuation of execution
        var printTask = DoWorkAsync(1);             // run in parallel 
        var printTask2 = DoWorkAsync(2);            // run in parallel 
        var printTask3 = DoWorkAsync(3);            // run in parallel 

        // run in parallel three print tasks
        await printTask;                            // parallel wait task completion
        await printTask2;                           // parallel wait task completion
        await printTask3;                           // parallel wait task completion

        Console.WriteLine("Completed");
    }

    public static async Task TestAsyncAwaitWithConfigureAwaitFalse()
    {
        // Console.WriteLine(DoWork());        // lock thread and stop execution of method

        await DoWorkAsync(1);

        await DoWorkAsync(2).ConfigureAwait(false);
    }

    public static async Task TestAsyncBreakfast()
    {
        await AsyncBreakfast.MakeBreakfast();
    }

    public static async Task TestAsyncBreakfastWithWhenAll()
    {
        await AsyncBreakfast.MakeBreakfastWithCompletionOfAllTasks();
    }

    public static async Task TestAsyncBreakfastEfficiently()
    {
        await AsyncBreakfast.MakeBreakfastEfficiently();
    }

    public static void TestRunAndForget_AsyncVoidExample()
    {
        RunAndForgetAsync();                                // run in parallel

        Console.WriteLine("Void method started");
        Task.Delay(4_000).Wait();                           // wait for method RunAndForget to finish execution
        Console.WriteLine("Void method completed");
    }

    // method with keyword void can be called from synchronous context in parallel mode
    private static async void RunAndForgetAsync()
    {
        Console.WriteLine("Fire and forget void method started");
        await Task.Delay(3_000);                            // some task
        Console.WriteLine("Fire and forget void method completed");
    }

    public static async Task MultipleAwaits()
    {
        await Task.Run(() => { Task.Delay(2_000).Wait(); });
        Console.WriteLine("Done with first task!");

        // Первая задача завершена!
        await Task.Run(() => { Task.Delay(2_000).Wait(); });
        Console.WriteLine("Done with second task!");

        // Вторая задача завершена!
        await Task.Run(() => { Task.Delay(2_000).Wait(); });
        Console.WriteLine("Done with third task!"); //Третья задача завершена!
    }

    public static async Task MultipleAwaitsWhenAll()
    {
        var task1 = Task.Run(() =>
        {
            Task.Delay(2_000).Wait();
            Console.WriteLine("Done with first task!");
        });

        var task2 = Task.Run(() =>
        {
            Task.Delay(1_000).Wait();
            Console.WriteLine("Done with second task!");
        });

        var task3 = Task.Run(() =>
        {
            Task.Delay(1_000).Wait();
            Console.WriteLine("Done with third task!");
        });
        await Task.WhenAll(task1, task2, task3);
        Console.WriteLine("All tasks are completed");
    }

    public static void CallAsyncInSync()
    {
        DoWorkAsync(1).Wait();
        // or not preferred for usage: DoWorkAsync.GetAwaiter().GetResult();
    }

    public static async Task AsyncWithTryCatch()
    {
        try
        {
            throw new Exception();
        }
        catch (Exception ex)
        {
            // async context in catch block
            await Task.Run(() =>
            {
                Console.WriteLine("Exception occured in method {0}." +
                    "Exception message: {1}",
                    nameof(AsyncWithTryCatch),
                    ex.Message);
            });
        }
        finally
        {
            await Task.Run(() =>
            {
                Console.WriteLine("Do magic cleanup");
            });
        }
    }

    public static async ValueTask<int> AsyncReturnValueType()
    {
        await Task.Delay(1000);
        return 5;
    }

    public static async Task MethodWithProblemsFixed(int firstParam, int secondParam)
    {
        Console.WriteLine("Enter");
        if (secondParam < 0)
        {
            Console.WriteLine("Bad data");
            return;
        }

        await actualImplementation();
        async Task actualImplementation()
        {
            await Task.Run(() =>
            {
                Task.Delay(4_000).Wait();

                Console.WriteLine("First Complete");
                // Вызвать еще один длительно выполняющийся метод, который терпит
                // неудачу из-за того, что значение второго параметра выходит
                // з а пределы допустимого диапазона.
                Console.WriteLine("Something bad happened");
            });
        }
    }

    // check cancellation of async call in ThreadsInUI project

    public static async Task TestGenerateSequenceAsync()
    {
        await foreach (var number in GenerateSequenceAsync())
        {
            Console.WriteLine(number);
        }
    }

    private static async IAsyncEnumerable<int> GenerateSequenceAsync()
    {
        for (int i = 0; i < 20; i++)
        {
            await Task.Delay(100);
            yield return i;
        }
    }

    #endregion
}
