namespace DrinkMaker.Classes;

public class Soda : Drink
{
    // New field
    public bool IsDiet { get; set; }

    // Constructor 
    public Soda(string name, string color, double temp, bool isDiet, int calories)
        : base(name, color, temp, true, calories)
    {
        IsDiet = isDiet;
    }

    // ShowDrink method, have to override this per dev kit
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Diet Soda: {IsDiet}");
        Console.WriteLine();
    }
}
