using System;
using System.Collections.Generic;
using System.Linq;
using Workspace.Learning.Classes.Resources.Figures;
using Workspace.Learning.Classes.Resources.Figures.Interfaces;

namespace Workspace.Learning.Classes;

public static class InterfacesUsage
{
    private static object Clone(ICloneable objectToClone)
    {
        return objectToClone.Clone();
    }

    private static void PassInterfaceTypeAsParameter(IDraw3d volumeFigure)
    {
        volumeFigure.Draw3d();         // can be anything that implement IDraw3d 
    }

    private static IPointy ReturnInterfaceType(IEnumerable<Shape> shapes)
    {
        foreach (Shape s in shapes)
        {
            if (s is IPointy ip)
            {
                return ip;
            }
        }
        return null;
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

    public static void TestInterfaceAsParameter()
    {
        PassInterfaceTypeAsParameter(new Hexagon());
        PassInterfaceTypeAsParameter(new Circle());
        
        Shape[] myShapes = { new Hexagon(), new Circle(),
            new Triangle("Joe"), new Circle("JoJo") } ;
        foreach (var t in myShapes)
        {
            // Можно ли нарисовать эту фигуру в трехмерном виде?
            if (t is IDraw3d s)
            {
                PassInterfaceTypeAsParameter(s);
            }
        }
    }

    public static void TestExplicitInterfaceImplementation()
    {
        Octagon octagon = new Octagon();
        ((IDrawToForm)octagon).Draw();
        ((IDrawToMemory)octagon).Draw();
        ((IDrawToPrinter)octagon).Draw();
    }
    
    
}