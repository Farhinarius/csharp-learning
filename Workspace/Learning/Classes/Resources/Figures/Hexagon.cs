using System;
using Workspace.Learning.Classes.Resources.Figures.Interfaces;

namespace Workspace.Learning.Classes.Resources.Figures;

public class Hexagon : Shape, IPointy
{
    public Hexagon() {}

    public Hexagon(string name) : base(name) { }

    public override void Draw()
    {
        Console.WriteLine("Draw Hexagon");
    }

    public byte Points => 6;
}