namespace Workspace.Learning.Classes.Resources.Figures.Interfaces;

public interface IRegularPointy : IPointy
{
    int SideLength { get; set; }
    int NumberOfSides { get; set; }
    int Perimeter => SideLength * NumberOfSides;
}