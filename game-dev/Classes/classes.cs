// collaborated with michele, mya, and rayven for some debugging

namespace gamedev.classes;

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

    // Methods

}

public class Enemy
{
    // Fields
    public string Name { get; set; }
    public int Health { get; set; }
    public List<string> AttackList { get; set; }

    // Constructors 
    public Enemy(string name, List<string> attackList)

    {
        //match to constructor from fields
        Name = name;
        Health = 100;
        AttackList = attackList;
    }

    //Methods 
    public string RandomAttack()
    {
        //use random() to pick randomized attacks from the attack list
        Random rand = new();
        int randomIndex = rand.Next(AttackList.Count);
        return AttackList[randomIndex];
    }

    // ToString method to call enemy and info, had to override this per dev kit
    public override string ToString()
    {
        // use a join to call all info in the list, join enemy name and health
        string attackNames = string.Join(" : ", AttackList);
        return $"Enemy Name: {Name}\nEnemy HP: {Health}\nSignature Attacks: {attackNames}";
    }

    // this will print the attack list 
    public void PrintAttackList()
    {
        foreach (var attack in AttackList)
        {
            Console.WriteLine(attack);
        }
    }
}




