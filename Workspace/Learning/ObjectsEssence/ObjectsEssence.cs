using Workspace.Learning.ObjectsEssence.Resources;

namespace Workspace.Learning.ObjectsEssence
{
    public static class ObjectsEssence
    {
        // for better understanding of this methods you need to check classes inside
        public static void ChainConstructorWithDefaultParameters()
        {
            Motorcycle m = new Motorcycle(5);
            m.Display();
        }
        
        public static void InheritanceConstructor()
        {
            Point3D p3 = new Point3D(10, 10, 10);
        }

        public static void ParametricPolymorphism()
        {
            Point pointToDraw = new Point();
            Point.Draw(pointToDraw);
            Point.Draw(pointToDraw, 5.5f);
        }

        public static void InheritancePolymorphism()
        {
            Point p4 = new Point(10, 10);
            Point p5 = new Point3D(1, 2, 3);
        }

        public static void OverridingPolymorphism()
        {
            // Enemy.attack()       ->  virtual method of abstract class
            // Lizard.attack()      ->  overrided method for real class
        } 
    }
}