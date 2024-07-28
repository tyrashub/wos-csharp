
namespace DrinkMaker.Classes;

public class Coffee : Drink
{
    // New fields
    public string Roast { get; set; }
    public string BeanType { get; set; }

    // Constructor 
    public Coffee(string name, string color, double temp, string roast, string beanType, int calories)
        : base(name, color, temp, false, calories)
    {
        Roast = roast;
        BeanType = beanType;
    }

    // ShowDrink method, have to override this per dev kit
    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Roast: {Roast}");
        Console.WriteLine($"Bean Type: {BeanType}");
        Console.WriteLine();
    }

}