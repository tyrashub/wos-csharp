// collaborated with michele, mya, keihma and rayven for some debugging

namespace game_dev.classes;

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

public class Enemy
{
    // Fields
    public string Name { get; set; }
    public int Health { get; set; }
    public List<Attack> AttackList { get; set; }

    // Constructors 
    public Enemy(string name, int health, List<Attack> attackList)

    {
        //match to constructor from fields
        Name = name;
        Health = 100;
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
        string attack = string.Join(" : ", AttackList.Select(a => a.Name));
        return $"Enemy Name: {Name} Enemy HP: {Health} Signature Attacks: {attack}";
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

    // melee fighter subclass
    public class Melee : Enemy
    {
        // Fields
        public new string Name { get; set; }
        public new int Health { get; set; }
        public new List<Attack> AttackList { get; set; }


        // Constructors 
        public Melee(string name, int health, List<Attack> attackList)
           : base(name, 120, attackList)

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

    // ranged fighter subclass
    public class Ranged : Enemy
    {
        // new field
        public int Distance { get; set; }

        // constructor
        public Ranged(string name, int health, List<Attack> attackList) : base(name, 100, attackList)
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
    }

    // magic caster subclass
    public class Magic : Enemy
    {
        // Constructor
        public Magic(string name, int health, List<Attack> attackList) : base(name, 80, attackList) { }

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
}

// <<<< DEV KIT SUGGESTED CODE >>>>>


// internal class Melee
// {
//     private string v1;
//     private int v2;
//     private List<Attack> attacks;

//     public Melee(string v1, int v2, List<Attack> attacks)
//     {
//         this.v1 = v1;
//         this.v2 = v2;
//         this.attacks = attacks;
//     }

//     internal void PerformAttack(Ranged ranged, Attack punch)
//     {
//         throw new NotImplementedException();
//     }

//     internal void Rage(Magic magic)
//     {
//         throw new NotImplementedException();
//     }
// }

// internal class Ranged
// {
//     private string v1;
//     private int v2;
//     private List<Attack> attacks;

//     public Ranged(string v1, int v2, List<Attack> attacks)
//     {
//         this.v1 = v1;
//         this.v2 = v2;
//         this.attacks = attacks;
//     }

//     internal void Dash()
//     {
//         throw new NotImplementedException();
//     }

//     internal void PerformAttack(Melee melee, Attack shootArrow)
//     {
//         throw new NotImplementedException();
//     }
// }

// internal class Magic
// {
//     private string v1;
//     private int v2;
//     private List<Attack> attacks;

//     public Magic(string v1, int v2, List<Attack> attacks)
//     {
//         this.v1 = v1;
//         this.v2 = v2;
//         this.attacks = attacks;
//     }

//     internal void Heal(Ranged ranged)
//     {
//         throw new NotImplementedException();
//     }

//     internal void Heal(Magic magic)
//     {
//         throw new NotImplementedException();
//     }

//     internal void PerformAttack(Melee melee, Attack fireball)
//     {
//         throw new NotImplementedException();
//     }





