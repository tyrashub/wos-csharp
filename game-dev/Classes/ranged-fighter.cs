namespace game_dev.classes;

public class Ranged : Enemy
{
    public int Distance { get; set; }

    public Ranged(string name, int health, List<Attack> attackList) : base(name, 100, attackList)
    {
        Distance = 5;
    }

    public override void PerformAttack(Enemy target, Attack chosenAttack)
    {
        if (Distance < 10)
        {
            Console.WriteLine($"{Name} it too close... their distance is {Distance}");
            return;
        }
        base.PerformAttack(target, chosenAttack);
    }

    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"{Name} has dashed, {Name}'s distance is now {Distance} km!");
    }
}
