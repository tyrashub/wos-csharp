
// MENU 

while (true)
{
    Console.WriteLine("Choose an option below:");
    Console.WriteLine("1. Flip a Coin");
    Console.WriteLine("2. Roll a Die");
    Console.WriteLine("3. Stat Roll (4 rolls of a die)");
    Console.WriteLine("4. Roll Until a Chosen Number");
    Console.WriteLine("5. Quit");

    // USER INPUT
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
    string choice = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

    // HANDLE USER INPUT HERE
    switch (choice)
    {
        case "1":
            Console.WriteLine(CoinFlip());
            break;
        case "2":
            Console.Write("Enter the number of sides: ");
            int sides;
            if (int.TryParse(Console.ReadLine(), out sides))
            {
                Console.WriteLine($"Rolled: {RollDie(sides)}");
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
            break;
        case "3":
            Console.WriteLine("Enter the number of sides: ");
            int statSides;
            if (int.TryParse(Console.ReadLine(), out statSides))
            {
                List<int> rolls = StatRoll(statSides, 4);
                Console.WriteLine("Rolls: " + string.Join(", ", rolls));
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
            break;
        case "4":
            Console.Write("Roll until: ");
            int target;
            if (int.TryParse(Console.ReadLine(), out target))
            {
                Console.WriteLine(RollUntil(target));
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
            break;
        case "5":
            return;
        default:
            Console.WriteLine("Please try again.");
            break;
    }
}


// FUNCTIONS

// Coin Flip Function
static string CoinFlip()
{
    Random rand = new();
    int flip = rand.Next(2);
    return flip == 0 ? "Heads" : "Tails";
}

// Dice Roll Function
static int RollDie(int sides)
{
    Random rand = new();
    return rand.Next(1, sides + 1);
}

// Stat Roll Function
static List<int> StatRoll(int sides, int rolls)
{
    List<int> results = new List<int>();
    for (int i = 0; i < rolls; i++)
    {
        results.Add(RollDie(sides));
    }
    return results;
}
// Roll Until Function
static string RollUntil(int target)
{
    if (target < 1 || target > 6)
    {
        return "Invalid. Number should be between 1 and 6.";
    }

    Random rand = new();
    int count = 0;
    int roll;
    do
    {
        roll = rand.Next(1, 7);
        count++;
    } while (roll != target);

    return $"Rolled a {target} after {count} tries";
}
