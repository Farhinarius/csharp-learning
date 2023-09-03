using System;

namespace Workspace.Learning.GarbageCollection.Resources;

public class UnhandledResourceWrapper : IDisposable
{
    // Сборщик мусора будет вызывать этот метод, если
    // пользователь объекта забыл вызвать Dispose().
    ~UnhandledResourceWrapper()
    {
        // Очистить любые внутренние неуправляемые ресурсы.
        // **Не** вызывать Dispose() на управляемых объектах.
    }

    // Пользователь объекта будет вызывать этот метод
    // для как можно более скорой очистки ресурсов,
    public void Dispose()
    {
        // Очистить неуправляемые ресурсы.
        // Вызвать Dispose() для других освобождаемых объектов,
        // содержащихся внутри.
        // Если пользователь вызвал Dispose(), то финализация
        // не нужна, поэтому подавить ее.
        GC.SuppressFinalize(this);
    }

}