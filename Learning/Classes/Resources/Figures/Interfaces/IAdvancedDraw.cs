namespace Learning.Classes.Resources.Figures.Interfaces;

public interface IAdvancedDraw : IDraw
{
    void DrawInBoundingBox(int top, int left, int bottom, int right);
    void DrawUpsideDown();
    new int TimeToDraw() => 15;
}