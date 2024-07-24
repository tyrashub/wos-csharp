// Three Basic Arrays
// Create an integer array with the values 0 through 9 inside.
// Create a string array with the names "Tim", "Martin", "Nikki", and "Sara".
// Create a boolean array of length 10. Then fill it with alternating true/false values,
//  starting with true. (Tip: do this using logic! Do not hard-code the values in!)

//{had to comment these lines to run the rest of the code)
// int array
// int[] numArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

// string array
// string[] stringArray = new string[] { "Tim", "Martin", "Nikki", "Sara" };

// boolean array

// bool[] boolArray = new bool[10];
// create a for loop that holds 10 indexes and runs for as long as the length
// for (int i = 0; i < boolArray.length; i++)
// {
// at the index check if it is divisible by 2 and print true if so, else false
//     boolArray[i] = (i % 2 == 0);
// }
// foreach (bool value in boolArray)
// {
//     Console.WriteLine();
// }


// List of Flavors
// Create a string List of ice cream flavors that holds at least 5 different flavors. (Feel free to add more than 5!)
// Output the length of the List after you added the flavors.
// Output the third flavor in the List.
// Now remove the third flavor using its index location.
// Output the length of the List again. It should now be one fewer.
// User Dictionary

// Initializing an empty list of ice cream flavors
List<string> iceCreamFlavors = new List<string>();
// create list and add each flavor
iceCreamFlavors.Add("Vanilla");
iceCreamFlavors.Add("Chocolate");
iceCreamFlavors.Add("Strawberry");
iceCreamFlavors.Add("Sherbert");
iceCreamFlavors.Add("Coffee Toffee");
iceCreamFlavors.Add("Rocky Road");

//print amount of flavors
Console.WriteLine($"We have {iceCreamFlavors.Count} ice cream flavors. Which one would you like?");
Console.WriteLine($"The third flavor is {iceCreamFlavors[2]}.");

//remove third flavor at index
iceCreamFlavors.RemoveAt(2);

//output after we remove third flavor
Console.WriteLine($"We have sold out of one flavor! We now have only {iceCreamFlavors.Count} ice cream flavors.");


// User Dictionary
// Create a dictionary that will store string keys and string values.
// Add key/value pairs to the dictionary where:
// Each key is a name from your names array (this can be done by hand or using logic)
// Each value is a randomly selected flavor from your flavors List (remember Random from earlier?)
// Loop through the dictionary and print out each user's name and their associated ice cream flavor.
List<string> iceCreamFlavors2 = new List<string>();
// create list and add each flavor
iceCreamFlavors2.Add("Cookie Dough");
iceCreamFlavors2.Add("Mint");
iceCreamFlavors2.Add("Butter Pecan");
iceCreamFlavors2.Add("Sherbert");

//create string and add names
string[] names = new string[] { "Tim", "Martin", "Nikki", "Sara" };

// \create dictionary
Dictionary<string, string> userPreferences = new Dictionary<string, string>();

// generate random 
Random rand = new Random();
for (int i = 0; i < names.Length; i++)
{
    int randomIndex = rand.Next(iceCreamFlavors2.Count);
    userPreferences[names[i]] = iceCreamFlavors2[randomIndex];
}

// create foreach statement to loop through
foreach (string name in names)
{
    // print name and flavor random choice
    Console.WriteLine($"{name}'s favorite flavor is {userPreferences[name]}.");
}