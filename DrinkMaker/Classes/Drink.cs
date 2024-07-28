namespace DrinkMaker.Classes;

public class Drink
{
    // Fields
    public string Name;
    public string Color;
    public double Temperature;
    public bool IsCarbonated;
    public int Calories;

    // We need a basic constructor that takes all these features in
    public Drink(string name, string color, double temp, bool isCarb, int calories)
    {
        Name = name;
        Color = color;
        Temperature = temp;
        IsCarbonated = isCarb;
        Calories = calories;
    }

    // ShowDrink() method
    public virtual void ShowDrink()
    {
        Console.WriteLine($"Name: {Name}");
        Console.WriteLine($"Color: {Color}");
        Console.WriteLine($"Temperature: {Temperature} °F");
        Console.WriteLine($"Carbonated: {IsCarbonated}");
        Console.WriteLine($"Calories (per serving): {Calories}");
    }
}

