namespace RiderMaker.Classes;
using RiderMaker.Interfaces;

public class Bike : Vehicle
{
    // Constructor
    public Bike(string name, int numberOfPassengers, string color, bool hasEngine, int topSpeed) : base(name, numberOfPassengers, color, false, topSpeed) { }
}