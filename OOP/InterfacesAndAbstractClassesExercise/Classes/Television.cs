namespace InterfacesAndAbstractClassesExercise.Classes;

public class Television : ElectronicDevice
{

    public Television(string brand, string model) : base(brand, model)
    {

    }

    public void changeChannel()
    {
        Console.WriteLine("The channel has been changed...");
    }

    public override string TurnOff()
    {
        return $"The {Brand} {Model} television is now turning off...";
    }

    public override string TurnOn()
    {
        return $"The {Brand} {Model} television is now turning on...";
    }
}