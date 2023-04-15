using System;

namespace Workspace.Learning.Classes.Resources.Figures;

public class Circle : Shape
{
    public Circle() {}
    public Circle(string name) : base(name) {}

    public override void Draw()
    {
        Console.WriteLine("Draw Circle");
    }
}