using System;

namespace Learning.GarbageCollection.Resources;

public class MyResourceWrapper
{
    // Очистить неуправляемые ресурсы.
    // Выдать звуковой сигнал при уничтожении
    // (только в целях тестирования).
    ~MyResourceWrapper() => Console.Beep();
}