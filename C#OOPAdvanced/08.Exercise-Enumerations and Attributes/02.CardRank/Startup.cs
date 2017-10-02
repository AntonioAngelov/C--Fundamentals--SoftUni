using System;

public class Startup
{
    public static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var ranks = Enum.GetValues(typeof(Rank));

        Console.WriteLine($"{input}:");

        foreach (var rank in ranks)
        {
            Console.WriteLine($"Ordinal value: {(int)rank}; Name value: {rank}");
        }
    }
}
