// CONDITIONALS

// Declare a variable called temperature that holds an integer
// Note: temperature reading is assumed to be in fahrenheit
int temperature = 75;
if (temperature >= 72)
{
    Console.WriteLine("It's a beautiful day to go outside!");
}
else
{
    Console.WriteLine("Maybe I'll stay inside today.");
}

int temperature1 = 68;
if (temperature1 >= 72)
{
    // This executes if the temperature is greater than or equal to 72
    Console.WriteLine("It's a beautiful day to go outside!");
}
else if (temperature > 64)
{
    // This executes only if the temperature was NOT greater than or equal to 72 and IS above 64
    Console.WriteLine("I think it should be fine to go outside today with a light jacket.");
}
else
{
    // If neither of the above conditions are met, we run the else statement
    Console.WriteLine("Maybe I'll stay inside today.");
}

int temperature2 = 62;
string weather = "Cloudy";
// If the temperature is greater than or equal to 72 OR the weather is sunny, we run the first condition
if (temperature2 >= 72 || weather == "Sunny")
{
    Console.WriteLine("It's a beautiful day to go outside!");
    // Otherwise, if the temperature is greater than 64 AND it is not raining out, we run the second condition
}
else if (temperature2 > 64 && weather != "Rainy")
{
    Console.WriteLine("I think it should be fine to go outside today with a jacket.");
}
else
{
    Console.WriteLine("Maybe I'll stay inside today.");
}

//  LOOPS

// for loop
int start = 0;
int end = 10;
// loop from start to end including end
for (int i = start; i <= end; i++)
{
    // Console.WriteLine(i);
}
// loop from start to end excluding end
for (int i = start; i < end; i++)
{
    // Console.WriteLine(i);
}

// while loop
int j = 1;
while (j <= 10)
{
    Console.WriteLine(j);
    j++;
}

// do while loop
int k = 11;
do
{
    Console.WriteLine(k);
    k++;
}
while (k <= 10);

//  RANDOM NUMBERS
var rand = new Random();

string name = "Andy";

for (int i = 0; i <= rand.Next(11); i++)
{
    // exclusive upper bound
    // Console.WriteLine(rand.Next(10));
}

for (int i = 0; i <= 100; i++)
{
    // exclusive upper bound
    // Console.WriteLine(rand.Next(10));
    Console.WriteLine(rand.NextDouble());
}

for (int i = 1; i < 16; i++)
{
    var result = rand.Next(1, 11);
    if (result == 1 || result == 7)
    {
        Console.WriteLine(result);
    }
}