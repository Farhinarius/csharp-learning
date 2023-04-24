using System;

namespace Workspace.Learning.Classes.Resources
{
    
    public class Motorcycle
    {
        private string _modelName;
        
        private int _speed;

        private Point _point = new Point();
        
        public float Cost { get; set; }

        // specify standard constructor, that will be set all fields on default values
        public Motorcycle() { }
        
        // constructor chain implementation
        public Motorcycle(string modelName) : this(modelName, 0) { }

        // constructor chain implementation
        public Motorcycle(int speed) : this("", speed) { }

        // constructor chain implementation
        public Motorcycle(string modelName = "moto", int speed = 0, float cost = 10000, Point point = default)
        {
            _modelName = modelName;
            _speed = speed;
            Cost = cost;
            _point = point ?? new Point();
        }
        
        public void Display()
        {
            Console.WriteLine($"Name: {_modelName} " +
                              $"\nSpeed: {_speed}" +
                              $"\nCost: {Cost}" +
                              $"\nPoint: ");
            _point.Display();
        }
    }
}