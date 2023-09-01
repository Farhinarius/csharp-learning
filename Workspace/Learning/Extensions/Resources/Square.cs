using System;

namespace Workspace.Learning.Extensions.Resources
{
    public struct Square
    {
        public int Length { get; set; }

        public Square(int length) : this()
        {
            Length = length;
        }

        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public override string ToString() => $"[Length = {Length}]";

        public static explicit operator Square(Rectangle r)
            => new Square { Length = r.Height };

        public static explicit operator Square(int sideLength) 
            => new Square { Length = sideLength };

        public static explicit operator int(Square s) => s.Length;
    }
}
