using System;

namespace Workspace.Learning.GarbageCollection.Resources;

public class DisposableObject : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine($"Utilize ${typeof(DisposableObject)}");
    }
}