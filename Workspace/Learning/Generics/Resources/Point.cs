using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.Learning.Generics.Resources
{
    public class Point<T>
    {
        // Обобщенные данные состояния,
        private T _xPos;
        private T _yPos;

        public Point() { }

        // Обобщенный конструктор,
        public Point(T xVal, T yVal)
        {
            _xPos = xVal;
            _yPos = yVal;
        }
        
        // Обобщенные свойства,
        public T X
        {
            get => _xPos;
            set => _xPos = value;
        }

        public T Y
        {
            get => _yPos;
            set => _yPos = value;
        }
        public void ResetPoint()
        {
            _xPos = default;
            _yPos = default;
        }

        public override string ToString() => $"[{X}, {Y}]";

    }
}
