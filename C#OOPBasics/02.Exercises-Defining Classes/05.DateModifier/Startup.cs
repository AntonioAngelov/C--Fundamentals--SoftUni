using System;

public class Startup
{
    static void Main(string[] args)
    {
        DateModifier modifier = new DateModifier();
        string d1 = Console.ReadLine();
        string d2 = Console.ReadLine();

        modifier.GetDifference(d1, d2);

    }
}

