using System;
using System.Text.RegularExpressions;

namespace _02.VowelCount
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var text = Console.ReadLine();

            Regex regex = new Regex("[AEIOUYaeiouy]");
            var matches = regex.Matches(text);

            Console.WriteLine($"Vowels: {matches.Count}");
        
        }
    }
}
