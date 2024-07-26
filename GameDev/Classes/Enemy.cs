namespace GameDev.Classes;
public class Enemy
{
    // Fields
    public string? Name { get; set; }
    public int Health { get; set; }
    public List<Attack> AttackList { get; set; }

    // Constructors 
    public Enemy(string name, int health, List<Attack> attackList)

    {
        //match to constructor from fields
        Name = name;
        Health = health;
        AttackList = attackList;
    }

    // randomattack(); Method
    public Attack RandomAttack()
    {
        //use random() to pick randomized attacks from the attack list
        Random rand = new();
        var randomIndex = rand.Next(AttackList.Count);
        return AttackList[randomIndex];
    }


    // ToString method to call enemy and info, had to override this per dev kit
    public override string ToString()
    {
        // use a join to call all info in the list, join enemy name and health
        string attack = Enemy.DisplayAttacks(AttackList);
        return $"Enemy Name: {Name}\n\tEnemy HP: {Health}\n\t{attack}";
    }


    // static methods calls on the class itself
    public static string DisplayAttacks(List<Attack> attacks)
    {
        string attack = string.Join(", ", attacks.Select(a => a.Name));
        return $"Attacks: [{attack}]";
    }

    // this will print the attack list 
    public void PrintAttackList()
    {
        foreach (var attack in AttackList)
        {
            Console.WriteLine(attack.Name);
        }
    }

    // performattack(); method, game-dev 2 assignment
    // inside of the Enemy class
    public virtual void PerformAttack(Enemy Target, Attack chosenAttack)
    {
        // Write some logic here to reduce the Targets health by your Attack's DamageAmount
        Target.Health -= chosenAttack.DamageAmount;
        Console.WriteLine($"{Name} has attacked {Target.Name}, yielding {chosenAttack.DamageAmount} damage! {Target.Name}'s HP becomes {Target.Health}...");
    }


}