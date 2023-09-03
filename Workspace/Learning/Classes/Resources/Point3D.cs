
using System;
using System.Collections;
using System.Collections.Generic;

namespace Workspace.Learning.Classes.Resources
{
    public class Point3D : Point, IEnumerable<int>
    {
        public int Z { get; set; }

        public Point3D() { }

        public Point3D(int x, int y, int z)
            : base(x, y) =>
            Z = z;

        public override void Display()
        {
            base.Display();
            Console.Write($", Z: {Z}");
        }

        public override void Draw()
        {
            base.Draw();
            Console.Write($", Z: {Z}");
        }

        public IEnumerator<int> GetEnumerator()
        {
            yield return X;
            yield return Y;
            yield return Z;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}