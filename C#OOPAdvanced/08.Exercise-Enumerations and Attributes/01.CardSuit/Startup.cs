using System;

public class Startup
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var suits = Enum.GetValues(typeof(Suit));

        Console.WriteLine($"{input}:");

        foreach (var suit in suits)
        {
            Console.WriteLine($"Ordinal value: {(int)suit}; Name value: {suit}");
        }
    }
}

