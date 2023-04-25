using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Workspace.Learning.Classes.Resources;
using Workspace.Learning.Classes.Resources.Enemies;
using Workspace.Learning.Classes.Resources.Vehicles;
using Workspace.Learning.Generics.Resources;

namespace Workspace.Learning.Generics
{
    public static class GenericsUsage
    {
        
        public static void WorkWithArrayList()
        {
            // Типы значений автоматически упаковываются,
            // когда передаются члену, принимающему object.
            ArrayList myInts = new ArrayList();
            myInts.Add(10);
            myInts.Add(20);
            myInts.Add(35);
            
            // Распаковка происходит, когда объект преобразуется
            // обратно в данные, расположенные в стеке.
            int i = (int?) myInts[0] ?? throw new NullReferenceException();
            
            // Теперь значение вновь упаковывается, т.к.
            // метод WriteLine () требует типа object!
            Console.WriteLine("Value of your int: {0}", i);
        }
        
        public static void ArrayListOfDifferentTypesUsage()
        {
            var arrayList = new ArrayList
            {
                5,
                3.14f,
                "racoon",
                true,
                new OperatingSystem(PlatformID.Xbox, new Version(10, 0)),
                new Point(),
                new Spider(),
                new Lizard(),
                new Motorcycle()
            };

            foreach (var element in arrayList)
            {
                Console.WriteLine(element);
            }
        }

        public static void WorkWithObservableCollection()
        {
            ObservableCollection<Airplane> observableAirplanes = new ObservableCollection<Airplane>();

            observableAirplanes.CollectionChanged += CollectionChangedCallback;
            for (int i = 0; i < 5; i++)
            {
                observableAirplanes.Add(new Airplane());
            }
            
            for (int i = 4; i >= 0; i--)
            {
                observableAirplanes.RemoveAt(i);
            }

            void CollectionChangedCallback(object s, NotifyCollectionChangedEventArgs args)
            {
                Console.WriteLine($"Action: {args.Action}");

                if (args.NewItems != null && args.NewItems.Count != 0)
                {
                    foreach (var item in args.NewItems)
                    {
                        Console.WriteLine($"Added Item: {( (Airplane) item ).ModelType}");
                    }
                }
                
                if (args.OldItems != null && args.OldItems.Count != 0)
                {
                    foreach (var item in args.OldItems)
                    {
                        Console.WriteLine($"Removed Item: { ((Airplane) item).ModelType} ");
                    }
                }
                


            }
        }

        public static void TestGenericSwap()
        {
            float a = 5f;
            float b = 4f;
            
            Swap(ref a, ref b); // or Spaw<Type>(a, b)     

        }

        private static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}