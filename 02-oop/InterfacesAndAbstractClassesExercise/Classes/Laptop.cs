namespace InterfacesAndAbstractClassesExercise.Classes;
using InterfacesAndAbstractClassesExercise.Interfaces;
public class Laptop : ElectronicDevice, IRechargeable
{
    public Laptop(string brand, string model) : base(brand, model)
    {

    }

    public void Sleep()
    {
        Console.WriteLine($"The {Brand} {Model} is falling asleep...");
    }
    public string Recharge()
    {
        return $"The {Brand} {Model} laptop is now recharging...";
    }

    public override string TurnOff()
    {
        return $"The {Brand} {Model} laptop is now turning off...";
    }

    public override string TurnOn()
    {
        return $"The {Brand} {Model} laptop is now turning on...";
    }
}