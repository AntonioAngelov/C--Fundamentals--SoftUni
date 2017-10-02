using System;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var nationsBuilder = new NationsBuilder();

        var input = Console.ReadLine();

        while (input != "Quit")
        {
            var splitted = input
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = splitted[0];
            var paramethers = splitted.Skip(1).ToList();

            switch (command)
            {
                case "Bender":
                    nationsBuilder.AssignBender(paramethers);
                    break;
                case "Monument":
                    nationsBuilder.AssignMonument(paramethers);
                    break;
                case "Status":
                    Console.WriteLine(nationsBuilder.GetStatus(paramethers[0]));
                    break;
                case "War":
                    nationsBuilder.IssueWar(paramethers[0]);
                    break;
            }


            input = Console.ReadLine();
        }

        Console.WriteLine(nationsBuilder.GetWarsRecord());
    }
}

