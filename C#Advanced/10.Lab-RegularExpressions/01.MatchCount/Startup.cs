using System;
using System.Text.RegularExpressions;

namespace _01.MatchCount
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var pattern = Console.ReadLine();
            var text = Console.ReadLine();

            Regex regex = new Regex($"{pattern}");
            var matches = regex.Matches(text);

            Console.WriteLine(matches.Count);

        }
    }
}
