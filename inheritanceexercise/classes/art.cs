namespace InheritanceExercises.Classes;

// Base class
public class Art
{
    // Properties common to all types of artwork
    public string Title { get; set; }
    public string Artist { get; set; }
    public int Year { get; set; }

    // Constructor
    public Art(string title, string artist, int year)
    {
        Title = title;
        Artist = artist;
        Year = year;
    }

    // Virtual method to display details, meant to be overridden
    public virtual void DisplayDetails()
    {
        Console.WriteLine($"Title: {Title}, Artist: {Artist}, Year: {Year}");
    }
}

// Subclass representing a Painting
public class Painting : Art
{
    // Additional property unique to Painting
    public string Medium { get; set; }

    // Constructor calling the base class constructor
    public Painting(string title, string artist, int year, string medium)
        : base(title, artist, year)
    {
        Medium = medium;
    }

    // Overriding the DisplayDetails method
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Medium: {Medium}");
    }
}

// Subclass representing a Sculpture
public class Sculpture : Art
{
    // Additional property unique to Sculpture
    public string Material { get; set; }

    // Constructor calling the base class constructor
    public Sculpture(string title, string artist, int year, string material)
        : base(title, artist, year)
    {
        Material = material;
    }

    // Overriding the DisplayDetails method
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Material: {Material}");
    }
}

// Subclass representing Digital Art
public class DigitalArt : Art
{
    // Additional property unique to DigitalArt
    public string SoftwareUsed { get; set; }

    // Constructor calling the base class constructor
    public DigitalArt(string title, string artist, int year, string softwareUsed)
        : base(title, artist, year)
    {
        SoftwareUsed = softwareUsed;
    }

    // Overriding the DisplayDetails method
    public override void DisplayDetails()
    {
        base.DisplayDetails();
        Console.WriteLine($"Software Used: {SoftwareUsed}");
    }
}