using System;
using Workspace.Learning.ObjectsEssence.Resources;

namespace Workspace.Learning.ObjectsEssence;

public static class RecordsUsage
{
    public static void RecordEquality()
    {
        CarRecord myCarRecord = new CarRecord("Japan", "S3000", "black");
        CarRecord anotherMyCarRecord = new CarRecord("Japan", "S3000", "black");
        
        // Эквивалентны ли экземпляры CarRecord?
        Console.WriteLine($"CarRecords are the same? {myCarRecord.Equals(anotherMyCarRecord)}");        // true
        Console.WriteLine($"MCarRecords are the same reference? {ReferenceEquals(myCarRecord, anotherMyCarRecord)}"); // false
        
        // Указывают ли экземпляры CarRecord на тот же самый объект?
        Console.WriteLine($"CarRecords are the same? {myCarRecord == anotherMyCarRecord}");             // true
        Console.WriteLine($"CarRecords are not the same? {myCarRecord != anotherMyCarRecord}");         // false
    }

    public static void DeepCopyRecords()
    {
        CarRecord myCarRecord = new CarRecord("Japan", "S3000", "black");   // copy with changed properties -> myCarRecord with {Model = "Odyssey"};
        CarRecord ourOtherCar = myCarRecord with {};
        Console.WriteLine("My copied car:");
        Console.WriteLine(ourOtherCar.ToString());
        Console.WriteLine("Car Record copy using with expression results");
        // Результаты копирования CarRecord
        // с использованием выражения with
        Console.WriteLine($"CarRecords are the same? {ourOtherCar.Equals(myCarRecord)}");
        Console.WriteLine($"CarRecords are the same? {ReferenceEquals(ourOtherCar, myCarRecord)}");
    }
}