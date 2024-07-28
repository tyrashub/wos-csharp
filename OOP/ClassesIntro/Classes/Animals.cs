namespace ClassesIntro.Classes;

//singular and PascalCase
public class Animal
{
    //field
    // private string _name;

    // // property 
    // public string Name
    // {
    //     get
    //     {
    //         return _name;
    //     }
    //     set
    //     {
    //         _name = value;
    //     }
    // }

    // auto implemented property
    public string Name { get; set; }
    public string Type { get; set; }
    public int Age { get; set; }

    // Notice how this is like a function taking in a parameter for name
    // constructor
    public Animal(string name, string type, int age)

    {
        // Notice the type here is "Animal". Classes create their very own data type! 

        Name = name;
        Type = type;
        Age = Age;
    }

    // overloaded constructor
    public Animal(string name, string type)

    {
        // Notice the type here is "Animal". Classes create their very own data type! 
        Name = name;
        Type = type;
        Age = 0;
    }

    public override string ToString()
    {
        return $"Name: {Name}, Type: {Type}, Age: {Age}";
    }
    public void Birthday()
    {
        Age++;
    }
}