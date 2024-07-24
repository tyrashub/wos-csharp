using ClassesIntro.Classes;

//call get method
var ani = new Animal("Huey", "Dog");

//call set method 
// ani.Name = "Riley";

ani.Birthday();
Console.WriteLine(ani);

var abby = new Animal("Abby", "Catahoula-Pit-Mix", 4);
Console.WriteLine(abby);
// Console.WriteLine($"{ani.Name} {ani.Type} Age: {ani.Age}");

var animalList = new List<Animal>() { ani, abby };
