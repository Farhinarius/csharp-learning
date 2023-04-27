using System;

namespace Workspace.Learning.Classes.Resources.Vehicles;

public abstract class Vehicle
{
    public string ModelName;
    
    public int Speed;
    public float Cost { get; protected set; }

    // constructor chain implementation
    protected Vehicle(string modelName = "moto", int speed = 0, float cost = 10000)
    {
        ModelName = modelName;
        Speed = speed;
        Cost = cost;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Name: {ModelName} " +
                          $"\nSpeed: {Speed}" +
                          $"\nCost: {Cost}\n");
    }
}