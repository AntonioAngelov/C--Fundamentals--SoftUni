using System;
using System.Linq;

public class Startup
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine();
        var manager = new DraftManager();

        while (input != "Shutdown")
        {
            var splitted = input
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = splitted[0];
            var arguments = splitted.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(manager.RegisterHarvester(arguments));
                    break;
                case "RegisterProvider":
                    Console.WriteLine(manager.RegisterProvider(arguments));
                    break;
                case "Day":
                    Console.WriteLine(manager.Day());
                    break;
                case "Mode":
                    Console.WriteLine(manager.Mode(arguments));
                    break;
                case "Check":
                    Console.WriteLine(manager.Check(arguments));
                    break;
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(manager.ShutDown());
    }
    
}
