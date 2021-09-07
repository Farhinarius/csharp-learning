using System;


namespace Workspace.Learning.ObjectsEssence.Resources
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point() {}

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Display()
        {
            Console.WriteLine($"X: {X}, Y: {Y}");
        }
        
        public static void Draw(Point p)
        {
            // drawline logic with some library
        }

        public static void Draw(Point p, float thickness)
        {
            // drawline with thickness with some logic
        }
    }
}