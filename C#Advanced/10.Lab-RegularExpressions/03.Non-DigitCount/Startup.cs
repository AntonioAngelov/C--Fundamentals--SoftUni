using System;
using System.Text.RegularExpressions;

namespace _03.Non_DigitCount
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            Regex regex = new Regex("\\D");
            var matches = regex.Matches(text);

            Console.WriteLine($"Non-digits: {matches.Count}");
        }
    }
}
