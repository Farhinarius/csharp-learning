using System;
using System.Reflection.Metadata.Ecma335;
using Workspace.Learning.Classes.Resources.Vehicles;
using Workspace.Learning.Events.Resources;

namespace Workspace.Learning.Events;

public static class EventsUsage
{
    private delegate int BinaryOp(int x, int y);

    public static void TestDelegateType()
    {
        BinaryOp binaryOp = SimpleMath.Add;        // assign method to delegate instance
        // binaryOp += SimpleMath.Subtract;        // append method to delegate instance 
        // if delegate instance contains more than one methods with return values,
        // after delegate instance call result will be retrieved from the return value of last subscribed function

        Console.WriteLine("5 + 5 = {0}", binaryOp(5, 5));
        DisplayDelegateInfo(binaryOp);
    }

    public static void DisplayDelegateInfo(Delegate delegateObj)
    {
        foreach (var d in delegateObj.GetInvocationList())
        { 
            Console.WriteLine("Method name: {0}", d.Method);        // method name
            Console.WriteLine("Type name: {0}", d.Target);        // type name
        }
    }

    public static void TestDelegateInstancesAsEvents()
    {
        Car car = new Car(currentSpeed: 0, maxSpeed: 200);

        // declare delegate instance (handler) and assign OnCarEngineBroken method
        // Car.CarEngineHandler onCarEngineBrokenHandler = new Car.CarEngineHandler(OnCarEngineBroken);

        // assign handler to delegate instance (_listOfHandlers) inside car class
        // car.RegisterCarEngineHandler(new Car.CarEngineHandler(OnCarEngineBroken));
        // car.RegisterCarEngineHandler(onCarEngineBrokenHandler);

        // assign just method name
        car.RegisterCarEngineHandler(OnCarEngineBroken);

        // assgin anonymous method as handler to delegate instance (_listOfHandlers) inside car class
        car.RegisterCarEngineHandler((msg) =>
        {
            Console.WriteLine("Message From Car Object => {0}", msg);
        });

        for (int i = 0; i < 22; i++)
        {
            car.Accelerate(10);
        }

        // unregister onCarEngineBrokenHandler from delegate instance (_listOfHandlers) inside car class
        //car.UnregisterCarEngineHandler(onCarEngineBrokenHandler);
        car.UnregisterCarEngineHandler(OnCarEngineBroken);

        car.Reset();
        for (int i = 0; i < 22; i++)
        {
            car.Accelerate(10);
        }
    }

    // callback declaration
    public static void OnCarEngineBroken(string msg)
    {
        Console.WriteLine($"Car engine message received");
    }
}
