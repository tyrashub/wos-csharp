namespace RiderMaker.Classes;
using RiderMaker.Interfaces;

public class Car : Vehicle, INeedFuel
{
    // Fields
    public string FuelType { get; set; }
    public int FuelTotal { get; set; }

    // Constructor
    public Car(string name, int numberOfPassengers, string color, bool hasEngine, int topSpeed, string fuelType) : base(name, numberOfPassengers, color, true, topSpeed)

    {
        FuelType = fuelType;
        FuelTotal = 10;
    }

    // Methods
    public void GiveFuel(int Amount)
    {
        FuelTotal += Amount;
        Console.WriteLine($"{Name} is now fueled by {FuelType}, adding {FuelTotal} gallon(s)...");
    }
}
