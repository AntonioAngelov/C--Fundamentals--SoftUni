using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        var numbers = Console.ReadLine()
            .Split(' ');

        var urls = Console.ReadLine()
            .Split(' ');

        Smartphone phone = new Smartphone();

        foreach (var number in numbers)
        {
            Console.WriteLine(phone.Call(number));
        }

        foreach (var url in urls)
        {
            Console.WriteLine(phone.Browse(url));
        }
    }
}
