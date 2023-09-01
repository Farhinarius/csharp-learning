using System;
using System.Collections.Generic;
using Workspace.Learning.Classes.Resources;
using Workspace.Learning.Classes.Resources.Vehicles;
using Workspace.Learning.Extensions.Resources;

namespace Workspace.Learning.Extensions
{
    public static class ExtensionsUsage
    {
        public static void TestPropertyListModification()
        {
            List<Vehicle> vehicles = (new Garage()).vehicles;
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
            Point p4 = (Point) p3.Clone();
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
            Console.ReadLine();

        }


    }
}
