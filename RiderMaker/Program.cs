using RiderMaker.Classes;

// some vehicles
Vehicle car = new("Honda CR-V", 4, "Red", true);
Vehicle car2 = new("Toyota Camry", 2, "Silver", true);
Vehicle car3 = new("Mercedes Benz", 1, "White", true);
Vehicle bike = new("Canyon Torque", 1, "Black and Green", false);
Vehicle skates = new("Impala Lightspeed", 1, "White and Tan", false);

// initialize vehicle list
List<Vehicle> vehicles = new() { car, car2, car3, bike, skates };

// foreach loop for vehicles
foreach (Vehicle item in vehicles)
{
    item.ShowInfo();
}

// travel 100 miles
car.Travel(100);
car2.Travel(46);
car2.Travel(4);
car3.Travel(13);
bike.Travel(3);
skates.Travel(10);

// updated vehicle info 
car.ShowInfo();
car2.ShowInfo();
car3.ShowInfo();
bike.ShowInfo();
skates.ShowInfo();

// bonus ?
car.DistanceTraveled = 350;
bike.DistanceTraveled = 35;
skates.DistanceTraveled = 5;

// updated vehicle info
car.ShowInfo();
skates.ShowInfo();
bike.ShowInfo();