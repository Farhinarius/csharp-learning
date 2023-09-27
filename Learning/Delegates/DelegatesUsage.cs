using System;
using System.Collections.Generic;
using Learning.Classes.Resources.Vehicles;
using Learning.Delegates.Resources;

namespace Learning.Delegates;

public static class DelegatesUsage
{
    private delegate int BinaryOp(int x, int y);

    private delegate void MyGenericDelegate<T>(T args);

    public static void DelegateTest()
    {
        double[] a = { 0.0, 0.5, 1.0 };
        double[] squares = DelegateExample.Apply(a, (x) => x * x);
        DelegateExample.OutputArray(squares);

        double[] sines = DelegateExample.Apply(a, Math.Sin);
        DelegateExample.OutputArray(sines);

        Multiplier m = new Multiplier(2.0);
        double[] doubles = DelegateExample.Apply(a, m.Multiply);
        DelegateExample.OutputArray(doubles);
    }

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

    public static void TestDelegateInstances()
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
        car.RegisterCarEngineHandler((_, msg) =>
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
    public static void OnCarEngineBroken(object sender, string msg)
    {
        Console.WriteLine($"Car engine message received");
    }

    public static void TestGenericDelegate()
    {
        MyGenericDelegate<string> strTarget = str =>
        {
            Console.WriteLine("Upper string: {0}", str.ToUpper());
        };

        MyGenericDelegate<int> intTarget = number =>
        {
            Console.WriteLine("Increment number: {0}", ++number);
        };

        MyGenericDelegate<(string statusMessage, int statusCode)> messageHandler = response =>
        {
            Console.WriteLine("Status message: {0}", response.statusMessage);
            Console.WriteLine("Status code: {0}", response.statusCode);
        };

        EventHandler<(int, int, string)> responseHandler = (s, args) =>
        {
            Console.WriteLine("Status code: {0}", args.Item1);
            Console.WriteLine("Error code: {0}", args.Item2);
            Console.WriteLine("Message: {0}", args.Item3);
        };

        strTarget("Ultimate super cool string");
        Console.WriteLine();

        intTarget(10);
        Console.WriteLine();

        messageHandler?.Invoke(("Ultimate super cool string", 5));
        Console.WriteLine();

        responseHandler?.Invoke(null, (1, 0, "Response retrieved"));
        Console.WriteLine();
    }

    public static void TestActionDelegate()
    {
        Action<string, ConsoleColor, int> actionTarget = (msg, textColor, printCount) =>
        {
            ConsoleColor previous = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            for (int i = 0; i < printCount; i++)
            {
                Console.WriteLine(msg);
            }
            Console.ForegroundColor = previous;
        };

        actionTarget("Action Message!", ConsoleColor.Yellow, 5);
    }

    public static void TestFuncDelegate()
    {
        Func<int, int, int> addFunc = SimpleMath.Add;
        int result = addFunc.Invoke(5, 5);
        Console.WriteLine("5 + 5 = {0}", result);

        Func<int, int, string> sumToStringFunc = (x, y) =>
        {
            return (x + y).ToString();
        };
        string sum = sumToStringFunc?.Invoke(5, 5);
        Console.WriteLine(sum);
    }

    public static void TestEvents()
    {
        var car = new Car(currentSpeed: 0);

        car.OnExplode += (_, msg) => Console.WriteLine(msg);

        for (int i = 0; i < 22; i++)
        {
            car.Accelerate(10);
        }
    }

    public static void TestAnonymousHandlers()
    {
        Car car = new Car("SlugBug", 10, 100);

        car.OnExplode += delegate
        {
            Console.WriteLine("OnExplode callback");
        };

        car.OnExplode += delegate (object sender, string msg)
        {
            Console.WriteLine(msg);
        };

        int aboutToBlowCounter = 0;
        // Зарегистрировать обработчики событий как анонимные методы,
        car.OnAboutToBlow += delegate
        {
            aboutToBlowCounter++;
            Console.WriteLine("Eek! Going too fast!, aboutToBlowCounter + 1");
        };

        car.OnAboutToBlow += delegate (object sender, string message)
        {
            aboutToBlowCounter++;
            Console.WriteLine("Critical Message from Car: {0}, aboutToBlowCounter + 1", message);
        };

        car.OnAboutToBlow += static delegate
        {
            // aboutToBlowCounter++         // error: CS8820 A static anonymous function cannot contain a reference to aboutToBlowCounter
            Console.WriteLine("Static anonumous method called. Cannot change local external variables in internal anonymous method context");
        };

        // В конце концов, это будет инициировать события,
        for (int i = 0; i < 10; i++)
        {
            car.Accelerate(10);
        }
        Console.WriteLine("AboutToBlow event was fired {0} times.", aboutToBlowCounter);
        Console.ReadLine();
    }

    public static void TestLambdaWithLinq()
    {
        List<int> ints = new List<int> { 20, 1, 4, 8, 9, 44 };

        List<int> evenNumbers = ints.FindAll(n => n % 2 == 0);

        List<int> oddNumbers = ints.FindAll(i =>
        {
            Console.WriteLine("value of i is currently: {0}", i);
            bool isOdd = i % 2 != 0;
            return isOdd;
        });


        Console.WriteLine("Here are your even nubmers:");
        foreach (var evenNumber in evenNumbers)
        {
            Console.Write("{0}\t", evenNumber);
        }

        Console.WriteLine("Here are your odd nubmers:");
        foreach (var oddNumber in oddNumbers)
        {
            Console.Write("{0}\t", oddNumber);
        }

    }

    public static void TetsStaticKeywordWithLambda()
    {
        var outerVariable = 0;
        Func<int, int, bool> DoWork = static (x, y) =>
        {
            // Ошибка на этапе компиляции по причине доступа
            // к внешней переменной.
            // outerVariable++;
            return true;
        };
    }


}
