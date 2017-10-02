using System;
using System.Text.RegularExpressions;

namespace _03.SeriesOfLetters
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex(@"(.)\1+");

            var result = regex.Replace(input, "$1");

            Console.WriteLine(result);
        }
    }
}
