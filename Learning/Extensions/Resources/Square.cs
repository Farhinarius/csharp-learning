using System;

namespace Learning.Extensions.Resources
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

        // Casting operators (Type conversion operators)
        // cast type Rectangle (argument) to type square (pperator name)
        public static explicit operator Square(Rectangle r)
            => new Square { Length = r.Height };

        // cast type int (argument) to type square (operator name)
        public static explicit operator Square(int sideLength)
            => new Square { Length = sideLength };

        // cast type Square as argument to type int
        public static explicit operator int(Square s) => s.Length;
    }
}
