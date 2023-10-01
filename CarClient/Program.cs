using CarLibrary.Models;

// Создать объект MiniVan.
MiniVan mv = new MiniVan();
mv.TurboBoost();

SportsCar sportsCar = new SportsCar();
sportsCar.TurboBoost();

Console.WriteLine("Done. Press any key to terminate");
// Готово. Нажмите любую клавишу для прекращения работы
Console.ReadLine();