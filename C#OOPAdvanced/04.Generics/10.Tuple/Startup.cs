using System;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var personInfo1 = Console.ReadLine()
            .Split(' ')
            .ToList();
        Tuple<string, string> tuple1 = new Tuple<string, string>(personInfo1[0] + " " + personInfo1[1], personInfo1[2]);

        var personInfo2 = Console.ReadLine()
            .Split(' ')
            .ToList();
        Tuple<string, int> tuple2 = new Tuple<string, int>(personInfo2[0], int.Parse(personInfo2[1]));

        var numbers = Console.ReadLine()
            .Split(' ')
            .ToList();
        Tuple<int, double> tuple3 = new Tuple<int, double>(int.Parse(numbers[0]), double.Parse(numbers[1]));

        Console.WriteLine(tuple1.ToString());
        Console.WriteLine(tuple2.ToString());
        Console.WriteLine(tuple3.ToString());
    }
}

