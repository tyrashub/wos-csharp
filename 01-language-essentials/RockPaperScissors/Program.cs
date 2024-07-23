using System;

class Program
{
    static void Main()
    {
        // Welcome Message
        Console.WriteLine("Welcome to Rock, Paper, Scissors game!");
        string playerName;

        // User Input: Prompt the user for their name and ensure it is at least three characters long.
        do
        {
            Console.Write("Please enter your name (at least 3 characters): ");
            playerName = Console.ReadLine().Trim();
        } while (playerName.Length < 3);

        Console.WriteLine($"\nHello, {playerName}!");

        // Game Instructions
        Console.WriteLine("\nRandomly choose one of three hand signs: ROCK, PAPER, or SCISSORS.");
        Console.WriteLine("1. Rock wins against scissors.");
        Console.WriteLine("2. Scissors win against paper.");
        Console.WriteLine("3. Paper wins against rock.");
        Console.WriteLine("If both players show the same sign, it's a tie.");

        Console.ReadLine();
    }
}
