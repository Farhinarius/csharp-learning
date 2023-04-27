using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Workspace.Learning.Classes.Resources;
using Workspace.Learning.Classes.Resources.Figures;
using Workspace.Learning.Classes.Resources.Figures.Interfaces;
using Workspace.Learning.Classes.Resources.Vehicles;

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

    public static void UseEnumeratorImplicitly()
    {
        Garage garage = new Garage();
        foreach (var vehicle in garage)
        {
            (vehicle as Vehicle)?.Display();
        }
    }
    
    public static void UseEnumeratorExplicitlyWithExplicitInterfaceImplementation()
    {
        Garage garage = new Garage();

        var e = ((IEnumerable)garage).GetEnumerator();
        for (var i = 0; i < garage.Length; i++)
        {
            e.MoveNext();
            var vehicle = (Vehicle) e.Current;
            vehicle?.Display();
        }
    }

    public static void UseEnumeratorExplicitlyWithImplicitInterfaceImplementation()
    {
        Garage garage = new Garage();

        var e = garage.GetEnumerator();     // method do not called (implicitly returns an IEnumerator)
        for (var i = 0; i < garage.Length; i++)
        {
            e.MoveNext();                           // calls garage.GetEnumerator and pause execution on yield statement for next MoveNext call
            var vehicle = (Vehicle) e.Current;
            vehicle?.Display();
        }
    }

    public static void EnumerateByField()
    {
        Garage garage = new Garage();

        var costEnumerator = garage.GetFieldEnumerator();
        for (int i = 0; i < garage.Length; i++)
        {
            costEnumerator.MoveNext();
            Console.WriteLine(costEnumerator.Current);
        }
    }

    public static void EnumeratePointClass()
    {
        Point3D p3d = new Point3D(1, 2, 3);
        foreach (var point in p3d)
        {
            Console.WriteLine($"Point value: {point}");
        }
    }

    public static void UselessEnumeratorCall()
    {
        Garage garage = new Garage();
        IEnumerator garageEnumerator = garage.GetEnumerator();      // method will not be called
        Console.ReadLine();
    }

    public static void UseProtectedEnumerator()
    {
        Garage garage = new Garage();
        try
        {
            // На этот раз возникает ошибка.
            var vehicleEnumerator = garage.GetEnumeratorProtected();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception occurred on GetEnumerator");
        }
    }

    public static void UseNamedIterator()
    {
        Garage garage = new Garage();
        // Получить элементы (в обратном порядке!)
        // с применением именованного итератора.
        foreach (Vehicle v in garage.GetTheVehicles(true))
        {
            Console.WriteLine("Vehicle cost is {0}", v.Cost);
        }
    }

    public static void UseICloneableToCloneObject()
    {
        Point p3 = new Point(1, 1);
        Point p4 = (Point)p3.Clone();
        
        // Изменить р4.Х (что не приводит к изменению рЗ.х). Убедились, что работаем с клоном
        p4.X = 0;
        
        // Вывести все объекты.
        Console.WriteLine($"Original point: {p3}");
        Console.WriteLine($"Cloned and changed point : {p4}");
    }

    public static void DeepCloneableImplementation()
    {
        Point p3 = new Point(1, 1);
        Point p4 = (Point)p3.Clone();
        
        Console.WriteLine("Before modification:"); // Перед модификацией
        Console.WriteLine("p3: {0}", p3);
        Console.WriteLine("p4: {0}", p4);
        
        p4.Pd.PetName = "My new Point";
        p4.X = 9;
        
        Console.WriteLine("\nChanged p4.Pd.PetName and p4.X");
        Console.WriteLine("After modification:");
        Console.WriteLine("p3: {0}", p3);
        Console.WriteLine("p4: {0}", p4);
    }
    
}