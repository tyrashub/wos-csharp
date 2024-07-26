namespace GameDev.Classes;
public class Attack
{
    // Fields
    public string Name { get; set; }
    public int DamageAmount { get; set; }

    // Constructors
    public Attack(string name, int damageAmount)
    {
        //match to constructor from fields
        Name = name;
        DamageAmount = damageAmount;
    }
}
