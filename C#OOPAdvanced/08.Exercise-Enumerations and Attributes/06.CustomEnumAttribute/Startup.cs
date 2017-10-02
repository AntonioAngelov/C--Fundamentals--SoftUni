using System;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        var type = Console.ReadLine();

        if (type == "Rank")
        {
            PrintAttribute(typeof(Rank));
        }
        else
        {
            PrintAttribute(typeof(Suit));
        }
        
    }

    public static void PrintAttribute(Type type)
    {
        var attributes = type.GetCustomAttributes(false);

        Console.WriteLine(attributes[0]);
    }
}
