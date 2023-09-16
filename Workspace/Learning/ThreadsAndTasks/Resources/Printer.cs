using System;
using System.Threading;

namespace Workspace.Learning.ThreadsAndTasks.Resources
{
    public class Printer
    {
        private int _count = 0;

        // Маркер блокировки. Необходим для блокировки доступа из потоков к публичным методом и для указанния ссылки выполнения потокам
        private object _threadLock = new object();

        private Random _random = new Random();

        public void PrintNumbers()
        {
            Console.WriteLine("-> {0} thread is executing {1} <-",
                Thread.CurrentThread.Name,
                nameof(PrintNumbers));

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Printed by thread {0} value: {1}",
                    Thread.CurrentThread.Name, i);

                Thread.Sleep(1000 * _random.Next(5));
            }
        }

        public void SwitchValue()
        {
            Console.WriteLine("-> {0} thread is executing {1} <-",
                Thread.CurrentThread.Name,
                nameof(SwitchValue));

            for (int i = 0; i < 10; i++)
            {
                switch (_random.Next(2))       // below 2 non negative
                {
                    case 0:
                        Console.WriteLine("Increased(++) by thread {0} value: {1}",
                            Thread.CurrentThread.Name, ++_count);
                        break;
                    case 1:
                        Console.WriteLine("Decreased(--) by thread {0} value: {1}",
                            Thread.CurrentThread.Name, --_count);
                        break;
                    default:
                        Console.WriteLine("What a hell?");
                        break;
                }

                Thread.Sleep(1000 * new Random().Next(5));
            }
        }

        public void PrintNumbersLocked()
        {
            // Использовать в качестве маркера блокировки закрытый член object, блокирая доступ к другим потокам, кроме первого входящего
            lock (_threadLock)
            {
                Console.WriteLine("-> {0} thread is executing {1} <-",
                    Thread.CurrentThread.Name,
                    nameof(PrintNumbers));

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000 * _random.Next(5));
                    Console.WriteLine("Printed by thread {0} value: {1}",
                        Thread.CurrentThread.Name, i);
                }

                Console.WriteLine();
            }
        }
    }
}
