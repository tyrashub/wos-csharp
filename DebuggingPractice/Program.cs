// Challenge 1
bool amProgrammer = true;
int Age = 27;
List<string> Names = new() { "Monica" };
Dictionary<string, string> MyDictionary = new()
{
    { "Hello", "0" },
    { "Hi there", "0" }
};
// This is a tricky one! Hint: look up what a char is in C#
string MyName = "MyName";
Console.WriteLine(amProgrammer);
Console.WriteLine(Age);
Console.WriteLine(MyName);

// Challenge 2
List<int> Numbers = new() { 2, 3, 6, 7, 1, 5 };
for (int i = Numbers.Count - 1; i >= 0; i--)
{
    Console.WriteLine(Numbers[i]);
}


// Challenge 3
List<int> MoreNumbers = new() { 12, 7, 10, -3, 9 };
foreach (int num in MoreNumbers)
{
    Console.WriteLine(num);
}


// Challenge 4
List<int> EvenMoreNumbers = new() { 3, 6, 9, 12, 14 };
foreach (int num in EvenMoreNumbers)
{
    Console.WriteLine(num);
}


// Challenge 5
// What can we learn from this error message?
string MyString = "superduberawesome";
char[] MyStringArray = MyString.ToCharArray();
MyStringArray[7] = 'p';
Console.WriteLine(MyString);


// Challenge 6
// Hint: some bugs don't come with error messages
Random rand = new();
int randomNum = rand.Next(13);
if (randomNum != 12)
{
    Console.WriteLine("Hello");
}

