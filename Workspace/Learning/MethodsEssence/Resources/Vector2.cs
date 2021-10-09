using System;

namespace Workspace.Learning.MethodsEssence.Resources
{
    public struct Vector2
    {
        public int X;
        public int Y;
        
        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        
        public void Display()
        {
            Console.WriteLine($"X: {X}, Y: {X}");
        }
    }
}