using System;
using Workspace.Learning.Classes.Resources.Figures.Interfaces;

namespace Workspace.Learning.Classes.Resources.Figures;

public class Circle : Shape, IDraw3d
{
    public Circle() {}
    public Circle(string name) : base(name) {}

    public override void Draw()
    {
        Console.WriteLine("Draw Circle");
    }

    public void Draw3d()
    {
        Console.WriteLine("Draw 3d Circle!");
    }
}