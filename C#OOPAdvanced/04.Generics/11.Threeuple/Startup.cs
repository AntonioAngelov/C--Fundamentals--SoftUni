using System;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var personInfo1 = Console.ReadLine()
            .Split(' ')
            .ToList();
        Threeuple<string, string, string> tuple1 = new Threeuple<string, string, string>(personInfo1[0] + " " + personInfo1[1], personInfo1[2], personInfo1[3]);

        var personInfo2 = Console.ReadLine()
            .Split(' ')
            .ToList();
        Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(personInfo2[0], int.Parse(personInfo2[1]), personInfo2[2] == "drunk");

        var bankInfo = Console.ReadLine()
            .Split(' ')
            .ToList();
        Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(bankInfo[0], double.Parse(bankInfo[1]), bankInfo[2]);

        Console.WriteLine(tuple1.ToString());
        Console.WriteLine(tuple2.ToString());
        Console.WriteLine(tuple3.ToString());
    }
}
