using System;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();

        var manager = new CarManager();

        while (input != "Cops Are Here")
        {
            var command = input
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            switch (command[0])
            {
                case "register":
                    manager.Register(int.Parse(command[1]), command[2], command[3], command[4], int.Parse(command[5]),
                        int.Parse(command[6]), int.Parse(command[7]), int.Parse(command[8]), int.Parse(command[9]));
                    break;
                case "check":
                    Console.WriteLine(manager.Check(int.Parse(command[1])));
                    break;
                case "open":
                    manager.Open(int.Parse(command[1]), command[2], int.Parse(command[3]), command[4], int.Parse(command[5]), command.Count > 6 ? int.Parse(command[6]) : 0);
                    break;
                case "participate":
                    manager.Participate(int.Parse(command[1]), int.Parse(command[2]));
                    break;
                case "start":
                    Console.WriteLine(manager.Start(int.Parse(command[1])));
                    break;
                case "park":
                    manager.Park(int.Parse(command[1]));
                    break;
                case "unpark":
                    manager.Unpark(int.Parse(command[1]));
                    break;
                case "tune":
                    manager.Tune(int.Parse(command[1]), command[2]);
                    break;
            }

            input = Console.ReadLine();
        }
    }
}
