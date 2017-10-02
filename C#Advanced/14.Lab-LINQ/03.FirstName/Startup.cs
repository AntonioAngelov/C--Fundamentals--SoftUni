namespace _03.FirstName
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine()
                .Split(' ')
                .OrderBy(n => n)
                .ToList();

            var letters = Console.ReadLine()
                .Split(' ')
                .OrderBy(l => l)
                .ToList();

            for (int i = 0; i < letters.Count; i++)
            {
                var matches = names.Where(n => n.StartsWith(letters[i], StringComparison.OrdinalIgnoreCase));

                if (matches.Count() != 0)
                {
                    Console.WriteLine(matches.FirstOrDefault());
                    break;
                }
                else if (i == letters.Count - 1)
                {
                    Console.WriteLine("No match");
                }
            }
        }
    }
}
