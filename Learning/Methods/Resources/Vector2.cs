using System;

namespace Learning.Methods.Resources
{
    public struct Vector2
    {
        public int X;
        public int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Display()
        {
            Console.WriteLine($"X: {X}, Y: {X}");
        }
    }
}