using System;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine()
            .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
            .ToList();

        var gandalf = new Gandalf();

        for (int i = 0; i < input.Count; i++)
        {
            gandalf.Eat(input[i]);
        }

        Console.WriteLine(gandalf);

    }
}

