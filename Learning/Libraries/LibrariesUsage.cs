// default usings namespaces statements (import whole namespace)      
// use type like -> new Square() (from namespace Workspace.Learning.Libraries.Shapes)
using Learning.Libraries.Resources.Shapes;
using Learning.Libraries.Resources.Shapes3D;

// give aliases to class Shape3D types (import specific type)
// use type like -> new Square3D() (from namespace Workspace.Learning.Libraries.Shapes3D)
using Hexagon3D = Learning.Libraries.Resources.Shapes3D.Hexagon;
using Circle3D = Learning.Libraries.Resources.Shapes3D.Circle;
using Square3D = Learning.Libraries.Resources.Shapes3D.Square;

// import namespaces as aliases, not a class
using figures = Learning.Classes.Resources.Figures;
using bfHome = System.Runtime.Serialization.Formatters.Binary;
// or
using System.Runtime.Serialization.Formatters.Binary;


namespace Learning.Libraries;

public static class LibrariesUsage
{
    // example of using types from imported namespace
    public static void UseTypesFromImportedNamespaces()
    {
        // using Shape classes rise a conflict,
        // since Shapes and Shapes3d contain classes with identical names
        // and it's not clear from which namespace to use type.
        //Hexagon h = new Hexagon();                          // Ошибка на этапе компиляции!
        //Circle c = new Circle();                            // Ошибка на этапе компиляции!
        //Square s = new Square();                            // Ошибка на этапе компиляции!
    }

    // fixture example of namespace conflicts
    public static void UseNamespaceTypesWithoutUsingStatement()
    {
        Resources.Shapes.Hexagon h = new Resources.Shapes.Hexagon();
        Resources.Shapes.Circle c = new Resources.Shapes.Circle();
        Resources.Shapes.Square s = new Resources.Shapes.Square();
    }

    // use aliases
    public static void ExampleSolveSimilarTypeConflicts()
    {
        Hexagon3D h = new Hexagon3D();
        Circle3D с = new Circle3D();  
        Square3D s = new Square3D();  
    }

    // use alias namespace
    public static void TestAliasNamespace()
    {
        figures.Circle c = new figures.Circle();
        figures.BitmapImage img = new figures.BitmapImage();
        bfHome.BinaryFormatter b = new bfHome.BinaryFormatter();
        BinaryFormatter bf = new BinaryFormatter();
    }

}
