// Group work with Rayven, Karrington, and Elvyn

//  1.  
for (int i = 1; i <= 255; i++)
{
    Console.WriteLine(i);
}

//  2.
var rand = new Random();
for (int j = 0; j < 5; j++)
{
    int randomNum = rand.Next(10, 21);
    Console.WriteLine(randomNum);
}

//  3.
int sum = 0;
for (int k = 0; k < 5; k++)
{
    int randomNum = rand.Next(10, 21);
    sum += randomNum;
    Console.WriteLine(randomNum);
}
Console.WriteLine("Sum: " + sum);

// 4.
for (int l = 1; l <= 100; l++)
{
    if ((l % 3 == 0 || l % 5 == 0) && !(l % 3 == 0 && l % 5 == 0))
    {
        Console.WriteLine(l);
    }
}

//  5.
for (int m = 1; m <= 100; m++)
{
    if (m % 3 == 0 && m % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (m % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (m % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else if ((m % 3 == 0 || m % 5 == 0) && !(m % 3 == 0 && m % 5 == 0))
    {
        Console.WriteLine(m);
    }
}

//  6.
int i = 1;
while (i <= 100)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("Fizz");
    }
    else if (i % 5 == 0)
    {
        Console.WriteLine("Buzz");
    }
    else
    {
        Console.WriteLine(i);
    }
    i++;
}