using InterfacesAndAbstractClassesExercise.Classes;
using InterfacesAndAbstractClassesExercise.Interfaces;

var samsung = new Smartphone("Galaxy", "A15");
var apple = new Smartphone("iPhone", "15");
var lenovo = new Smartphone("Legion", "Y90");

var lg = new Television("LG", "C4");
var roku = new Television("Roku TV", "55R4A4");
var sony = new Television("Bravia", "xs200");


var asus = new Laptop("ROG Strix", "G16");
var hp = new Laptop("OMEN", "2300");
var dell = new Laptop("XPS", "GS00");



var rechargeable = new List<IRechargeable> { asus, hp, dell, samsung, apple, lenovo };

foreach (var item in rechargeable)
{
    item.Recharge();
    Console.WriteLine(item.Recharge());
}

var devices = new List<ElectronicDevice>() { asus, hp, dell, samsung, apple, lenovo, lg, roku, sony };

