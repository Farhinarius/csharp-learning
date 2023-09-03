using System;
using System.Collections.Generic;
using System.Reflection;
using Workspace.Learning.Classes.Resources;
using Workspace.Learning.Classes.Resources.Vehicles;
using Workspace.Learning.Extensions.Resources;

namespace Workspace.Learning.Extensions
{
    public static class ExtensionsUsage
    {
        public static void TestPropertyListModification()
        {
            List<Vehicle> vehicles = (new Garage()).Vehicles;
            vehicles.Add(new Car());

            foreach (var vehicle in vehicles)
            {
                vehicle.Display();
            }
        }

        public static void TestIndexers()
        {
            Garage garage = new Garage();

            for (var i = 0; i < garage.Count; i++)
            {
                garage[i].Display();
            }
        }

        public static void TestIndexerOverDictionary()
        {
            PersonCollection peopleDictionary =
                new PersonCollection();

            peopleDictionary["Homer"] = new Person("Homer", "Simpson", 40);
            peopleDictionary["Marge"] = new Person("Marge", "Simpson", 38);

            // Получить объект лица Homer и вывести данные.
            Person homer = peopleDictionary["Homer"];
        }

        public static void TestOperatorsOverload()
        {
            Point p1 = new(1, 1);
            Point p2 = new(2, 3);

            // sum and subtract points
            Point summedPoints = p1 + p2;
            Point subtractedPoints = p2 - p1;

            Console.WriteLine($"Source points ->  p1: {p1}p2: {p2}");
            Console.WriteLine($"Value of p3 -> p1 + p2: {summedPoints}");
            Console.WriteLine($"Value of p4 -> p2 - p1 {subtractedPoints}");

            // to offset points
            Point summedOffsetPoint = p1 + 2;
            Point subtractOffsetPoint = p2 - 2;

            Console.WriteLine($"Value of summedOffsetPoint -> p1 + 2: {summedOffsetPoint}");
            Console.WriteLine($"Value of subtractOffsetPoint -> p2 - 2 {subtractOffsetPoint}");

            // the += is emulated for opeartion +. So if + operator is overloaded, then += already implemented
            p1 += p2;
            Console.WriteLine($"Value of p1 += p2: {p1}");

            // separate overloading of post/past increment/decrement operations (need to overload together)
            p1++;
            Console.WriteLine($"Value of  p1++: {p1}");
            p1--;
            Console.WriteLine($"Value of p1--: {p1}");

            // equation (Overload Equals() method of class System.Object,
            // then overload operator == and != and call existed Equals() overloading)
            Point p3 = new(3, 3);
            Point p4 = (Point)p3.Clone();
            Console.WriteLine($"Source points ->  p3: {p3}p4: {p4}");
            Console.WriteLine($"Value of p3 == p4: {p3 == p4}");
            Console.WriteLine($"Value of p3 != p4: {p3 != p4}");

            // implement IComparable.CompareTo interface implementation. Call CompareTo in operator overloading to compare entities
            p3++;       // test clone implementation
            Console.WriteLine($"Source points ->  p3: {p3}p4: {p4}");
            Console.WriteLine($"Value of p3 > p4: {p3 > p4}");
            Console.WriteLine($"Value of p3 < p4: {p3 < p4}");
            Console.WriteLine($"Value of p3 >= p4: {p3 >= p4}");
            Console.WriteLine($"Value of p3 <= p4: {p3 <= p4}");
        }

        public static void TestCustomConversions()
        {
            Rectangle rect = new Rectangle(10, 4);
            Console.WriteLine(rect.ToString());
            rect.Draw();

            Square sq = (Square)rect;
            Console.WriteLine(sq.ToString());
            sq.Draw();

            Square sq2 = (Square)90;
            Console.WriteLine("sq2 = {0}", sq2);

            int side = (int)sq2;
            Console.WriteLine("Side length of sq2 = {0}", side);

            // implicit conversion from square to rectangle
            Square sq3 = new Square { Length = 5 };
            Rectangle rectFromSq = sq3;
            Console.WriteLine("Call implicit conversion from Square to Rectangle: {0}", rectFromSq);

            // explicit conversion for implicit operator (just as in language)
            Square sq4 = new Square { Length = 4 };
            Rectangle rectFromSq2 = (Rectangle)sq4;
            Console.WriteLine("Call implicit conversion from Square to Rectangle but with explicit usage: {0}", rectFromSq2);
        }

        public static void TestExtensionsMethods()
        {
            int myNumber = 1234567;
            myNumber.DisplayDefiningAssembly();

            System.Data.DataSet dataSet = new System.Data.DataSet();
            dataSet.DisplayDefiningAssembly();

            // Использовать новую функциональность int.
            Console.WriteLine("Value of mylnt: {0}", myNumber);
            Console.WriteLine("Reversed digits of mylnt: {0}", myNumber.ReverseDigits());
        }

        public static void TestInterfaceExtensions()
        {
            // System.Array реализует IEnumerable, потому мы можем применить расширяющий метод для интерфейса IEnumerable
            string[] data = { "Wow", "this", "is", "sort", "of", "annoying", "but", "in", "a", "weird", "way", "fun!" };
            data.PrintDataAndBeep();
            Console.WriteLine();

            // List<T> реализует IEnumerable, потому мы можем применить расширяющий метод для интерфейса IEnumerable
            List<int> mylnts = new List<int>() { 10, 15, 20 };
            mylnts.PrintDataAndBeep();
            Console.ReadLine();
        }

        // Anonymous Type:
        // • Контроль над именами анонимных типов отсутствует.
        // • Анонимные типы всегда расширяют System.Object.
        // • Поля и свойства анонимного типа всегда допускают только чтение.
        // • Анонимные типы не могут поддерживать события, специальные методы, специальные операции или специальные переопределения.
        // • Анонимные типы всегда неявно запечатаны.
        // • Экземпляры анонимных типов всегда создаются с применением стандартных конструкторов.

        public static void BuildAnonymousType()
        {
            // instantiate anonymous type. Fields of anonymous type is readonly. Anonymous type have inherits from System.Object and
            // have System.Object methods from moment of creation
            var car = new { DateMade = 1990, Mark = "Volvo", MaxSpeed = 250 };
            ReflectOverAnonymousType(car);
        }

        private static void ReflectOverAnonymousType(object obj)
        {
            Console.WriteLine("obj is an instance of: {0}", obj.GetType().Name);
            Console.WriteLine("Base class of {0} is {1}", obj.GetType().Name, obj.GetType().BaseType);
            Console.WriteLine("obj.ToString() == {0}", obj.ToString());
            Console.WriteLine("obj.GetHashCode() == {0}", obj.GetHashCode());
        }

        public static void TestAnonymousTypeEquality()
        {
            // Создать два анонимных класса с идентичными наборами
            // пар "имя-значение".
            var firstCar = new
            {
                Color = "Bright Pink",
                Make = "Saab",
                CurrentSpeed = 55
            };
            var secondCar = new
            {
                Color = "Bright Pink",
                Make = "Saab",
                CurrentSpeed = 55
            };
            // Считаются ли они эквивалентными, когда используется Equals()?
            if (firstCar.Equals(secondCar))
            {
                Console.WriteLine("Same anonymous object!");
            }
            else
            {
                Console.WriteLine("Not the same anonymous object!");
            }

            // Можно ли проверить их эквивалентность с помощью операции ==?
            if (firstCar == secondCar)
            {
                Console.WriteLine("Same anonymous object!");
            }
            else
            {
                Console.WriteLine("Not the same anonymous object!");
            }

            // Имеют ли эти объекты в основе один и тот же тип?
            if (firstCar.GetType().Name == secondCar.GetType().Name)
            {
                Console.WriteLine("We are both the same type!");
                // Оба объекта имеют тот же самый тип
            }
            else
            {
                Console.WriteLine("We are different types!");
                // Объекты относятся к разным типам
            }

            // Отобразить все детали.
            Console.WriteLine();
            ReflectOverAnonymousType(firstCar);
            ReflectOverAnonymousType(secondCar);
        }

        public static void BuildAnonoymousTypeInAnonymousType()
        {
            // Создать анонимный тип, состоящий из еще одного анонимного типа.
            var purchaseltem = new
            {
                TimeBought = DateTime.Now,
                ItemBought = new { Color = "Red", Make = "Saab", CurrentSpeed = 55 },
                Price = 34.000
            };
            ReflectOverAnonymousType(purchaseltem);
        }

    }
}
