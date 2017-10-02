namespace _11.ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = Console.ReadLine();

            var filters = new List<List<string>>();

            while (command != "Print")
            {
                var currentFilter = command.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                        .Skip(1)
                        .ToList(); ;

                if (command.StartsWith("Add"))
                {
                    filters.Add(currentFilter);
                }
                else
                {
                    filters = filters
                        .Where(f => f.SequenceEqual(currentFilter) == false)
                        .ToList();
                }

                command = Console.ReadLine();
            }

            var predicates = new Dictionary<string, Func<string, string, bool>>
                {
                    {"Starts with", (name, substring) => name.StartsWith(substring)},
                    {"Ends with", (name, substring) => name.EndsWith(substring)},
                    {"Length", (name, length) => name.Length.ToString().Equals(length)},
                    {"Contains", (name, substring) => name.Contains(substring)}
                };


            foreach (var f in filters)
            {
                people = people
                    .Where(p => predicates[f[0]](p, f[1]) == false)
                    .ToList();
            }

            Console.WriteLine(string.Join(" ", people));

        }
    }
}
