using RiderMaker.Classes;
using RiderMaker.Interfaces;

// some vehicles
Car honda = new Car("Honda CR-V", 4, "Red", true, 125, "Unleaded Gasoline");
Car toyota = new Car("Toyota Camry", 2, "Silver", true, 150, "Premium Gasoline");
Car benz = new Car("Mercedes Benz", 1, "White", true, 150, "Premium Gasoline");
Bike canyon = new Bike("Canyon Torque", 1, "Black and Green", false, 60);
Horse stallion = new Horse("Male Stallion", 1, "Black", false, 25, "Grains");
// Skates Impala = new("Impala Lightspeed", 1, "White and Tan", false);

// initialize vehicle list
List<Vehicle> vehicles = new() { honda, toyota, benz, canyon, stallion };
List<INeedFuel> NeedsFuel = new List<INeedFuel>();

// foreach loop for vehicles
foreach (Vehicle v in vehicles)
{
    if (v is INeedFuel)
    {
        NeedsFuel.Add((INeedFuel)v);
    }
}

foreach (INeedFuel item in NeedsFuel)
{
    item.GiveFuel(10);
}

// travel 100 miles
honda.Travel(100);
toyota.Travel(46);
benz.Travel(4);
benz.Travel(13);
canyon.Travel(3);
stallion.Travel(15);
// skates.Travel(10);

// updated vehicle info 
honda.ShowInfo();
toyota.ShowInfo();
benz.ShowInfo();
canyon.ShowInfo();
// skates.ShowInfo();

// bonus ?
honda.DistanceTraveled = 350;
canyon.DistanceTraveled = 35;
// skates.DistanceTraveled = 5;

// updated vehicle info
honda.ShowInfo();
// skates.ShowInfo();
canyon.ShowInfo();