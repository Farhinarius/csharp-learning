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

        private Color _color;

        public Point() {}

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Color color)
        {
            _color = color;
        }
        
        public void Display()
        {
            Console.WriteLine($"Point values -> \nX: {X}, Y: {Y}");
        }

        public virtual void Draw()
        {   
            Console.WriteLine($"X: {X}\n Y: {Y}");
        }
        
        // Переопределить Object.ToString().
        public override string ToString() => $"X = {X}; Y = {Y}";
        
        // Возвратить копию текущего объекта.
        // public object Clone() => new Point(this.X, this.Y);
        
        // Копировать все поля Point по очереди. Упрощенная версия неглубоко копирования
        public object Clone() => this.MemberwiseClone();



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