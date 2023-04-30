using System;

namespace Workspace.Learning.GarbageCollection.Resources;

public class AdvancedResourceWrapper : IDisposable
{
    // Используется для выяснения, вызывался ли метод Dispose().
    private bool _disposed = false;
    
    public void Dispose()
    {
        // Вызвать вспомогательный метод.
        // Указание true означает, что очистку
        // запустил пользователь объекта.
        CleanUp(true);
        // Подавить финализацию.
        GC.SuppressFinalize(this);
    }
    private void CleanUp(bool disposingByUser)
    {
        // Удостовериться, не выполнялось ли уже освобождение,
        if (!this._disposed)
        {
            // Если disposing равно true, тогда
            // освободить все управляемые ресурсы,
            if (disposingByUser)
            {
                // Освободить управляемые ресурсы.
            }
            // Очистить неуправляемые ресурсы.
        }
        
        _disposed = true;
    }
    ~AdvancedResourceWrapper()
    {
        // Вызвать вспомогательный метод.
        // Указание false означает, что
        // очистку запустил сборщик мусора.
        CleanUp(false);
    }

}