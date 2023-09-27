using System;

namespace Learning.Classes.Resources.Vehicles;

public abstract class Vehicle
{
    public string ModelName { get; init; }
    public int CurrentSpeed { get; protected set; }
    public int MaxSpeed { get; init; }
    public float Cost { get; init; }

    protected Vehicle(string modelName = "moto", int currentSpeed = 0, int maxSpeed = 200, float cost = 10000)
    {
        ModelName = modelName;
        CurrentSpeed = currentSpeed;
        MaxSpeed = maxSpeed;
        Cost = cost;
    }

    public virtual void Display() =>
        Console.WriteLine($"Name: {ModelName} " +
                          $"\nCurrentSpeed: {CurrentSpeed}" +
                          $"\nCost: {Cost}\n");

    public override string ToString() =>
        $"ModelName: {ModelName}\n" +
        $"CurrentSpeed: {CurrentSpeed}\n" +
        $"MaxSpeed: {MaxSpeed}\n" +
        $"Cost: {Cost}\n";

}