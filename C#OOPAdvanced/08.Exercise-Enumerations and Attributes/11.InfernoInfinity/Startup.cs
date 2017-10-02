using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        //exercise 11
        //InvernoInfinity();

        //exercise 10
        UseCustomAttribute();
    }

    private static void UseCustomAttribute()
    {
        var command = Console.ReadLine();
        var attrs = typeof(Weapon).GetCustomAttributes(false);

        var info = attrs[0] as InfoAttribute;

        while (command != "END")
        {
            switch (command)
            {
                case "Author":
                    Console.WriteLine($"{command}: {info.Author}");
                    break;
                case "Revision":
                    Console.WriteLine($"{command}: {info.Revision}");
                    break;
                case "Description":
                    Console.WriteLine($"Class description: {info.Description}");
                    break;
                case "Reviewers":
                    Console.WriteLine($"{command}: {string.Join(", ", info.Reviewers)}");
                    break;
            }

            command = Console.ReadLine();
        }
    }

    private static void InvernoInfinity()
    {
        Dictionary<string, Weapon> weapons = new Dictionary<string, Weapon>();

        var input = Console.ReadLine();

        while (input != "END")
        {
            var splitted = input
                .Split(';')
                .ToList();

            switch (splitted[0])
            {
                case "Create":
                    var type = splitted[1]
                        .Split(' ')
                        .ToList();

                    weapons.Add(splitted[2], new Weapon(type[1], type[0], splitted[2]));
                    break;
                case "Add":
                    var gemType = splitted[3]
                        .Split(' ')
                        .ToList();

                    Gem gem = new Gem(gemType[1], gemType[0]);
                    weapons[splitted[1]].AddGem(gem, int.Parse(splitted[2]));
                    break;
                case "Remove":
                    weapons[splitted[1]].RemoveGem(int.Parse(splitted[2]));
                    break;
                case "Print":
                    Console.WriteLine(weapons[splitted[1]].GetFullInformation());
                    break;

            }

            input = Console.ReadLine();
        }
    }
}

