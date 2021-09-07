using Workspace.Learning.ObjectsEssence.Resources;
using Workspace.Resources;

namespace Workspace.Learning
{
    public static class NullableTypes
    {
        public static void NullableTypeExample()
        {
            Point point = null;
            Point? newPoint = point;
            
            newPoint?.Display();       // show nothing

            newPoint = point ?? new Point(2, 2);
            newPoint?.Display();       // show point (2, 2)
        }
        
    }
}