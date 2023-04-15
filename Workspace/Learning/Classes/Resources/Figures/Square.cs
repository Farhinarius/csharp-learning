using System;
using Workspace.Learning.Classes.Resources.Figures.Interfaces;

namespace Workspace.Learning.Classes.Resources.Figures;


class Square : Shape, IRegularPointy
{
    public Square() { }

    public Square(string name) : base(name) { }
    
    public override void Draw()
    {
        Console.WriteLine("Drawing a square");
    }

    // Это свойство поступает из интерфейса IPointy.
    public byte Points => 4;

    // Эти свойства поступает из интерфейса IRegularPointy.
    public int SideLength { get; set; }
    public int NumberOfSides { get; set; } = 4;

    // Обратите внимание, что свойство Perimeter не реализовано.
}
