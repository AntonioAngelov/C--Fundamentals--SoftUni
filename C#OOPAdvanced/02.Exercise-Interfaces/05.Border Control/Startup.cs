using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        //ec=xercise 6
        //BirthdayCelebrations();

        //exercise 7 
        FoodShortage();

    }

    private static void FoodShortage()
    {
        var n = int.Parse(Console.ReadLine());

        Dictionary<string, IBuyer> buyers = new Dictionary<string, IBuyer>();

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (input.Count == 4)
            {
                buyers.Add(input[0], new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
            }
            else
            {
                buyers.Add(input[0] , new Rebel(input[0], int.Parse(input[1]), input[2]));
            }
        }

        var data = Console.ReadLine();

        while (data != "End")
        {
            if (buyers.ContainsKey(data))
            {
                buyers[data].BuyFood();
            }

            data = Console.ReadLine();
        }

        Console.WriteLine(buyers.Values.Sum(b => b.Food));

    }

    private static void BirthdayCelebrations()
    {
        Society society = new Society();

        var input = Console.ReadLine();

        while (input != "End")
        {
            var splitted = input
                .Split(' ')
                .ToList();

            if (splitted[0] == "Robot")
            {
                society.AddInhabitant(new Robot(splitted[1], splitted[2]));
            }
            else if (splitted[0] == "Citizen")
            {
                society.AddInhabitant(new Citizen(splitted[1], int.Parse(splitted[2]), splitted[3], splitted[4]));
                society.AddPetOrCitizen(new Citizen(splitted[1], int.Parse(splitted[2]), splitted[3], splitted[4]));
            }
            else
            {
                society.AddPetOrCitizen(new Pet(splitted[1], splitted[2]));
            }

            input = Console.ReadLine();
        }

        var year = Console.ReadLine();

        Console.WriteLine(society.GetBurthdatesInYear(year));
    }
}

