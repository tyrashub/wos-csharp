using GameDev.Classes;


// creeate some preliminary attacks
var attack1 = new Attack("Accio", 10);
var attack2 = new Attack("Confrigo", 15);
var attack3 = new Attack("Levioso", 5);
var attack4 = new Attack("Expelliarmus", 25);

// print the attacks and their damage 5 to 25
Console.WriteLine($"Attack: {attack1.Name}, Damage: {attack1.DamageAmount}");
Console.WriteLine($"Attack: {attack2.Name}, Damage: {attack2.DamageAmount}");
Console.WriteLine($"Attack: {attack3.Name}, Damage: {attack3.DamageAmount}");
Console.WriteLine($"Attack: {attack4.Name}, Damage: {attack4.DamageAmount}");

// create enemy and add signature attacks
var voldermortAttackList = new List<Attack> { attack1, attack2, attack3, attack4 };
var enemy1 = new Enemy("Voldemort", 100, voldermortAttackList);


// print enemy info
Console.WriteLine(enemy1.ToString());

// testing the randomizeattack(); method
for (int i = 0; i < 5; i++)
{
    var attack = enemy1.RandomAttack();
    Console.WriteLine($"Randomized attack: {attack.Name}");
}

// new attacks added to new enemyAttackList
var punch = new Attack("Punch", 20);
var kick = new Attack("Kick", 15);
var tackle = new Attack("Tackle", 25);
var shootArrow = new Attack("Shoot an Arrow", 20);
var throwKnife = new Attack("Throw a Knife", 15);
var fireball = new Attack("Fireball", 25);
var lightningBolt = new Attack("Lightning Bolt", 20);
var staffStrike = new Attack("Staff Strike", 10);

// 1. Create instances of the Melee, Ranged, and Magic Caster classes
// create some random enemies and add in properties from class
var melee = new Melee("Fearless Warrior", 120, new List<Attack> { punch, kick, tackle });
var ranged = new Ranged("Speed Demon", 100, new List<Attack> { shootArrow, throwKnife });
var magic = new Magic("Hogwarts Wizard", 80, new List<Attack> { fireball, lightningBolt, staffStrike });

var enemyAttackList = new List<Attack> { punch, kick, tackle, shootArrow, throwKnife, fireball, lightningBolt, staffStrike };

Console.WriteLine(Enemy.DisplayAttacks(enemyAttackList));

Console.WriteLine(melee.ToString());
Console.WriteLine(ranged.ToString());
Console.WriteLine(magic.ToString());


// testing performAttack();, rage();, dash();, and heal(); methods

// melee fighter attacks on ranged and magic fighter
melee.PerformAttack(ranged, punch);
melee.PerformAttack(magic, tackle);

// 2. Perform the Kick Attack from your Melee class character on your Ranged character
melee.PerformAttack(ranged, kick);

// 3. Perform the Rage method from your Melee class character on your Magic Caster character
// call rage method in melee class
melee.Rage(magic);

// 4. Perform the Shoot an Arrow Attack from your Ranged character on your Melee character 
// ranged fighter attacks on melee and magic fighter
ranged.PerformAttack(melee, shootArrow);
ranged.PerformAttack(magic, throwKnife);

// 5. Have your Ranged character perform the Dash method
// calll dash method in ranged class
ranged.Dash();

// 6. Perform another Shoot an Arrow Attack from your Ranged character (this one should have worked now if everything is set up properly)
ranged.PerformAttack(melee, shootArrow);

// 7. Perform a Fireball Attack from your Magic Caster on your Melee character
// magic healer atacks/heals on ranged and melee fighter
magic.PerformAttack(melee, fireball);
magic.PerformAttack(melee, staffStrike);
magic.PerformAttack(ranged, lightningBolt);

//  8. Have the Magic Caster perform the Heal method on the Ranged character
// call heal method in magic class
magic.Heal(ranged);

// 9. Have the Magic Caster perform the Heal method on themselves
magic.Heal(magic);