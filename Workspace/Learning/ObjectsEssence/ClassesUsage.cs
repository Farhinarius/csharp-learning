using System;
using System.Collections;
using Workspace.Learning.ObjectsEssence.Resources;
using Workspace.Learning.ObjectsEssence.Resources.Enemies;

namespace Workspace.Learning.ObjectsEssence
{
    public static class ClassesUsage
    {
        // for better understanding of this methods you need to check classes inside
        public static void ChainConstructorWithDefaultParameters()
        {
            Motorcycle m = new Motorcycle(5);
            m.Display();
        }

        public static void UsingDifferentInitialization()
        {
            // set up manually
            Point p = new Point();
            p.X = 10;
            p.Y = 15;
            p.Display();
            
            // programmer defined constructor 
            Point p2 = new Point(5, 5);
            p.Display();
            
            // object initializer
            Point p3 = new Point
            {
                X = 3,
                Y = 3
            };
            
            p3.Display();
        }

        public static void InitializerBehavioursWithConstructors()
        {
            // initializer without constructor
            Point p = new Point
            {
                X = 3,
                Y = 3
            };
            
            // initializer with default constructor
            Point pD = new Point()
            {
                X = 5,
                Y = 10
            };
            
            // initializer + constructor syntax
            Point pC = new Point(Point.Color.blue)
            {
                X = 15,
                Y = 10
            };
        }
        
        public static void InheritanceConstructor()
        {
            Point3D p3 = new Point3D(10, 10, 10);
        }

        public static void ParametricPolymorphism()
        {
            Point pointToDraw = new Point();
            Point.Draw(pointToDraw);
            Point.Draw(pointToDraw, 5.5f);
        }

        public static void InheritancePolymorphism()
        {
            Point p4 = new Point(10, 10);
            Point p5 = new Point3D(1, 2, 3);
        }

        public static void OverridingPolymorphism()
        {
            var enemies = new Enemy[3]; // can create array of abstract polymorphic interfaces

            enemies[0] = new Lizard();
            enemies[1] = new Spider();
            enemies[2] = new Lizard(5, 4);

            foreach (var enemy in enemies)
                enemy.Attack();
            

            // Enemy.attack()       ->  virtual method of abstract class (can not be called)
            // Lizard.attack()      ->  overridden method of real class
        }
        
        public static void TypeCasting()
        {
            Enemy enemy1 = new Lizard();
            Lizard lizard = enemy1 as Lizard;

            Enemy.Upgrade(enemy1);
        }

        public static void UseEnumerator()
        {
            Garage garage = new Garage();
            var e = ((IEnumerable)garage).GetEnumerator();

            for (var i = 0; i < garage.Length; i++)
            {
                e.MoveNext();
                var motorcycle = (Motorcycle) e.Current;
                motorcycle?.Display();
            }

            // ???
            // for (int i = 0; i < garage.Length; i++)
            // {
            //     var enumerator = garage.GetEnumerator();
            //     var motorcycle = (Motorcycle) enumerator;
            //     motorcycle?.Display();
            // }
            
        }

        public static void UseEnumeratorWithYield()
        {
            var garage = new Garage();

            foreach (var motorcycle in garage)
            {
                (motorcycle as Motorcycle)?.Display();
            }
        }
        
    }
}