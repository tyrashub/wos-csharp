using gamedev.classes;


// creeate some attacks
var attack1 = new Attack("Accio", 10);
var attack2 = new Attack("Confrigo", 15);
var attack3 = new Attack("Levioso", 5);
var attack4 = new Attack("Expelliarmus", 25);

// print the attacks and their damage 5 to 25
Console.WriteLine($"Attack: {attack1.Name}, Damage: {attack1.DamageAmount}");
Console.WriteLine($"Attack: {attack2.Name}, Damage: {attack2.DamageAmount}");
Console.WriteLine($"Attack: {attack3.Name}, Damage: {attack3.DamageAmount}");
Console.WriteLine($"Attack: {attack4.Name}, Damage: {attack4.DamageAmount}");

// create Enemy and add signature attacks
var enemy1AttackList = new List<string> { "Accio", "Expelliarmus", "Confrigo", "Levioso" };
var enemy1 = new Enemy("Voldemort", enemy1AttackList);

// enemy info
Console.WriteLine(enemy1.ToString());

// testing the randomize attack method
for (int i = 0; i < 5; i++)
{
    var attack = enemy1.RandomAttack();
    Console.WriteLine($"Randomized attack: {attack}");
}
