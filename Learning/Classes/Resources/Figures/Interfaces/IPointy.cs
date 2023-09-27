namespace Learning.Classes.Resources.Figures.Interfaces;

public interface IPointy
{
    // Ошибка! Интерфейсы не могут иметь поля данных!
    //public int numbOfPoints;
    // Ошибка! Интерфейсы не могут иметь нестатические конструкторы!
    //public IPointy() { numbOfPoints = 0;}

    // Может иметь следующие поля:
    // Неявно public и abstract.
    // byte GetNumberOfPoints();
    // Свойство, поддерживающее чтение и запись,
    // в интерфейсе может выглядеть так:
    // string PropName { get; set; }
    // Тогда как свойство только для записи - так:

    byte Points { get; }
}
