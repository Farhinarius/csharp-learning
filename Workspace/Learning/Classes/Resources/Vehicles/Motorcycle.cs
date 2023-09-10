using System;

namespace Workspace.Learning.Classes.Resources.Vehicles
{

    public class Motorcycle : Vehicle
    {
        private int _driverIntensity;
        private string _driverName;
        private static readonly int MAX_INTENSITY = 10;

        // specify standard constructor, that will be set all fields on default values
        public Motorcycle() { }

        // constructor chain implementation
        public Motorcycle(string modelName) : this(modelName, 0) { }

        // constructor chain implementation
        public Motorcycle(int speed) : this("", speed) { }

        // constructor chain implementation
        public Motorcycle(int driverIntensity, string name) 
            : this(intensity: driverIntensity, driverName: name) { }

        // constructor chain implementation
        public Motorcycle(string modelName = "undefined", 
            int currentSpeed = 0,
            int maxSpeed = 200,
            float cost = 10000,
            int intensity = 5, 
            string driverName = "Default") 
            : base(modelName, currentSpeed, maxSpeed, cost)
        {
            if (intensity > MAX_INTENSITY)
            {
                intensity = MAX_INTENSITY;
            }
            _driverIntensity = intensity;
            _driverName = driverName;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Driver intensity: {0}, Driver name: {1}", _driverIntensity, _driverName);
        }
    }
}