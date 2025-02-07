using System;
using Learning.Classes.Resources.Figures.Interfaces;

namespace Learning.Classes.Resources.Figures;

public class Triangle : Shape, IPointy
{
    public Triangle() { }
    public Triangle(string name) : base(name) { }
    public override void Draw()
    {
        Console.WriteLine("Drawing {0} the Triangle", PetName);
    }

    public byte Points => 3;
}
