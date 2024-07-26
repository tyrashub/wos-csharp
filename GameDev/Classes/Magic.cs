namespace GameDev.Classes;

// magic caster subclass
public class Magic : Enemy
{
    // Constructor
    public Magic(string name, int health, List<Attack> attackList) : base(name, health, attackList) { }

    // Heal(); method, pass in target for the method
    public void Heal(Enemy target)
    {
        // if their health is less than 0, don't heal target
        if (target.Health < 0)
        {
            Console.WriteLine($"{target.Name} is out of the fight! They cannot heal...");
            return;
        }
        // otherwise, heal them plus 40 HP
        target.Health += 40;
        Console.WriteLine($"{Name} works their magic and increases {target.Name} 40 HP! {target.Name}'s HP is {target.Health}...");
    }
}
