using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    public class Program
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();

            Regex regex = new Regex(@"^[A-Z][a-z]+ [A-Z][a-z]+$");

            while (name != "end")
            {
                var matches = regex.Matches(name);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }

                name = Console.ReadLine();
            }
        }
    }
}
