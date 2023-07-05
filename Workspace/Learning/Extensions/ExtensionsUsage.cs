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

        
    }
}
