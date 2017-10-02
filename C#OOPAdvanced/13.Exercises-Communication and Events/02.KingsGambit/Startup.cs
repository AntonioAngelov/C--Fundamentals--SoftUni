using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main(string[] args)
    {
        var kingName = Console.ReadLine();
        King king = new King(kingName);

        List<Soldier> army = new List<Soldier>();

        var royalGuardsNames = Console.ReadLine()
            .Split(' ');

        foreach (var name in royalGuardsNames)
        {
            var currentGuard = new RoyalGuard(name);
            army.Add(currentGuard);

            king.UnderAttack += currentGuard.KingUnderAttack;
        }

        var footmnNames = Console.ReadLine()
            .Split(' ');

        foreach (var name in footmnNames)
        {
            var currentFootman = new Footman(name);
            army.Add(currentFootman);

            king.UnderAttack += currentFootman.KingUnderAttack;
        }

        var command = Console.ReadLine();

        while (command != "End")
        {
            if (command == "Attack King")
            {
               king.OnUnderAttack(); 
            }

            else
            {
                string soldierName = command
                    .Split(' ')
                    .LastOrDefault();

                Soldier soldier = army.FirstOrDefault(s => s.Name == soldierName);

                if (!soldier.SurviveAttack())
                {
                    king.UnderAttack -= soldier.KingUnderAttack;
                    army.Remove(soldier);
                }
            }

            command = Console.ReadLine();
        }

    }
}

