using System;
using Learning.Classes.Resources.Figures.Interfaces;

namespace Learning.Classes.Resources.Figures;

public class Octagon : IDrawToForm, IDrawToMemory, IDrawToPrinter
{
    // Явно привязать реализации Draw() к конкретным интерфейсам.
    // Модификатор доступа не может быть указан!
    void IDrawToForm.Draw()
    {
        Console.WriteLine("Draw to form");
    }

    void IDrawToMemory.Draw()
    {
        Console.WriteLine("Draw to memory");
    }

    void IDrawToPrinter.Draw()
    {
        Console.WriteLine("Draw to printer");
    }
}