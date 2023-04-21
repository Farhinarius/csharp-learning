using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Workspace.Learning.Classes.Resources;
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

    public static void TestArrayOfInterfaceTypes()
    {
        IPointy[] pointyFigures = { new Hexagon(), new Square(), new Triangle() };
        foreach (var pf in pointyFigures)
        {
            Console.WriteLine($"Figure {pf.GetType()} has {pf.Points} number of points ");
        }
    }

    public static void TestExplicitInterfaceImplementation()
    {
        Octagon octagon = new Octagon();
        ((IDrawToForm)octagon).Draw();      // 1
        (octagon as IDrawToMemory).Draw();  // 2
        if (octagon is IDrawToPrinter printedOctagon) // 3
        {
            printedOctagon.Draw();
        }
    }

    public static void TestHierarchyOfInterfacesWithBitmapImageClass()
    {
        BitmapImage bitmapImage = new BitmapImage();
        bitmapImage.Draw();
        bitmapImage.DrawInBoundingBox(10,10,100,100);
        bitmapImage.DrawUpsideDown();
        // instance of BitmapImage do not have access to TimeToDraw standard implementation of interface member
        // bitmapImage.TimeToDraw -> Compile error occured
        if (bitmapImage is IAdvancedDrawable advancedDrawable)
        {
            advancedDrawable.DrawUpsideDown();
            Console.WriteLine($"Time to draw: {advancedDrawable.TimeToDraw() }");   // only interface casted type can reach inherited interface type  
        }
        
        // if class implement standard interface member, then after call of implemented member either on class, or on interface every time
        // will be called implementation of that member
        Console.WriteLine("Calling Implemented TimeToDraw");
        Console.WriteLine($"Time to draw: {bitmapImage.TimeToDraw()}");         // implementation inside BitmapImage  
        Console.WriteLine($"Time to draw: {((IDrawable) bitmapImage).TimeToDraw()}");   // implementation inside BitmapImage
        Console.WriteLine($"Time to draw: {((IAdvancedDrawable) bitmapImage).TimeToDraw()}");   // implementation inside BitmapImage
    }
    
    public static void UseEnumerator()
    {
        Garage garage = new Garage();
        foreach (var car in garage)
        {
            ((Motorcycle) car)?.Display();
        }

        var e = ((IEnumerable)garage).GetEnumerator();
        for (var i = 0; i < garage.Length; i++)
        {
            e.MoveNext();
            var motorcycle = (Motorcycle) e.Current;
            motorcycle?.Display();
        }
        
        
    }

    public static void UseEnumeratorWithYield()
    {
        var garage = new Garage();

        foreach (var motorcycle in garage)
        {
            (motorcycle as Motorcycle)?.Display();
        }
    }
    
    
}