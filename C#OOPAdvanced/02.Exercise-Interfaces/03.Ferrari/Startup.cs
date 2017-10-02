using System;

public class Startup
{
    public static void Main(string[] args)
    {
        var driver = Console.ReadLine();
        ICar ferrari = new Ferrari(driver);
        Console.WriteLine(ferrari.ToString());
    }
}

