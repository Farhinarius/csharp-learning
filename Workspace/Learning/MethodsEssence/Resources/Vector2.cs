using System;

namespace Workspace.Learning.MethodsEssence.Resources
{
    public struct Vector2
    {
        public int x;
        public int y;
        
        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public void Display()
        {
            Console.WriteLine($"X: {x}, Y: {x}");
        }
    }
}