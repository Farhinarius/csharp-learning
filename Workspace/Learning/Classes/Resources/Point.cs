using System;

namespace Workspace.Learning.Classes.Resources
{
    public class Point : ICloneable, IComparable<Point>
    {
        # region NestedTypes

        public enum Color
        {
            Red,
            Green,
            Blue
        }

        #endregion

        public int X { get; set; }
        public int Y { get; set; }

        public PointDescription Pd { get; set; } = new PointDescription();

        private Color _color;

        public Point() { }

        public Point(int x, int y, string petName = "New point")
        {
            X = x;
            Y = y;
            Pd.PetName = petName;
        }

        public Point(Color color)
        {
            _color = color;
        }

        public virtual void Display()
        {
            Console.Write($"\nPoint -> X: {X}, Y: {Y}");
        }

        public virtual void Draw()
        {
            Console.WriteLine($"X: {X}, Y: {Y}");
        }

        #region static

        public static void Draw(Point p)
        {
            // drawline logic with some library
        }

        public static void Draw(Point p, float thickness)
        {
            // drawline with thickness with some logic
        }

        #endregion

        #region Object base method overloading implementation

        public override string ToString() => $"X: {X}; Y: {Y}; Name: {Pd.PetName};\nID: {Pd.PointId}\n";

        public override bool Equals(object obj) => this.X == ((Point)obj).X && this.Y == ((Point)obj).Y;

        public override int GetHashCode() => this.ToString().GetHashCode();

        #endregion

        #region ICloneable implementation

        // Возвратить неглубокую копию текущего объекта.
        // public object Clone() => new Point(this.X, this.Y);

        // Копировать все поля Point по очереди. Упрощенная версия неглубоко копирования
        //public object Clone() => this.MemberwiseClone();

        public object Clone()
        {
            // Сначала получить поверхностную копию.
            Point newPoint = (Point)this.MemberwiseClone();

            // Затем восполнить пробелы.
            PointDescription currentDesc = new PointDescription();
            currentDesc.PetName = this.Pd.PetName;
            newPoint.Pd = currentDesc;

            return newPoint;
        }

        #endregion

        #region IComparable implementation 

        public int CompareTo(Point other)
        {
            if (this.X > other.X && this.Y > other.Y)
            {
                return 1;
            }
            if (this.X < other.X && this.Y < other.Y)
            {
                return -1;
            }
            return 0;
        }

        #endregion

        #region Operators overloading implementation 

        public static Point operator +(Point sourcePoint, Point pointToAdd)
            => new Point(sourcePoint.X + pointToAdd.X, sourcePoint.Y + pointToAdd.Y);

        public static Point operator -(Point sourcePoint, Point pointToSubtract)
            => new Point(sourcePoint.X - pointToSubtract.X, sourcePoint.Y - pointToSubtract.Y);

        public static Point operator +(Point sourcePoint, int change)
            => new Point(sourcePoint.X + change, sourcePoint.Y + change);

        public static Point operator -(Point sourcePoint, int change)
            => new Point(sourcePoint.X - change, sourcePoint.Y - change);

        public static Point operator +(int change, Point sourcePoint)
            => new Point(sourcePoint.X + change, sourcePoint.Y + change);

        // cannot subtract point from int
        public static Point operator ++(Point sourcePoint)
            => new Point(sourcePoint.X + 1, sourcePoint.Y + 1);

        public static Point operator --(Point sourcePint)
            => new Point(sourcePint.X - 1, sourcePint.Y - 1);

        public static bool operator ==(Point sourcePoint, Point pointToCompare)
            => sourcePoint.Equals(pointToCompare);

        public static bool operator !=(Point sourcePoint, Point pointToCompare)
            => !sourcePoint.Equals(pointToCompare);

        public static bool operator >(Point sourcePoint, Point pointToCompare)
            => sourcePoint.CompareTo(pointToCompare) > 0;

        public static bool operator <(Point sourcePoint, Point pointToCompare)
            => sourcePoint.CompareTo(pointToCompare) < 0;

        public static bool operator >=(Point sourcePoint, Point pointToCompare)
            => sourcePoint.CompareTo(pointToCompare) >= 0;

        public static bool operator <=(Point sourcePoint, Point pointToCompare)
            => sourcePoint.CompareTo(pointToCompare) <= 0;

        #endregion
    }
}