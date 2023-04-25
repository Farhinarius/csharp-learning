using System;

namespace Workspace.Learning.Classes.Resources.Vehicles;

public class Car : Vehicle
{
    // specify standard constructor, that will be set all fields on default values
    public Car() { }
        
    // constructor chain implementation
    public Car(string modelName) : this(modelName, 0) { }

    // constructor chain implementation
    public Car(int speed) : this(modelName: "auto", speed) { }

    // constructor chain implementation
    public Car(string modelName = "moto", int speed = 0, float cost = 10000)
    {
        ModelName = modelName;
        Speed = speed;
        Cost = cost;
    }
}