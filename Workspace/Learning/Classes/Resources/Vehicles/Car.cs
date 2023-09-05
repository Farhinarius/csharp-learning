using System;
using System.Collections.Generic;

namespace Workspace.Learning.Classes.Resources.Vehicles;

public class Car : Vehicle, IComparable<Car> // IComparable - uncomment to test non generic impl of interface
{
    private static int _constructCounter = 0;
    public int Id { get; init; }
    public int MaxSpeed { get; init; }
    public bool CarIsDead { get; private set; } = default;

    public delegate void CarEngineHandler(string msgForCaller);
    
    private CarEngineHandler _listOfHandlers;

    public void RegisterCarEngineHandler(CarEngineHandler methodToCall)
    {
        _listOfHandlers += methodToCall;
    }

    public void UnregisterCarEngineHandler(CarEngineHandler methodToRemove)
    {
        _listOfHandlers -= methodToRemove;
    }

    // specify standard constructor, that will be set all fields on default values
    public Car() { } 

    // constructor chain implementation
    public Car(string modelName) : this(modelName, 0) { }

    // constructor chain implementation
    public Car(int speedToSet) : this(modelName: "undefined", speedToSet) { }

    // constructor chain implementation
    public Car(string modelName = "undefined", int currentSpeed = 0, int maxSpeed = 200, float cost = 10000) 
        : base(modelName, currentSpeed, cost)
    {
        Id = _constructCounter;
        _constructCounter++;
        MaxSpeed = maxSpeed;
    }

    public void Accelerate(int delta)
    {
        // Если этот автомобиль сломан, то отправить сообщение об этом,
        if (CarIsDead)
        {
            _listOfHandlers?.Invoke("Sorry, this car is dead...");
        }
        else
        {
            CurrentSpeed += delta;
            Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            // Автомобиль почти сломан?
            if (Math.Abs(MaxSpeed - CurrentSpeed) <= 10)
            {
                _listOfHandlers?.Invoke("Careful buddy! Gonna blow!");
            }
            if (CurrentSpeed > MaxSpeed)
            {
                CarIsDead = true;
            }
        }
    }

    public void Reset()
    {
        CurrentSpeed = 0;
        CarIsDead = false;
    }


    #region IComparable

    // Implementation of a non-generic interface !!!
    // int IComparable.CompareTo(object other)
    // {
    //     if (other is not Car comparedCar) throw new ArgumentException("Parameter is not a Car!");
    //     // delegate comparison to IComparable implementation of System.Int32
    //     return this.Id.CompareTo(comparedCar.Id);
    // }
    int IComparable<Car>.CompareTo(Car otherCar) => Id.CompareTo(otherCar.Id);

    #endregion

    #region IComparer

    public static IComparer<Car> SortByCarModelName
        => new CarModelNameComparer();

    #endregion
}
// Implementation of a non-generic interface !!!
// public class CarModelNameNameComparer : IComparer
// {
//     // Проверить дружественное имя каждого объекта,
//     int IComparer.Compare(object ol, object o2)
//     {
//         if (ol is not Car c1 || o2 is not Car c2) throw new ArgumentException("Parameter is not a Car!");
//         
//         return string.Compare(c1.ModelName, c2.ModelName,
//                 StringComparison.OrdinalIgnoreCase);
//     }
// }


public class CarModelNameComparer : IComparer<Car>
{
    int IComparer<Car>.Compare(Car c1, Car c2)
        => string.Compare(c1?.ModelName, c2?.ModelName, StringComparison.OrdinalIgnoreCase);
}