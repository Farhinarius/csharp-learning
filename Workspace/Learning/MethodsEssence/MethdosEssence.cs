using System;
using Workspace.Learning.MethodsEssence.Resources;
using Workspace.Learning.ObjectsEssence.Resources;

namespace Workspace.Learning.MethodsEssence
{
    public static class MethodsEssence
    {
        #region Private
        
        // returns copy, array of value types
        private static int GetArrayValue(int[] array, int index) => array[index];

        private static ref int GetRefArrayValue(int index, params int[] intValues)
        {
            intValues[index] = 0;
            return ref intValues[index];
        }
        
        // pass copy of reference, returns copy of reference (address in memory), array of reference types
        private static Point GetRefTypeArrayValue(Point[] points, int index)
        {
            points[index] = new Point() {X = 0, Y = 0};         // can't create new address for Point class
            return points[index];
        }
        
        
        // pass a reference to a reference type, can create new address for Point class
        private static void ReplaceValueInArrayOfRefType(ref Point[] points, int index)
        {
            points[index] = new Point() {X = 3, Y = 3};
        }
        
        #endregion
        
        #region Public 
        
        public static void ArrayElementUsage()
        {
            int[] numbers = {1,2,3,4,5};
            
            foreach (var number in numbers)
                Console.WriteLine($"Array value: {number}");
            Console.WriteLine();
            
            var arrayValue = GetArrayValue(numbers, 1);     // pass copy of array and get copy of array element
            arrayValue = 0;
            
            foreach (var number in numbers)
                Console.WriteLine($"Array value: {number}");
            Console.WriteLine();
        }

        public static void ArrayRefElementUsage()
        {
            int[] numbers = {1,2,3,4,5};
            foreach (var number in numbers)
                Console.WriteLine($"Array value: {number}");
            Console.WriteLine();
            
            ref var arrayValue = ref GetRefArrayValue(1, numbers);      // pass copy of the array and get reference to the array element
            arrayValue = 10;
            
            foreach (var number in numbers)
                Console.WriteLine($"Array value: {number}");
            Console.WriteLine();
        }

        public static void ModifyValueType()
        {
            Vector2 v1 = new Vector2(5, 5);
            Vector2 v2 = v1;
            
            v1.Display();
            v2.Display();

            v1.x = 100;
            Console.WriteLine("=> Changed v1.x");
            v1.Display();
            v2.Display();
        }
        
        public static void ModifyRefType()
        {
            Point p1 = new Point(10, 10);
            // copy reference to p2 variable.
            Point p2 = p1;       // p1 and p2 points to the same memory address in heap
            
            p1.Display();
            p2.Display();

            p1.X = 100;
            Console.WriteLine("=> Changed p1.X");
            p1.Display();
            p2.Display();
        }

        public static void RefTypeArrayElementUsage()
        {
            Point[] points =
            {
                new Point() {X = 1, Y = 1},
                new Point() {X = 1, Y = 1},
                new Point() {X = 1, Y = 1},
                new Point() {X = 1, Y = 1},
                new Point() {X = 1, Y = 1}
            };

            var newPoint = GetRefTypeArrayValue(points, 1);
            newPoint.X = 5; newPoint.Y = 5;
            
            foreach (var point in points)
                Console.WriteLine($"Array value: {point.X} {point.Y}");
            Console.WriteLine();
        }

        public static void ModifyRefTypeCollectionInMethod()
        {
            Point[] points =
            {
                new Point() {X = 1, Y = 1},
                new Point() {X = 1, Y = 1},
                new Point() {X = 1, Y = 1},
                new Point() {X = 1, Y = 1},
                new Point() {X = 1, Y = 1}
            };

            ReplaceValueInArrayOfRefType(ref points, 2);
            foreach (var point in points)
                Console.WriteLine($"Array value: {point.X} {point.Y}");
            Console.WriteLine();
        }
        
        #endregion
    }
}