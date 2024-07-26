namespace game_dev.classes;

public class Melee : Enemy
{
    // Fields
    public new string Name { get; set; }
    public new int Health { get; set; }
    public new List<Attack> AttackList { get; set; }


    // Constructors 
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
    public Melee(string name, int health, List<Attack> attackList)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
       : base(name, 120, attackList)

    {

    }

    // Rage method
    public void Rage(Enemy target)
    {
        Attack randomAttack = RandomAttack();
        if (randomAttack != null)
        {
            randomAttack.DamageAmount += 10;
            PerformAttack(target, randomAttack);
            randomAttack.DamageAmount -= 10;
        }
    }
}