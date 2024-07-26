using InheritanceExercises.Classes;


// Testing the classes
class Program
{
    static void Main(string[] args)
    {
        // Creating instances of each subclass
        Painting painting = new Painting("Starry Night", "Vincent van Gogh", 1889, "Oil on canvas");
        Sculpture sculpture = new Sculpture("The Thinker", "Auguste Rodin", 1902, "Bronze");
        DigitalArt digitalArt = new DigitalArt("Digital Sunrise", "Alice Smith", 2022, "Photoshop");

        // Storing the art pieces in a list of Art objects
        List<Art> artGallery = new List<Art> { painting, sculpture, digitalArt };

        // Displaying details of each artwork
        foreach (var art in artGallery)
        {
            art.DisplayDetails();
            Console.WriteLine(); // For better readability
        }
    }
}