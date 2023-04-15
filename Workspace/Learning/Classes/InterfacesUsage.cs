using System;
using Workspace.Learning.Classes.Resources.Figures;
using Workspace.Learning.Classes.Resources.Figures.Interfaces;

namespace Workspace.Learning.Classes;

public static class InterfacesUsage
{
    private static object Clone(ICloneable objectToClone)
    {
        return objectToClone.Clone();
    }
    
    public static void CloneableExample()
    {
        const string myStr = "helloStr";
        OperatingSystem os = Environment.OSVersion;
        Console.WriteLine($"HashCode of original string: {myStr.GetHashCode()}, Hashcode of cloned string: {Clone(myStr).GetHashCode()}");
        Console.WriteLine($"Hashcode of original OS: {os.GetHashCode()}, Hashcode of cloned OS: {Clone(os).GetHashCode()}");
    }

    public static void TestFiguresInterfaces()
    {
        Shape[] figures = { new Circle(), new Triangle(), new Hexagon(), new Square("simple square") };

        foreach (var figure in figures)
        {
            var figurePoints = (figure as IPointy)?.Points ?? 0;
            var figureType = figure?.GetType();
            Console.WriteLine($"Figure {figureType} has {figurePoints} amount of points and ");
            
            if (figure is IRegularPointy regularPointy)
            {
                regularPointy.SideLength = 4;
                Console.WriteLine($"Perimeter of {figure.PetName} is {regularPointy.Perimeter}");
            }
        }
    }
    
    
}