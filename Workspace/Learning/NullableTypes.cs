using Workspace.Learning.Classes.Resources;

namespace Workspace.Learning
{
    public static class NullableTypes
    {
        public static void LocalNullableVariables()
        {
            int? nullableInt = 10;
            double? nullableDouble = 3.14;
            bool? nullableBool = null;
            char? nullableChar = 'a';
            int?[] arrayOfNullableInts = new int?[10];
        }

        public static void NullableTypeExample()
        {
            Point point = null;
            // point.Display();     // null reference exception occurse when trying to reach values inside null object (fields, properties, methods and etc.)
#nullable enable
            Point? newPoint = null;

            newPoint?.Display();       // equal to -> if (newPoint != null) newPoint.Display()

            newPoint = point ?? new Point(2, 2);
            newPoint?.Display();       // show point (2, 2)
        }

    }
}