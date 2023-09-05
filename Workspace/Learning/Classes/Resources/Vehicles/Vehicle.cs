using System;

namespace Workspace.Learning.Classes.Resources.Vehicles;

public abstract class Vehicle
{
    public string ModelName { get; protected set; }

    public int CurrentSpeed { get; protected set; }
    public float Cost { get; protected set; }

    // constructor chain implementation
    protected Vehicle(string modelName = "moto", int currentSpeed = 0, float cost = 10000)
    {
        ModelName = modelName;
        CurrentSpeed = currentSpeed;
        Cost = cost;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Name: {ModelName} " +
                          $"\nSpeed: {CurrentSpeed}" +
                          $"\nCost: {Cost}\n");
    }

    public override string ToString()
    {
        return $"Name: {ModelName}\nSpeed: {CurrentSpeed}\nCost: {Cost}\n";
    }
}