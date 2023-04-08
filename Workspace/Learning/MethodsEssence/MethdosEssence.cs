using System;
using System.Linq;
using System.Net.NetworkInformation;
using Workspace.Learning.MethodsEssence.Resources;
using Workspace.Learning.ObjectsEssence.Resources;

namespace Workspace.Learning.MethodsEssence
{
    public static class MethodsEssence
    {
        #region Private

        // pass copy of array address, returns copy of array element
        private static int GetArrayValue(int[] array, int index) => array[index];

        // pass copy of array address and copy of value type int, returns reference to array value
        // (returns address to altered array element)
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
        
        // array type is always reference type
        private static void ChangeValueTypeArrayElement(int[] array, int index, int valueToSet)
        {
            array[index] = valueToSet;          // values is changing in memory of the array
        }

        private static void ChangeRefTypeArrayElement(Point[] points, int index, params int[] valuesToSet)
        {
            points[index].X = valuesToSet[0];   // values is changing in memory of the array
            points[index].Y = valuesToSet[1];
        }

        private static double CalculateAverage(params double[] values) => values.Sum() / values.Length;
        
        
        // implementation order of positioned, named and default arguments:
        // 1. positioned arguments
        // 2. named arguments
        // 3. default arguments

        #endregion

        #region Public 
        
        public static void ArrayElementUsage()
        {
            int[] numbers = {1,2,3,4,5};
            
            foreach (var number in numbers)
                Console.WriteLine($"Array value: {number}");
            Console.WriteLine();
            
            var arrayValue = GetArrayValue(numbers, 1);     // pass copy of array address and get copy of array element
            arrayValue = 0;

            arrayValue = numbers[0];
            arrayValue = 100;

            foreach (var number in numbers)
                Console.WriteLine($"Array value: {number}");
            Console.WriteLine();
            
            // copy address of array. Two arrays points to the same memory address
            var newNumbers = numbers;
            numbers[0] = 100;
            
            foreach (var number in numbers)
                Console.WriteLine($"Array value: {number}");
            Console.WriteLine();
            
            foreach (var number in newNumbers)
                Console.WriteLine($"Array value: {number}");
            Console.WriteLine();
            
            // copying values of array to another
            int[] copiedNumbers = new int[5];
            numbers.CopyTo(copiedNumbers, 0);
            
            numbers[0] = 1;

            foreach (var number in numbers)
                Console.WriteLine($"Array value: {number}");
            Console.WriteLine();
            
            foreach (var number in copiedNumbers)
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

            v1.X = 100;
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
                new Point {X = 1, Y = 1},
                new Point {X = 1, Y = 1},
                new Point {X = 1, Y = 1},
                new Point {X = 1, Y = 1},
                new Point {X = 1, Y = 1}
            };

            ReplaceValueInArrayOfRefType(ref points, 2);
            foreach (var point in points)
                Console.WriteLine($"Array value: {point.X} {point.Y}");
            Console.WriteLine();
        }
        
        public static void ArrayChangingUseCase()
        {
            int[] numbers = {1, 2, 3, 4, 5, 6};
            
            ChangeValueTypeArrayElement(numbers, 1, 10);
            
            foreach (var number in numbers)
                Console.WriteLine($"Array value: {number}");
            Console.WriteLine();
            
            Point[] points =
            {
                new Point {X = 1, Y = 1},
                new Point {X = 1, Y = 1},
                new Point {X = 1, Y = 1},
                new Point {X = 1, Y = 1},
                new Point {X = 1, Y = 1}
            };
            
            ChangeRefTypeArrayElement(points, 1, 2, 3);
            foreach (var point in points)
                Console.WriteLine($"Array value: {point.X} {point.Y}");
            Console.WriteLine();
        }

        public static void CheckReferencedValueTypeCapabilities()
        {
            (int a, int b) tuple = (5, 5);
            var changeTupleMemberAsRef = (ref int a) =>
            {
                a = -a;
            };
            changeTupleMemberAsRef(ref tuple.a);
            
            Console.WriteLine(tuple);           
        }

        public static void TestCalcAverage()
        {
            Console.WriteLine(CalculateAverage(1,2,3,4));
        }

        #endregion
    }
}