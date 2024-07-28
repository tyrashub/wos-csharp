namespace InterfacesAndAbstractClassesExercise.Classes;

public abstract class ElectronicDevice
{
    public string Brand { get; set; }
    public string Model { get; set; }

    public ElectronicDevice(string brand, string model)
    {
        Brand = brand;
        Model = model;

    }

    public abstract string TurnOn();
    public abstract string TurnOff();


    public override string ToString()
    {
        return $"Brand: {Brand}, Model: {Model}";
    }

}