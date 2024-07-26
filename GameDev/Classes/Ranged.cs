
namespace GameDev.Classes;

// ranged fighter subclass
public class Ranged : Enemy
{
    // new field
    public int Distance { get; set; }

    // constructor
    public Ranged(string name, int health, List<Attack> attackList) : base(name, health, attackList)
    {
        // set default distance at 5
        Distance = 5;
    }

    // performattack(); method with the enemy and their attack passed in 
    public override void PerformAttack(Enemy target, Attack chosenAttack)
    {
        // if distance is less than 10 then they cannot attack
        if (Distance < 10)
        {
            Console.WriteLine($"{Name} is too close... their distance is only {Distance}...");
            return;
        }
        // use base from parent method
        base.PerformAttack(target, chosenAttack);
    }
    // Dash(); method, nothing passed in
    public void Dash()
    {
        // once dash is performed, set distance to 20 and print msg
        Distance = 20;
        Console.WriteLine($"{Name} has dashed away, {Name}'s distance is now {Distance} km!");
    }

    public override string ToString()
    {
        // use a join to call all info in the list, join enemy name and health
        string attack = Enemy.DisplayAttacks(AttackList);
        return $"Enemy Name: {Name}\n\tEnemy HP: {Health}\n\t{attack}\n\tDistance: {Distance} km";
    }

}