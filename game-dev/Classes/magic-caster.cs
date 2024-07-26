namespace game_dev.classes;

public class Magic : Enemy
{
    public Magic(string name, List<Attack> attackList) : base(name, 80, attackList) { }

    public void Heal(Enemy target)
    {
        if (target.Health <= 0)
        {
            Console.WriteLine($"{target.Name} cannot be healed because they are already defeated!");
            return;
        }
        target.Health += 40;
        Console.WriteLine($"{Name} heals {target.Name}, restoring 40 health. {target.Name}'s health is now {target.Health}.");
    }
}

