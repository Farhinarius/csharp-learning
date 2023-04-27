using System;

namespace Workspace.Learning.Classes.Resources
{
    public class Point
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

        public Point() {}

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
        
        public void Display()
        {
            Console.WriteLine($"Point values -> X: {X}, Y: {Y}\n");
        }

        public virtual void Draw()
        {   
            Console.WriteLine($"X: {X}\n Y: {Y}");
        }
        
        #region ToString implementation
        // Переопределить Object.ToString().
        public override string ToString() => $"X = {X}; Y = {Y}; Name = {Pd.PetName};\nID = {Pd.PointId}\n";
        
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
    }
}