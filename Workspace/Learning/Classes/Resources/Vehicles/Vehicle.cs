using System;

namespace Workspace.Learning.Classes.Resources.Vehicles;

public abstract class Vehicle
{
    protected string ModelName;
    
    protected int Speed;
    public float Cost { get; protected set; }

    public virtual void Display()
    {
        Console.WriteLine($"Name: {ModelName} " +
                          $"\nSpeed: {Speed}" +
                          $"\nCost: {Cost}");
    }
}