using System;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        var stones = Console.ReadLine()
            .Split(new string[] {" ", ","}, StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToList();

        Lake lake = new Lake(stones);
        Console.WriteLine(String.Join(", ", lake));
    }
}

