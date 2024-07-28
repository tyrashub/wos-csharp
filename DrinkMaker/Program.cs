using DrinkMaker.Classes;


// some drinks
Drink soda = new Soda("Dr. Pepper", "Brown", 40, false, 120);
Drink soda2 = new Soda("Sprite Zero", "Clear", 45, true, 80);
Drink coffee = new Coffee("Gëvalia", "Dark Brown", 195, "Dark", "French Roast", 1);
Drink coffee2 = new Coffee("Folgers", "Black", 205, "Medium", "Classic Roast", 4);
Drink wine = new Wine("Cabernet Sauvignon", "Red", 55, "Bordeaux", 1934, 65);
Drink wine2 = new Wine("Teulon Rosé", "Pink", 40, "Europe", 2013, 100);

// add these drinks to a new list
List<Drink> allDrinks = new() { soda, soda2, coffee, coffee2, wine, wine2 };

// foreach loop for ShowDrink() method
foreach (Drink values in allDrinks)
{
    values.ShowDrink();
}

// bonus ? 
// Cannot implicitly convert type 'DrinkMaker.Classes.Soda' to 'DrinkMaker.Classes.Coffee' Error CS0029
// Coffee myDrink = new Soda("Pepsi", "Dark", 4.0, false);

