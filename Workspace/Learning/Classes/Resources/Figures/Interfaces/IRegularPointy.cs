namespace Workspace.Learning.Classes.Resources.Figures.Interfaces;

public interface IRegularPointy : IPointy
{
    // Статические члены также разрешены в версии C# 8.  к статическому свойству необходимо обращаться через
    // интерфейс, а не переменную экземпляра.
    static string ExampleProperty { get; set; }
    static IRegularPointy() => ExampleProperty = "Foo";

    int SideLength { get; set; }
    int NumberOfSides { get; set; }
    int Perimeter => SideLength * NumberOfSides;
}