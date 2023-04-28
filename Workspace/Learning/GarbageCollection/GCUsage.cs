using System;
using Workspace.Learning.Classes.Resources.Vehicles;
using Point = Workspace.Learning.Classes.Resources.Point;

namespace Workspace.Learning.GarbageCollection;

public static class GcUsage
{
    public static void TestGcMethods()
    {
        // Вывести оценочное количество байтов, выделенных в куче.
        Console.WriteLine("Estimated bytes on heap: {0}", 
            GC.GetTotalMemory(false));
        
        Console.WriteLine("This OS has {0} object generations.\n",
            GC.MaxGeneration + 1);
        Car refToMyCar = new Car("Zippy", 100);
        refToMyCar.Display();

        // Вывести поколение объекта refToMyCar.
        Console.WriteLine("Generation of refToMyCar is: {0}",
            GC.GetGeneration(refToMyCar));
    }

    public static void TestGarbageCollection()
    {
        // Принудительно запустить сборку мусора
        // и ожидать финализации каждого объекта.
        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    public static void TestGarbageCollectionInDetail()
    {
        // Вывести оценочное количество байтов, выделенных в куче.
        Console.WriteLine("Estimated bytes on heap: {0}",
            GC.GetTotalMemory(false));
        
        // Значения MaxGeneration начинаются c 0.
        Console.WriteLine("This OS has {0} object generations.\n",
            (GC.MaxGeneration + 1));
        
        Car refToMyCar = new Car("Zippy", 100);
        refToMyCar.Display();
        
        // Вывести поколение refToMyCar.
        Console.WriteLine("\nGeneration of refToMyCar is: {0}",
            GC.GetGeneration(refToMyCar));

        object[] tonsOfObjects = new object[50000];
        for (int i = 0; i < 50000; i++)
        {
            tonsOfObjects[i] = new object();
        }
        
        // Выполнить сборку мусора только для объектов поколения 0.
        Console.WriteLine("Force Garbage Collection");
        GC.Collect(0, GCCollectionMode.Forced);
        GC.WaitForPendingFinalizers();
        
        // Вывести поколение refToMyCar.
        Console.WriteLine("Generation of refToMyCar is: {0}",
            GC.GetGeneration(refToMyCar));
        
        // Посмотреть, существует ли еще tonsOfObjects[9000].
        if (tonsOfObjects[9000] != null)
        {
            Console.WriteLine("Generation of tonsOfObjects[9000] is: {0}",
                GC.GetGeneration(tonsOfObjects[9000]));
        }
        else
        {
            Console.WriteLine("tonsOfObjects[9000] is no longer alive."); // tonsOfObjects[9000] больше не существует
        }

        // Вывести количество проведенных сборок мусора для разных поколений.
        Console.WriteLine("\nGen 0 has been swept {0} times",
            GC.CollectionCount(0)); // Количество сборок для поколения 0
        
        Console.WriteLine("Gen 1 has been swept {0} times",
            GC.CollectionCount(1)); // Количество сборок для поколения 1
        
        Console.WriteLine("Gen 2 has been swept {0} times",
            GC.CollectionCount(2)); // Количество сборок для поколения 2
    }
}