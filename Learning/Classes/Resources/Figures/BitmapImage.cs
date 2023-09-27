using System;
using Learning.Classes.Resources.Figures.Interfaces;

namespace Learning.Classes.Resources.Figures;

public class BitmapImage : IAdvancedDraw
{
    public void Draw()
    {
        Console.WriteLine("Draw image");
    }

    public void DrawInBoundingBox(int top, int left, int bottom, int right)
    {
        Console.WriteLine("Draw image in bounding box");
    }

    public void DrawUpsideDown()
    {
        Console.WriteLine("Draw image upside down");
    }

    public int TimeToDraw() => 16;
}