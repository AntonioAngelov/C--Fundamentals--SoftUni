namespace _05.AppliedArithmetics
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine();

            while (command != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(n => n + 1).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => n * 2).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => n - 1).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }


                command = Console.ReadLine();
            }

        }
    }
}
