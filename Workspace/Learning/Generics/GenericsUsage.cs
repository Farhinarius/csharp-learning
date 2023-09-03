using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Workspace.Learning.Classes.Resources;
using Workspace.Learning.Classes.Resources.Enemies;
using Workspace.Learning.Classes.Resources.Vehicles;
using Workspace.Learning.Generics.Resources;

namespace Workspace.Learning.Generics
{
    public static class GenericsUsage
    {
        // boxing - позволяет хранить данные типа значения внутри ссылочной переменной.
        public static void SimpleBoxUnboxOperation()
        {
            // Создать переменную ValueType (int).
            int mylnt = 25;
            // Упаковать int в ссылку на object,
            object boxedlnt = mylnt;
            // Распаковать ссылку обратно в int.
            int unboxedlnt = (int)boxedlnt;

            // Распаковать в неподходящий тип данных, чтобы
            // инициировать исключение времени выполнения.
            try
            {
                long unboxedLong = (long)boxedlnt;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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
            int i = (int?)myInts[0] ?? throw new NullReferenceException();

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

        // • Обобщения обеспечивают лучшую производительность, т.к. лишены накладных
        //   расходов по упаковке/распаковке, когда хранят типы значений.
        // • Обобщения безопасны в отношении типов, потому что могут содержать только объекты указанного типа.
        // • Обобщения значительно сокращают потребность в специальных типах
        //   коллекций, поскольку при создании обобщенного контейнера указывается “вид типа"
        public static void UseList()
        {
            // create and shot list of int values
            List<int> numbers = new List<int> { 1, 2, 200, 4, 5 };
            numbers.ForEach(Console.WriteLine);
            Console.WriteLine(numbers.Sum() / numbers.Count);

            // create and shot list of string values
            List<string> words = new List<string> { "Bruce", "Alfred", "Tim", "Richard" };
            words.ForEach(Console.WriteLine);

            // create and show list of Person values
            List<Person> people = new List<Person>()
            {
                new Person { FirstName= "Homer", LastName="Simpson", Age=47 },
                new Person { FirstName= "Marge", LastName="Simpson", Age=45 },
                new Person { FirstName= "Lisa", LastName="Simpson", Age=9 },
                new Person { FirstName= "Bart", LastName="Simpson", Age=8 }
            };
            people.ForEach(p => Console.WriteLine(p.FirstName));

            // create and show list of Point values
            List<Point> points = new List<Point>()
            {
                new Point { X = 5, Y = 1 },
                new Point3D { X = 1, Y = 1, Z = 1 },
                new Point3D { X = 1, Y = 2, Z = 3 },
                new Point { X = 2, Y = 2 }
            };
            points.Add(new Point { X = 10, Y = 20 });
            points.Remove(points.First());

            points.AddRange(points);
            points.ForEach(p => p.Display());
        }

        public static void UseDictionary()
        {
            // create and show dictionary of characters and corresponding persons
            Dictionary<char, Person> personDictionary = new Dictionary<char, Person>
            {
                { 'A', new Person { FirstName = "Ameli"} },
                { 'B', new Person { FirstName = "Benjamin" } },
                { 'C', new Person { FirstName = "Carl"} },
                { 'D', new Person { FirstName = "Denis"} }
            };

            foreach ((char key, Person person) in personDictionary)
            {
                Console.WriteLine($"{key} {person.FirstName}");
            }

            // Получить элемент с ключом Lisa.
            Person lisa = personDictionary['A'];
            Console.WriteLine(lisa);

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
                        Console.WriteLine($"Added Item: {((Airplane)item).ModelType}");
                    }
                }

                if (args.OldItems != null && args.OldItems.Count != 0)
                {
                    foreach (var item in args.OldItems)
                    {
                        Console.WriteLine($"Removed Item: {((Airplane)item).ModelType} ");
                    }
                }

                // preferred way for checking collection changed action value
                if (args.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (Airplane item in args.NewItems)
                    {
                        Console.WriteLine($"Removed Item: {item.ModelType} ");
                    }
                }

                // preferred way for checking collection changed action value
                if (args.Action == NotifyCollectionChangedAction.Remove)
                {
                    foreach (Airplane item in args.OldItems)
                    {
                        Console.WriteLine($"Removed Item: {item.ModelType} ");
                    }
                }
            }
        }

        public static void TestGenericSwap()
        {
            float a = 5f;
            float b = 4f;

            Console.WriteLine($"{a}, {b}");
            Swap<float>(ref a, ref b); // or Spaw<Type>(a, b)
            Console.WriteLine($"{a}, {b}");
            // 
            Person p1 = new Person { Age = 12, FirstName = "Foo", LastName = "Bar" };
            Person p2 = new Person { Age = 13, FirstName = "Baaboo", LastName = "Maamoo" };

            Console.WriteLine($"{p1}, {p2}");
            Swap<Person>(ref p1, ref p2);
            Console.WriteLine($"{p1}, {p2}");
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        public static void DisplayBaseClass<T>()
        {
            // BaseType - метод, используемый в рефлексии;
            // он будет описан в главе 17.
            Console.WriteLine($"Base class of {typeof(T)} is: {typeof(T).BaseType}");
        }

        public static void TestPatternMatching()
        {
            Point<string> р4 = default;
            Point<int> р5 = default;
            PatternMatching(р4);
            PatternMatching(р5);
        }

        public static void PatternMatching<T>(Point<T> p)
        {
            switch (p)
            {
                case Point<string> pString:
                    Console.WriteLine("Point is based on strings");
                    return;
                case Point<int> pint:
                    Console.WriteLine("Point is based on ints");
                    return;
            }
        }

    }
}