namespace Workspace.Learning.Classes.Resources.Vehicles
{

    public class Motorcycle : Vehicle
    {
        private Point _point = new Point();

        // specify standard constructor, that will be set all fields on default values
        public Motorcycle() { }

        // constructor chain implementation
        public Motorcycle(string modelName) : this(modelName, 0) { }

        // constructor chain implementation
        public Motorcycle(int speed) : this("", speed) { }

        // constructor chain implementation
        public Motorcycle(string modelName = "moto", int speed = 0, float cost = 10000, Point point = default)
            : base(modelName, speed, cost)
        {
            _point = point ?? new Point();
        }

        public override void Display()
        {
            base.Display();
            _point.Display();
        }
    }
}