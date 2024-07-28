namespace InterfacesAndAbstractClassesExercise.Classes;
using InterfacesAndAbstractClassesExercise.Interfaces;
public class Smartphone : ElectronicDevice, IRechargeable
{
    public Smartphone(string brand, string model) : base(brand, model)
    {

    }

    public void Call()
    {
        Console.WriteLine($"The {Brand} {Model} is calling ....");
    }
    public string Recharge()
    {
        return $"The {Brand} {Model} smartphone is now recharging...";
    }

    public override string TurnOff()
    {
        return $"The {Brand} {Model} smartphone is now turning off...";
    }

    public override string TurnOn()
    {
        return $"The {Brand} {Model} smartphone is now turning on...";
    }
}