namespace CarLibrary.Models;

public class MiniVan : Car
{
    public MiniVan(string name = "MiniVan", int maxSpeed = 200, int currentSpeed = 0) 
        : base(name, maxSpeed, currentSpeed)
    {}

    public override void TurboBoost()
    {
        State = EngineStateEnum.EngineDead;
        Console.WriteLine("Eek! Your engine block exploded!");
    }
}
