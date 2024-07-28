// 1. Iterate and print values
// Given a List of strings, iterate through the List and print out all the values. 
// Bonus: How many different ways can you find to print out the contents of a List? 
// (There are at least 3! Check Google!)

// list of strings
List<string> TestStringList = new List<string>() { "Harry", "Steve", "Carla", "Jeanne" };

// call the method so we can print the list
PrintList(TestStringList);

static void PrintList(List<string> MyList)
{
    // foreach loop
    foreach (string item in MyList)
    {
        Console.WriteLine(item);
    }

    // for loop
    for (int i = 0; i < MyList.Count; i++)
    {
        Console.WriteLine(MyList[i]);
    }
    //string join method
    Console.WriteLine(string.Join("\n", MyList));
}


// 2. Print Sum
// Given a List of integers, calculate and print the sum of the values.
static void SumOfNumbers(List<int> IntList)
{
    // calculates the sum with foreach loop
    int sum = 0;
    foreach (int number in IntList)
    {
        sum += number;
    }

    // print line
    Console.WriteLine(sum);
}

// initialize list
List<int> TestIntList = new List<int>() { 2, 7, 12, 9, 3 };

// You should get back 33 in this example
SumOfNumbers(TestIntList);


// 3. Find Max
// Given a List of integers, find and return the largest value in the List.
static int FindMax(List<int> IntList)
{
    // initialize max at first index
    int max = IntList[0];

    // use foreach loop to find the maximum value
    foreach (int number in IntList)
    {
        if (number > max)
        {
            max = number;
        }
    }

    // return statement
    return max;
}

// intialize list
List<int> TestIntList2 = new List<int>() { -9, 12, 10, 3, 17, 5 };
// You should get back 17 in this example
// call the testIntList2 into the function
int max = FindMax(TestIntList2);
// print the max
Console.WriteLine($"The max is {max}.");


// 4. Square the Values
// Given a List of integers, return the List with all the values squared.
static List<int> SquareValues(List<int> IntList)
{
    // squared values
    List<int> squaredList = new List<int>();

    // iterate through list and square each value
    foreach (int number in IntList)
    {
        // each number in the list will be multiplied by itself or 'squared'
        squaredList.Add(number * number);
    }

    // return statement
    return squaredList;
}
// new list
List<int> TestIntList3 = new List<int>() { 1, 2, 3, 4, 5 };
// You should get back [1,4,9,16,25], think about how you will show that this worked
// call the testIntList3 into the function
List<int> squaredList = SquareValues(TestIntList3);
// print all the items
Console.WriteLine(string.Join("\n", squaredList));

// 5. Replace Negative Numbers with 0
// Given an array of integers, return the array with all values below 0 replaced with 0.
static int[] NonNegatives(int[] IntArray)
{
    //for loop for as long as the array
    for (int i = 0; i < IntArray.Length; i++)
    {
        // logic statements
        if (IntArray[i] < 0)
        {
            // if it is less than 0, set index to 0
            IntArray[i] = 0;
        }
    }

    // return statement
    return IntArray;
}
// new int array
int[] TestIntArray = new int[] { -1, 2, 3, -4, 5 };
// You should get back [0,2,3,0,5], think about how you will show that this worked
int[] nonNegativeArray = NonNegatives(TestIntArray);
// print all the items 
Console.WriteLine(string.Join("\n", nonNegativeArray));

// 6. Print Dictionary
// Given a dictionary, print the contents of the said dictionary.
static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    // foreach loop
    foreach (var item in MyDictionary)
    {
        // this will pull each key value pair at that index and print
        Console.WriteLine($"{item.Key} - {item.Value}");
    }
}
// new dictionary
Dictionary<string, string> TestDict = new Dictionary<string, string>();
// 'push' values in 
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
// print statement
PrintDictionary(TestDict);


// 7. Find Key
// Given a search term, return true or false whether the given term is a key in a dictionary.
static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    return MyDictionary.ContainsKey(SearchTerm);
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));


// 8. Generate a Dictionary
// Given a List of names and a List of integers, create a dictionary where the key is a name 
// from the List of names and the value is a number from the List of numbers. Assume that the two
// Lists will be of the same length. Don't forget to print your results to make sure it worked.
// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    // new dictionary
    Dictionary<string, int> result = new Dictionary<string, int>();
    // for loop for as long as name count
    for (int i = 0; i < Names.Count; i++)
    {
        result.Add(Names[i], Numbers[i]);
    }

    // return statementt
    return result;
}
// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Your test code here
List<string> names = new List<string> { "Julie", "Harold", "James", "Monica" };
List<int> numbers = new List<int> { 6, 12, 7, 10 };
Dictionary<string, int> resultDict = GenerateDictionary(names, numbers);

// print results
foreach (var item in resultDict)
{
    // this will pull each key value pair at that index from both lists and print
    Console.WriteLine($"{item.Key} : {item.Value}");
}

