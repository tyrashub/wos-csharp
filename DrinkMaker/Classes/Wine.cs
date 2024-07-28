namespace DrinkMaker.Classes;

public class Wine : Drink
{
    // New Fields
    public string Region { get; set; }
    public int Year { get; set; }

    // Constructor
    public Wine(string name, string color, double temp, string region, int year, int calories)
        : base(name, color, temp, false, calories)
    {
        Region = region;
        Year = year;
    }

    // ShowDrink method, have to override this per dev kit
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Year: {Year}");
        Console.WriteLine();
    }
}