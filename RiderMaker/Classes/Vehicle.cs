namespace RiderMaker.Classes;

public class Vehicle
{
    // Fields
    private string Name;
    private int NumberOfPassengers;
    private string Color;
    private bool HasEngine;
    public int DistanceTraveled;

    // Constructor
    public Vehicle(string name, int numberOfPassengers, string color, bool hasEngine)
    {
        Name = name;
        NumberOfPassengers = numberOfPassengers;
        Color = color;
        HasEngine = hasEngine;
        DistanceTraveled = 0;
    }

    // Methods

    // show information 
    public void ShowInfo()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Number of Passengers: {NumberOfPassengers}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Has Engine: {HasEngine}");
        Console.WriteLine($"Distance Traveled: {DistanceTraveled} miles");
        Console.WriteLine();
    }

    // allows a user to fill in name and color
    public Vehicle(string name, string color, int numberOfPassengers)
    {
        Name = name;
        Color = color;
        NumberOfPassengers = numberOfPassengers;
        HasEngine = true;
        DistanceTraveled = 0;
    }

    //  distance traveled
    public void Travel(int distance)
    {
        if (distance > 0)
        {
            DistanceTraveled += distance;
            Console.WriteLine($"The {Name} has traveled {distance} miles...");
        }
        else
        {
            Console.WriteLine("We aren't moving yet...");
        }
    }

}
