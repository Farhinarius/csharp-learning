using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Learning.Classes.Resources;
using Workspace.Learning.Classes.Resources.Vehicles;

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
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 3);
            
            // sum and subtract points
            Point summedPoints = p1 + p2;
            Point subtractedPoints = p2 - p1;

            Console.WriteLine($"Source points ->  p1: {p1}, p2: {p2}");
            Console.WriteLine($"Value of p3 -> p1 + p2: {summedPoints}");
            Console.WriteLine($"Value of p4 -> p2 - p1 {subtractedPoints}");

            Point summedOffsetPoint = p1 + 2;
            Point subtractOffsetPoint = p2 - 2;

            Console.WriteLine($"Value of summedOffsetPoint -> p1 + 2: {summedOffsetPoint}");
            Console.WriteLine($"Value of subtractOffsetPoint -> p2 - 2 {subtractOffsetPoint}");
        }

        
    }
}
