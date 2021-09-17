
using System;

namespace Workspace.Learning.ObjectsEssence.Resources
{
    public class Point3D : Point
    {
        public int Z { get; set; }
        public Point3D(int x, int y, int z) 
            : base(x, y) =>
            Z = z;

        public override void Draw()
        {
            base.Draw();
            Console.WriteLine($"Z: {Z}");
        }
    }
}