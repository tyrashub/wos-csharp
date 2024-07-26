namespace GameDev.Classes;

public class Melee : Enemy
{
    // Fields
    public new string? Name { get; set; }
    public new int Health { get; set; }
    public new List<Attack>? AttackList { get; set; }


    // Constructors 
    public Melee(string name, int health, List<Attack> attackList)
       : base(name, health, attackList)

    {

    }

    // Rage(); method
    public void Rage(Enemy target)
    {
        // call randomattack(); method
        Attack randomAttack = RandomAttack();
        if (randomAttack != null)
        {
            // perform random attack and set damage amounts 
            randomAttack.DamageAmount += 10;
            PerformAttack(target, randomAttack);
            randomAttack.DamageAmount -= 10;
        }
    }
}