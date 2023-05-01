using System;
using System.Collections;
using System.Collections.Generic;

namespace Workspace.Learning.Classes.Resources.Vehicles;

public class Car : Vehicle, IComparable<Car> // IComparable - uncomment to test non generic impl of interface
{
    private static int _constructCounter = 0;
    public int Id { get; init; }
    
    // specify standard constructor, that will be set all fields on default values
    public Car() { }
        
    // constructor chain implementation
    public Car(string modelName) : this(modelName, 0) { }

    // constructor chain implementation
    public Car(int speed) : this(modelName: "auto", speed) { }

    // constructor chain implementation
    public Car(string modelName = "moto", int speed = 0, float cost = 10000) : base(modelName, speed, cost)
    {
        Id = _constructCounter;
        _constructCounter++;
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