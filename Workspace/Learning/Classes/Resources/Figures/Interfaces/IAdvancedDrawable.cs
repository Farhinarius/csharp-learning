namespace Workspace.Learning.Classes.Resources.Figures.Interfaces;

public interface IAdvancedDrawable : IDrawable
{
    void DrawInBoundingBox(int top, int left, int bottom, int right);
    void DrawUpsideDown();
    new int TimeToDraw() => 15;
}