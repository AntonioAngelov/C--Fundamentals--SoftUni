using System;

public class Startup
{
    public static void Main(string[] args)
    {
        Scale<int> scale = new Scale<int>(1 ,2);
        Console.WriteLine(scale.GetHavier());
    }
}

