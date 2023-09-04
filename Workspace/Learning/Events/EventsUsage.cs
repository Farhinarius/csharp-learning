using System;
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
    }

}
