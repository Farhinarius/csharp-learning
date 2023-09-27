using System;
using Learning.Classes.Resources.Figures.Interfaces;

namespace Learning.Classes.Resources.Figures;

public class Hexagon : Shape, IPointy, IDraw3d
{
    public Hexagon() { }

    public Hexagon(string name) : base(name) { }

    public override void Draw()
    {
        Console.WriteLine("Draw Hexagon");
    }

    public byte Points => 6;
    public void Draw3d()
    {
        Console.WriteLine("Draw 3d Hexagon!");
    }
}