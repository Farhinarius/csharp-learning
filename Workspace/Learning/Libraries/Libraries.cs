using Workspace.Learning.Libraries.Shapes;
using Workspace.Learning.Libraries.Shapes3D;

namespace Workspace.Learning.Libraries;

public static class Libraries
{
    public static void UseTypesFromDifferentNamespaces()
    {
        //Hexagon h = new Hexagon();  // Ошибка на этапе компиляции!
        //Circle c = new Circle();    // Ошибка на этапе компиляции!
        //Square s = new Square();    // Ошибка на этапе компиляции!
    }

    public static void UseNamespaceTypesWithoutUsingStatement()
    {
        Shapes.Hexagon h = new Shapes.Hexagon();
        Shapes.Circle c = new Shapes.Circle();
        Shapes.Square s = new Shapes.Square();
    }

    public static void TestNamespaceSimilarTypeConflicts()
    {
        // Н а какое пространство имен производится ссылка?
        Shapes3D.Hexagon h = new Shapes3D.Hexagon();  // Ошибка на этапе компиляции!
        Shapes3D.Circle с = new Shapes3D.Circle();    // Ошибка на этапе компиляции!
        Shapes3D.Square s = new Shapes3D.Square();    // Ошибка на этапе компиляции!

    }
}
