using RiderMaker.Interfaces;

namespace RiderMaker.Classes;

public class Horse : Vehicle, INeedFuel
{
    // Fields
    public string FuelType { get; set; }
    public int FuelTotal { get; set; }

    // Constructor
    public Horse(string name, int numberOfPassengers, string color, bool hasEngine, int topSpeed, string fuelType) : base(name, numberOfPassengers, color, false, topSpeed)

    {
        FuelType = fuelType;
        FuelTotal = 10;
    }

    // Methods

    public void GiveFuel(int Amount)
    {
        FuelTotal += Amount;
        Console.WriteLine($"{Name} is now fueled by {FuelType}...");
    }
}
