namespace CarLibrary.Models;

public class SportsCar : Car
{
    public SportsCar(string name = "Lambo", int maxSpeed = 200, int currentSpeed = 0)
        : base(name, maxSpeed, currentSpeed) { }

    public override void TurboBoost()
    {
        State = EngineStateEnum.EngineAlive;
        Console.WriteLine("Oooh! Supa fast!");
    }
}
