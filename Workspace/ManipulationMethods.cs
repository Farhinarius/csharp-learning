using System;
using System.Collections.Generic;

namespace Workspace
{
    public static class ManipulationMethods 
    {
        public static int Add(int b1, int b2) => b1 + b2;

        public static int GetArrayValue(int[] array, int index) => array[index];

        public static ref int GetRefArrayValue(int index, params int[] intValues)
        {
            intValues[index] = 0;
            return ref intValues[index];
        }

        public static Point GetRefTypeArrayValue(Point[] points, int index)
        {
            points[index] = new Point() {X = 0, Y = 0};
            return points[index];
        }

        public static IEnumerable<Point> GetRefTypeCollection(Point[] points, int index)
        {
            points[index] = new Point() {X = 3, Y = 3};
            return points;
        }
        
        
    }
}