namespace RiderMaker.Classes;

public abstract class Vehicle
{
    // Fields
    public string Name;
    public int NumberOfPassengers;
    public string Color;
    public bool HasEngine;
    public int TopSpeed;
    public int DistanceTraveled;

    // Constructor
    public Vehicle(string name, int numberOfPassengers, string color, bool hasEngine, int topSpeed)
    {
        Name = name;
        NumberOfPassengers = numberOfPassengers;
        Color = color;
        HasEngine = hasEngine;
        TopSpeed = topSpeed;
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
        Console.WriteLine($"Top Speed: {TopSpeed} mph");
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
        TopSpeed = 120;
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
